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
            this.USB = new System.Windows.Forms.GroupBox();
            this.cbForme = new System.Windows.Forms.ComboBox();
            this.nudOffset = new System.Windows.Forms.NumericUpDown();
            this.nudAmpl = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lstDataOut = new System.Windows.Forms.ListBox();
            this.btSend = new System.Windows.Forms.Button();
            this.chkSave = new System.Windows.Forms.CheckBox();
            this.nudFreq = new System.Windows.Forms.NumericUpDown();
            this.txtOffset = new System.Windows.Forms.TextBox();
            this.txtAmpl = new System.Windows.Forms.TextBox();
            this.lstDataIn = new System.Windows.Forms.ListBox();
            this.txtFreq = new System.Windows.Forms.TextBox();
            this.txtForme = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gbCom.SuspendLayout();
            this.USB.SuspendLayout();
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
            this.gbCom.Size = new System.Drawing.Size(245, 70);
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
            // USB
            // 
            this.USB.Controls.Add(this.lstDataIn);
            this.USB.Controls.Add(this.btSend);
            this.USB.Controls.Add(this.txtFreq);
            this.USB.Controls.Add(this.txtForme);
            this.USB.Controls.Add(this.label6);
            this.USB.Controls.Add(this.txtOffset);
            this.USB.Controls.Add(this.label5);
            this.USB.Controls.Add(this.cbForme);
            this.USB.Controls.Add(this.nudOffset);
            this.USB.Controls.Add(this.txtAmpl);
            this.USB.Controls.Add(this.nudAmpl);
            this.USB.Controls.Add(this.label1);
            this.USB.Controls.Add(this.label4);
            this.USB.Controls.Add(this.lstDataOut);
            this.USB.Controls.Add(this.chkSave);
            this.USB.Controls.Add(this.nudFreq);
            this.USB.Enabled = false;
            this.USB.Location = new System.Drawing.Point(12, 88);
            this.USB.Name = "USB";
            this.USB.Size = new System.Drawing.Size(515, 240);
            this.USB.TabIndex = 21;
            this.USB.TabStop = false;
            this.USB.Text = "USB";
            this.USB.Enter += new System.EventHandler(this.USB_Enter);
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
            this.cbForme.Location = new System.Drawing.Point(88, 24);
            this.cbForme.Name = "cbForme";
            this.cbForme.Size = new System.Drawing.Size(76, 21);
            this.cbForme.TabIndex = 62;
            this.cbForme.SelectedIndexChanged += new System.EventHandler(this.cbForme_SelectedIndexChanged);
            // 
            // nudOffset
            // 
            this.nudOffset.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudOffset.Location = new System.Drawing.Point(350, 63);
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
            this.nudOffset.TabIndex = 61;
            // 
            // nudAmpl
            // 
            this.nudAmpl.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudAmpl.Location = new System.Drawing.Point(350, 22);
            this.nudAmpl.Margin = new System.Windows.Forms.Padding(2);
            this.nudAmpl.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudAmpl.Name = "nudAmpl";
            this.nudAmpl.Size = new System.Drawing.Size(56, 20);
            this.nudAmpl.TabIndex = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(296, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 59;
            this.label1.Text = "Offset";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(278, 25);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 58;
            this.label4.Text = "Amplitude";
            // 
            // lstDataOut
            // 
            this.lstDataOut.FormattingEnabled = true;
            this.lstDataOut.Location = new System.Drawing.Point(24, 110);
            this.lstDataOut.Margin = new System.Windows.Forms.Padding(2);
            this.lstDataOut.Name = "lstDataOut";
            this.lstDataOut.Size = new System.Drawing.Size(221, 43);
            this.lstDataOut.TabIndex = 56;
            // 
            // btSend
            // 
            this.btSend.Location = new System.Drawing.Point(179, 174);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(152, 46);
            this.btSend.TabIndex = 52;
            this.btSend.Text = "Envoi";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // chkSave
            // 
            this.chkSave.AutoSize = true;
            this.chkSave.Location = new System.Drawing.Point(24, 174);
            this.chkSave.Margin = new System.Windows.Forms.Padding(2);
            this.chkSave.Name = "chkSave";
            this.chkSave.Size = new System.Drawing.Size(84, 17);
            this.chkSave.TabIndex = 49;
            this.chkSave.Text = "Sauvegarde";
            this.chkSave.UseVisualStyleBackColor = true;
            // 
            // nudFreq
            // 
            this.nudFreq.Increment = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudFreq.Location = new System.Drawing.Point(88, 63);
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
            this.nudFreq.Size = new System.Drawing.Size(76, 20);
            this.nudFreq.TabIndex = 29;
            this.nudFreq.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // txtOffset
            // 
            this.txtOffset.Location = new System.Drawing.Point(435, 63);
            this.txtOffset.Margin = new System.Windows.Forms.Padding(2);
            this.txtOffset.Name = "txtOffset";
            this.txtOffset.ReadOnly = true;
            this.txtOffset.Size = new System.Drawing.Size(70, 20);
            this.txtOffset.TabIndex = 61;
            // 
            // txtAmpl
            // 
            this.txtAmpl.Location = new System.Drawing.Point(435, 22);
            this.txtAmpl.Margin = new System.Windows.Forms.Padding(2);
            this.txtAmpl.Name = "txtAmpl";
            this.txtAmpl.ReadOnly = true;
            this.txtAmpl.Size = new System.Drawing.Size(70, 20);
            this.txtAmpl.TabIndex = 60;
            // 
            // lstDataIn
            // 
            this.lstDataIn.FormattingEnabled = true;
            this.lstDataIn.Location = new System.Drawing.Point(281, 110);
            this.lstDataIn.Margin = new System.Windows.Forms.Padding(2);
            this.lstDataIn.Name = "lstDataIn";
            this.lstDataIn.Size = new System.Drawing.Size(221, 43);
            this.lstDataIn.TabIndex = 52;
            // 
            // txtFreq
            // 
            this.txtFreq.Location = new System.Drawing.Point(189, 65);
            this.txtFreq.Margin = new System.Windows.Forms.Padding(2);
            this.txtFreq.Name = "txtFreq";
            this.txtFreq.ReadOnly = true;
            this.txtFreq.Size = new System.Drawing.Size(70, 20);
            this.txtFreq.TabIndex = 57;
            // 
            // txtForme
            // 
            this.txtForme.Location = new System.Drawing.Point(189, 22);
            this.txtForme.Margin = new System.Windows.Forms.Padding(2);
            this.txtForme.Name = "txtForme";
            this.txtForme.ReadOnly = true;
            this.txtForme.Size = new System.Drawing.Size(70, 20);
            this.txtForme.TabIndex = 56;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 66);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 55;
            this.label6.Text = "Fréquence";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 24);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "Forme";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 333);
            this.Controls.Add(this.USB);
            this.Controls.Add(this.gbCom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "App de test TP MINF PWM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.gbCom.ResumeLayout(false);
            this.USB.ResumeLayout(false);
            this.USB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmpl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFreq)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox gbCom;
        private System.Windows.Forms.ComboBox cboPortNames;
        private System.Windows.Forms.GroupBox USB;
        private System.Windows.Forms.CheckBox chkSave;
        private System.Windows.Forms.NumericUpDown nudFreq;
        private System.Windows.Forms.Button btOpenClose;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.ListBox lstDataIn;
        private System.Windows.Forms.TextBox txtFreq;
        private System.Windows.Forms.TextBox txtForme;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstDataOut;
        private System.Windows.Forms.NumericUpDown nudOffset;
        private System.Windows.Forms.NumericUpDown nudAmpl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOffset;
        private System.Windows.Forms.TextBox txtAmpl;
        private System.Windows.Forms.ComboBox cbForme;
    }
}

