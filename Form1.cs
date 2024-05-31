using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace AppCsTp2Pwm
{
    public partial class Form1 : Form
    {
        // Récupère tous les noms de ports disponibles et les stocke dans un tableau
        string[] ports = SerialPort.GetPortNames();
        int[] Datas = new int[4]; // Tableau pour stocker les données
        int signalForm; // Forme du signal
        string FinalMsg; // Message final à envoyer
        byte[] Datasend = new byte[28]; // Tableau pour envoyer les données

        // Déclaration pour la lecture du port série
        public delegate void ReceiverD();
        public ReceiverD myDelegate;

        public Form1()
        {
            InitializeComponent();
            // Obtient une liste des noms de ports série disponibles
            string[] ports = SerialPort.GetPortNames();
            // Ajoute les noms de port à la comboBox
            cboPortNames.Items.AddRange(ports);
            cboPortNames.SelectedIndex = 0; // Sélectionne le premier port par défaut
            lstDataIn.Items.Clear(); // Vide la liste des données reçues

            // Assigne la méthode DispInListRxData au délégué
            myDelegate = new ReceiverD(DispInListRxData);
        }

        // Affiche le message transmis sous forme hexadécimale
        void DispTxMess(byte[] Mess, int len)
        {
            string tmp = "";

            for (int i = 0; i < len; i++)
            {
                tmp = tmp + NumToHex(Mess[i]) + " ";
            }
            lstDataOut.Items.Add(tmp);

            // Ne garde que les 10 dernières lignes
            if (lstDataOut.Items.Count > 10)
                lstDataOut.Items.RemoveAt(0);
        }

        // Affiche le message transmis sous forme de chaîne de caractères
        void DispTxMess(string mess)
        {
            lstDataOut.Items.Add(mess);

            // Ne garde que les 10 dernières lignes
            if (lstDataOut.Items.Count > 10)
                lstDataOut.Items.RemoveAt(0);
        }

        // Compose le message à envoyer
        string composeMessage()
        {
            string msgtotal = "!S=";

            // Ajoute le caractère correspondant à la forme du signal
            switch (Datas[0])
            {
                case 0:
                    msgtotal += "S";
                    break;
                case 1:
                    msgtotal += "C";
                    break;
                case 2:
                    msgtotal += "T";
                    break;
                case 3:
                    msgtotal += "D";
                    break;
                default:
                    break;
            }

            // Ajoute la fréquence formatée
            msgtotal += "F=";
            if (Datas[2] < 1000)
            {
                msgtotal += "0";
                if (Datas[2] < 100)
                {
                    msgtotal += "0";
                    if (Datas[2] < 10)
                    {
                        msgtotal += "0";
                    }
                }
            }
            msgtotal += Datas[2].ToString();

            // Ajoute l'amplitude formatée
            msgtotal += "A=";
            if (Datas[1] < 10000)
            {
                msgtotal += "0";
                if (Datas[1] < 1000)
                {
                    msgtotal += "0";
                    if (Datas[1] < 100)
                    {
                        msgtotal += "0";
                        if (Datas[1] < 10)
                        {
                            msgtotal += "0";
                        }
                    }
                }
            }
            msgtotal += Datas[1].ToString();

            // Ajoute l'offset formaté
            int valuemem;
            msgtotal += "O=";
            if (Datas[3] < 0)
            {
                valuemem = -Datas[3];
                msgtotal += "-";
            }
            else
            {
                valuemem = Datas[3];
                msgtotal += "+";
            }

            // Gestion des zéros supplémentaires pour l'offset
            if (valuemem < 1000)
            {
                msgtotal += "0";
                if (valuemem < 100)
                {
                    msgtotal += "0";
                    if (valuemem < 10)
                    {
                        msgtotal += "0";
                    }
                }
            }
            msgtotal += valuemem.ToString();

            // Ajoute l'état de sauvegarde
            msgtotal += "W=" + (chkSave.Checked ? "1" : "0");

            msgtotal += "#";

            return msgtotal;
        }

        // Convertit une valeur numérique en hexadécimal
        string NumToHex(byte val)
        {
            string tmp = val.ToString("X");
            if (tmp.Length < 2)
            {
                tmp = "0" + tmp;
            }
            return tmp;
        }

        // Envoie le message via le port série
        void SendMessage()
        {
            // Envoie le message si le port est ouvert
            if (serialPort1.IsOpen)
            {
                // Enregistre les paramètres
                Datas[0] = cbForme.SelectedIndex;
                Datas[1] = int.Parse(nudAmpl.Value.ToString());
                Datas[2] = int.Parse(nudFreq.Value.ToString());
                Datas[3] = int.Parse(nudOffset.Value.ToString());

                FinalMsg = composeMessage();

                try
                {
                    serialPort1.Write(FinalMsg);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Erreur à l'envoi !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    timer1.Stop(); // Arrête le timer en cas d'erreur en mode continu
                    btSendContinuous.Text = "Envoi continu";

                    serialPort1.DiscardInBuffer();
                    serialPort1.DiscardOutBuffer();
                }
            }
            else
            {
                MessageBox.Show("Port non ouvert", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                timer1.Stop(); // Arrête le timer en cas d'erreur
            }
        }

        // Gère l'ouverture et la fermeture du port série
        private void btOpenClose_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen) // Ouverture du port
            {
                // Configuration du port
                serialPort1.PortName = (string)cboPortNames.SelectedItem;
                serialPort1.BaudRate = 57600;
                serialPort1.Parity = Parity.None;
                serialPort1.DataBits = 8;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Handshake = Handshake.RequestToSend;

                // Définition des timeouts de lecture/écriture
                serialPort1.ReadTimeout = 100;
                serialPort1.WriteTimeout = 100;

                try
                {
                    serialPort1.Open();

                    btOpenClose.Text = "Close";
                    cboPortNames.Enabled = false;
                }
                catch (Exception ex)
                {
                    if (!serialPort1.IsOpen)
                        MessageBox.Show(ex.ToString(), "Erreur à l'ouverture du port !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                cbForme.SelectedIndex = 0;
            }
            else // Fermeture du port
            {
                serialPort1.Close();

                btOpenClose.Text = "Open";
                cboPortNames.Enabled = true;
                timer1.Stop();
                btSendContinuous.Text = "Envoi continu";
            }
        }

        // Gestion des données reçues via le port série
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Déclenche l'affichage des données reçues sur le thread principal
            lstDataIn.BeginInvoke(myDelegate);
        }

        public void DispInListRxData()
        {
            // Tableau pour lire les octets
            byte[] Dataread = new byte[30];
            // Chaîne de caractères des données reçues
            string msgread = "";
            // Lecture du port série
            serialPort1.Read(Dataread, 0, 30);

            // Conversion des octets en chaîne de caractères
            for (int i = 0; i < 30; i++)
            {
                msgread = msgread + Convert.ToChar(Dataread[i]);
            }
            // Affiche la trame reçue dans la liste
            lstDataIn.Items.Add(msgread).ToString();
        }

        // Gestion du timer pour l'envoi continu
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                // Envoie le message
                SendMessage();
            }
            else
            {
                btOpenClose.Text = "Open";
            }
        }

        // Gestion de la fermeture du formulaire
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();

            // Fermeture du port série si nécessaire pour éviter les blocages
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

        // Gestion du changement de sélection de la forme du signal
        private void cbForme_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Gestion des événements de changement de sélection de la forme du signal
        }

        // Envoi manuel du message
        private void btSend_Click_1(object sender, EventArgs e)
        {
            // Envoie le message si le port est ouvert
            SendMessage();

            // Affiche le message dans la liste de sortie
            lstDataOut.Items.Add(FinalMsg);

            // Arrête l'envoi continu si activé
            if (timer1.Enabled)
            {
                timer1.Stop();
                btSendContinuous.Text = "Envoi continu";
            }
        }

        // Gestion de l'envoi continu
        private void btSendContinuous_Click_1(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                // Active l'envoi continu
                timer1.Interval = 50; // Envoie un message toutes les 50 ms
                timer1.Start();
                btSendContinuous.Text = "Stop envoi";
            }
            else
            {
                // Désactive l'envoi continu
                timer1.Stop();
                btSendContinuous.Text = "Envoi continu";
            }
        }

        // Gestion du changement d'état du checkbox de sauvegarde
        private void chkSave_CheckedChanged(object sender, EventArgs e)
        {
            // Gestion des événements de changement d'état du checkbox de sauvegarde
        }
    }
}