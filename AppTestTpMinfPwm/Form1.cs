﻿using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace AppCsTp2Pwm
{
    public partial class Form1 : Form
    {
        public delegate void ReceiverD();
        public ReceiverD myDelegate;
        int ctsCount = 0;
        int m_SendCount = 0;
        int m_DispCount = 0;
        byte[] Mess1 = new byte[5];
        string Message = "";

        const byte stx = 0xAA;
        const int m_MessSize = 5;
        CalCrc16 MyCrc = new CalCrc16();

        char[] tbFormes = { 'S', 'C', 'T', 'D' };  

        public Form1()
        {
            InitializeComponent();
            // Get a list of serial port names.
            string[] ports = SerialPort.GetPortNames();
            //Array.Sort(ports);
            cboPortNames.Items.AddRange(ports);
            cboPortNames.SelectedIndex = 0;
            lstDataIn.Items.Clear();

            myDelegate = new ReceiverD(DispInListRxData);

        }

        void DispTxMess(byte[] Mess, int len)
        {
            string messAffiche = "";

            for (int i = 0; i < len; i++)
            {
                messAffiche = messAffiche + NumToHex(Mess[i]) + " ";
            }
            lstDataOut.Items.Add(messAffiche);

            //ne garde que les 10 dernières lignes
            if (lstDataOut.Items.Count > 10)
                lstDataOut.Items.RemoveAt(0);
        }

        void composeMessage( ref byte[] Mess)
        {
            //ushort crc = 0xFFFF;
            //sbyte messAfficheVal;
            string tmpVal;

            //Mess[0] = 33;   // ! = 33 = 0x21
            Message = "!S=";
            //crc = MyCrc.updateCRC16(crc, stx);
            //TmpVal = (sbyte)tbFormes[cbForme.SelectedIndex];
            try
            {
                tmpVal = tbFormes[cbForme.SelectedIndex].ToString();
            }
            catch
            {
                tmpVal = tbFormes[0].ToString();
            }
            // Mess[1] = ConvSignedToByte(TmpVal);
            //Mess[1] = (byte)TmpVal;
            Message = Message + tmpVal + "F=";
            //crc = MyCrc.updateCRC16(crc, Mess[1]);
            //TmpVal = (sbyte)nudFreq.Value;
            tmpVal = nudFreq.Value.ToString();
            //Mess[2] = ConvSignedToByte(TmpVal);
            //Mess[2] = (byte)TmpVal;
            Message = Message + tmpVal + "A=";
            //crc = MyCrc.updateCRC16(crc, Mess[2]);
            //Mess[3] = (byte)(crc >> 8);      // attention MSB
            //Mess[4] = (byte)(crc & 0xFF);    // attention LSB
            //TmpVal = (sbyte)nudAmpl.Value;
            tmpVal = nudAmpl.Value.ToString();
            //Mess[3] = (byte)TmpVal;
            Message = Message + tmpVal + "O=";
            //TmpVal = (sbyte)nudOffset.Value;
            if (nudOffset.Value >= 0)
            {
                Message += "+";
            }
            tmpVal = nudOffset.Value.ToString();
            //Mess[4] = (byte)TmpVal;
            Message = Message + tmpVal + "W=";
            if (chkSave.Checked)
            {
                Message += "1#";
            }
            else
            {
                Message += "0#";
            }

            DispTxMess(Message);   //Affichage trame TX
        }

        // compose un message raccourci sans le CRC
        void composeBadMessage(ref byte[] Mess)
        {
            // compose un message raccourci sans le CRC
            sbyte TmpVal;

            Mess[0] = stx;
            TmpVal = (sbyte)cbForme.SelectedValue;
            Mess[1] = (byte)TmpVal;
            TmpVal = (sbyte)nudFreq.Value;
            Mess[2] = (byte)TmpVal;
            
            DispTxMess(Mess, 3);   //Affichage trame TX
        }    
    
               
        string NumToHex(byte val)
        {
            string tmp = val.ToString("X");
            if (tmp.Length < 2)
            {
                tmp = "0" + tmp;
            }
            return tmp;
        }

        void SendMessage(int count)
        {
            int NbCharMess;
            // Envoie le message si le port est ouvert
            if (serialPort1.IsOpen) {

                composeMessage(ref Mess1);
                NbCharMess = m_MessSize;

                try {
                    //serialPort1.Write(Mess1, 0, NbCharMess);
                    serialPort1.Write(Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Erreur à l'envoi !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    timer1.Stop();     // pour éviter problème en mode continu
                  

                    serialPort1.DiscardInBuffer();
                    serialPort1.DiscardOutBuffer();
                }

            } else { 
                MessageBox.Show("Port non ouvert", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                timer1.Stop();     // pour éviter problème en mode continu
            }
        }

        private void btOpenClose_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)    //ouverture du port
            {
                // Configuration du port
                serialPort1.PortName = (string)cboPortNames.SelectedItem;
                serialPort1.BaudRate  = 57600;
                serialPort1.Parity    = Parity.None;
                serialPort1.DataBits  = 8;
                serialPort1.StopBits  = StopBits.One;
                serialPort1.Handshake = Handshake.RequestToSend;

                // Set the read/write timeouts
                serialPort1.ReadTimeout = 100;
                serialPort1.WriteTimeout = 100;

                try
                {
                    serialPort1.Open();

                    btOpenClose.Text = "Close";
                    USB.Enabled = true;
                    cboPortNames.Enabled = false;
                }
                catch (Exception ex)
                {
                    if (!serialPort1.IsOpen)
                        MessageBox.Show(ex.ToString(), "Erreur à l'ouverture du port !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                cbForme.SelectedIndex = 0;
            }
            else //fermeture
            {
                serialPort1.Close();

                btOpenClose.Text = "Open";
                USB.Enabled = false;
                cboPortNames.Enabled = true;
                timer1.Stop();
            }

        } // end btOpenClose_Click

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //lstDataIn.Invoke(myDelegate);
            lstDataIn.BeginInvoke(myDelegate);
        }

        public void DispInListRxData()
        {
            ushort i = 0;
            ushort j = 0;
            byte[] RxMess = new byte[30];
            //string rxMessage;
            //ushort Crc;

            ushort iForme = 0;
            ushort iFreq = 0;
            ushort iAmpl = 0;
            ushort iOffset = 0;
            ushort iSave = 0;

            string messAffiche = "";
            int calculTmp = 0;

            // Traitement de la réception

            //cherche début de trame
            do
            {
                RxMess[0] = (byte)serialPort1.ReadByte();
            } while (RxMess[0] != 0x21);    // Tant que RxMess != "!"
            //} while (RxMess[0] != stx && serialPort1.BytesToRead >= 4);

            //rxMessage = serialPort1.ReadLine();


            //décode suite du msg
            if (serialPort1.BytesToRead >= 18)
            {
                do
                {
                    // Lecture du port si il y a des bytes à lire
                    if (serialPort1.BytesToRead != 0)
                    {
                        i++;
                        RxMess[i] = (byte)serialPort1.ReadByte();
                        if ((RxMess[i] == 'S') && (iForme == 0))
                        {
                            iForme = i;
                        }
                        else if (RxMess[i] == 'F')
                        {
                            iFreq = i;
                        }
                        else if (RxMess[i] == 'A')
                        {
                            iAmpl = i;
                        }
                        else if (RxMess[i] == 'O')
                        {
                            iOffset = i;
                        }
                        else if (RxMess[i] == 'W')
                        {
                            iSave = i;
                        }
                    }
                } while (RxMess[i] != 0x23);    // Faire tant que Rxmess[i] n'est pas égal à #

                // Écriture de la forme dans la case prévue
                txtForme.Text = ((char)RxMess[iForme + 2]).ToString();

                j = 2;
                for (j += iFreq ; j < iAmpl; j++)
                {
                    calculTmp *= 10;
                    calculTmp += RxMess[j] - '0';
                }
                txtFreq.Text = calculTmp.ToString();

                j = 2;
                calculTmp = 0;
                for (j += iAmpl; j < iOffset; j++)
                {
                    calculTmp *= 10;
                    calculTmp += RxMess[j] - '0';
                }
                txtAmpl.Text = calculTmp.ToString();

                j = 3;
                calculTmp = 0;
                for (j += iOffset; j < iSave; j++)
                {
                    calculTmp *= 10;
                    calculTmp += RxMess[j] - '0';
                }
                if(RxMess[iOffset+2]>='-')
                {
                    calculTmp *= -1;
                }
                txtOffset.Text = calculTmp.ToString();

                //Affichage de la trame recue
                messAffiche = "";
                for (j = 0; j <= i; j++)
                {
                    //Reécriture du message reçu
                    messAffiche += ((char)RxMess[j]).ToString();
                }
                // Envoy du message reécrit dans la boite de réception
                lstDataIn.Items.Add(messAffiche);

                //ne garde que les 10 dernières lignes
                if (lstDataIn.Items.Count > 10)
                    lstDataIn.Items.RemoveAt(0);

            }
        }

        string ConvUsignedToSignedString(byte val)
        {
            string Res = "";
            short tmp;
            if (val < 128) {
                tmp = val;
            } else
            {
                tmp = val;
                tmp -= 256;
            }
            Res = tmp.ToString();
            return Res;
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            // Envoie le message si le port est ouvert
            m_SendCount = 0;
            SendMessage(m_SendCount);

            //stoppe envoi continu
            if (timer1.Enabled)
            {
                timer1.Stop();
            }           
        }

        private void btSendContinuous_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                //active envoi continu
                timer1.Interval = 50;  // pour 1 message chaque 50 ms
                m_SendCount = 0;
                ctsCount = 0;
                timer1.Start();
            }
            else
            {
                //désactive envoi continu
                timer1.Stop();
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (serialPort1.CtsHolding == true) //ctrl de flux autorise émission ? 
            {
                ctsCount = 0;
                // Envoie le message
                m_SendCount = m_SendCount + 1;
                SendMessage(m_SendCount);
            }
            else
            {
                ctsCount++;
                if (ctsCount >= 10)   //stoppe émission et timer au bout de 10x avec ctrl de flux qui bloque
                {                   
                    //désactive envoi continu
                    timer1.Stop();
                    MessageBox.Show("Le contrôle de flux HW bloque l'émission !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
 
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();

            // Fermeture du port si nécessaire.
            // Workaround pour éviter blocage de l'app à la fermeture
            // Un simple appel à serialPort1.Close() fige l'app !
            try
            {
                serialPort1.Handshake = Handshake.None;
                serialPort1.DtrEnable = false;
                serialPort1.RtsEnable = false;
                serialPort1.DataReceived -= serialPort1_DataReceived;
                Thread.Sleep(200);
                if (serialPort1.IsOpen)
                {
                    serialPort1.DiscardInBuffer();
                    serialPort1.DiscardOutBuffer();
                    serialPort1.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Erreur à la fermeture du port !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbForme_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void USB_Enter(object sender, EventArgs e)
        {

        }
    }
}
