namespace AppCsTp2Pwm
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gbCom = new System.Windows.Forms.GroupBox();
            this.btOpenClose = new System.Windows.Forms.Button();
            this.cboPortNames = new System.Windows.Forms.ComboBox();
            this.lstDataIn = new System.Windows.Forms.ListBox();
            this.cbForme = new System.Windows.Forms.ComboBox();
            this.nudOffset = new System.Windows.Forms.NumericUpDown();
            this.nudAmpl = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lstDataOut = new System.Windows.Forms.ListBox();
            this.btSendContinuous = new System.Windows.Forms.Button();
            this.btSend = new System.Windows.Forms.Button();
            this.chkSave = new System.Windows.Forms.CheckBox();
            this.nudFreq = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbCom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmpl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFreq)).BeginInit();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 19200;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // gbCom
            // 
            this.gbCom.Controls.Add(this.btOpenClose);
            this.gbCom.Controls.Add(this.cboPortNames);
            this.gbCom.Location = new System.Drawing.Point(12, 12);
            this.gbCom.Name = "gbCom";
            this.gbCom.Size = new System.Drawing.Size(515, 70);
            this.gbCom.TabIndex = 20;
            this.gbCom.TabStop = false;
            this.gbCom.Text = "Réglages communication";
            // 
            // btOpenClose
            // 
            this.btOpenClose.Location = new System.Drawing.Point(16, 30);
            this.btOpenClose.Name = "btOpenClose";
            this.btOpenClose.Size = new System.Drawing.Size(75, 23);
            this.btOpenClose.TabIndex = 19;
            this.btOpenClose.Text = "Open";
            this.btOpenClose.UseVisualStyleBackColor = true;
            this.btOpenClose.Click += new System.EventHandler(this.btOpenClose_Click);
            // 
            // cboPortNames
            // 
            this.cboPortNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPortNames.FormattingEnabled = true;
            this.cboPortNames.Location = new System.Drawing.Point(114, 32);
            this.cboPortNames.Margin = new System.Windows.Forms.Padding(2);
            this.cboPortNames.Name = "cboPortNames";
            this.cboPortNames.Size = new System.Drawing.Size(98, 21);
            this.cboPortNames.Sorted = true;
            this.cboPortNames.TabIndex = 17;
            // 
            // lstDataIn
            // 
            this.lstDataIn.FormattingEnabled = true;
            this.lstDataIn.Location = new System.Drawing.Point(287, 225);
            this.lstDataIn.Margin = new System.Windows.Forms.Padding(2);
            this.lstDataIn.Name = "lstDataIn";
            this.lstDataIn.Size = new System.Drawing.Size(221, 134);
            this.lstDataIn.TabIndex = 63;
            // 
            // cbForme
            // 
            this.cbForme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbForme.FormattingEnabled = true;
            this.cbForme.Items.AddRange(new object[] {
            "Sinus",
            "Carre",
            "Triangle",
            "Dent de scie"});
            this.cbForme.Location = new System.Drawing.Point(98, 105);
            this.cbForme.Name = "cbForme";
            this.cbForme.Size = new System.Drawing.Size(86, 21);
            this.cbForme.TabIndex = 75;
            // 
            // nudOffset
            // 
            this.nudOffset.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudOffset.Location = new System.Drawing.Point(396, 137);
            this.nudOffset.Margin = new System.Windows.Forms.Padding(2);
            this.nudOffset.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudOffset.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            -2147483648});
            this.nudOffset.Name = "nudOffset";
            this.nudOffset.Size = new System.Drawing.Size(56, 20);
            this.nudOffset.TabIndex = 74;
            // 
            // nudAmpl
            // 
            this.nudAmpl.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudAmpl.Location = new System.Drawing.Point(396, 105);
            this.nudAmpl.Margin = new System.Windows.Forms.Padding(2);
            this.nudAmpl.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudAmpl.Name = "nudAmpl";
            this.nudAmpl.Size = new System.Drawing.Size(56, 20);
            this.nudAmpl.TabIndex = 73;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(342, 139);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 72;
            this.label1.Text = "Offset";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(342, 107);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 71;
            this.label4.Text = "Amplitude";
            // 
            // lstDataOut
            // 
            this.lstDataOut.FormattingEnabled = true;
            this.lstDataOut.Location = new System.Drawing.Point(28, 225);
            this.lstDataOut.Margin = new System.Windows.Forms.Padding(2);
            this.lstDataOut.Name = "lstDataOut";
            this.lstDataOut.Size = new System.Drawing.Size(221, 134);
            this.lstDataOut.TabIndex = 70;
            // 
            // btSendContinuous
            // 
            this.btSendContinuous.Location = new System.Drawing.Point(352, 176);
            this.btSendContinuous.Name = "btSendContinuous";
            this.btSendContinuous.Size = new System.Drawing.Size(100, 23);
            this.btSendContinuous.TabIndex = 69;
            this.btSendContinuous.Text = "Envoi continu";
            this.btSendContinuous.UseVisualStyleBackColor = true;
            this.btSendContinuous.Click += new System.EventHandler(this.btSendContinuous_Click_1);
            // 
            // btSend
            // 
            this.btSend.Location = new System.Drawing.Point(84, 176);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(100, 23);
            this.btSend.TabIndex = 68;
            this.btSend.Text = "Envoi";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click_1);
            // 
            // chkSave
            // 
            this.chkSave.AutoSize = true;
            this.chkSave.Location = new System.Drawing.Point(227, 182);
            this.chkSave.Margin = new System.Windows.Forms.Padding(2);
            this.chkSave.Name = "chkSave";
            this.chkSave.Size = new System.Drawing.Size(84, 17);
            this.chkSave.TabIndex = 67;
            this.chkSave.Text = "Sauvegarde";
            this.chkSave.UseVisualStyleBackColor = true;
            this.chkSave.CheckedChanged += new System.EventHandler(this.chkSave_CheckedChanged);
            // 
            // nudFreq
            // 
            this.nudFreq.Increment = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudFreq.Location = new System.Drawing.Point(124, 134);
            this.nudFreq.Margin = new System.Windows.Forms.Padding(2);
            this.nudFreq.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudFreq.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudFreq.Name = "nudFreq";
            this.nudFreq.Size = new System.Drawing.Size(56, 20);
            this.nudFreq.TabIndex = 66;
            this.nudFreq.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 136);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 65;
            this.label3.Text = "Fréquence";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 107);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 64;
            this.label2.Text = "Forme";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 392);
            this.Controls.Add(this.cbForme);
            this.Controls.Add(this.nudOffset);
            this.Controls.Add(this.nudAmpl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstDataOut);
            this.Controls.Add(this.btSendContinuous);
            this.Controls.Add(this.btSend);
            this.Controls.Add(this.chkSave);
            this.Controls.Add(this.nudFreq);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstDataIn);
            this.Controls.Add(this.gbCom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "App de test TP MINF PWM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.gbCom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmpl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFreq)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox gbCom;
        private System.Windows.Forms.ComboBox cboPortNames;
        private System.Windows.Forms.Button btOpenClose;
        private System.Windows.Forms.ListBox lstDataIn;
        private System.Windows.Forms.ComboBox cbForme;
        private System.Windows.Forms.NumericUpDown nudOffset;
        private System.Windows.Forms.NumericUpDown nudAmpl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstDataOut;
        private System.Windows.Forms.Button btSendContinuous;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.CheckBox chkSave;
        private System.Windows.Forms.NumericUpDown nudFreq;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

