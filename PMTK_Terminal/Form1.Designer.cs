namespace PMTK_Terminal
{
    partial class Main_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.GB_Connection = new System.Windows.Forms.GroupBox();
            this.CB_Baudrate = new System.Windows.Forms.ComboBox();
            this.B_Close = new System.Windows.Forms.Button();
            this.L_ComPort = new System.Windows.Forms.Label();
            this.B_Open = new System.Windows.Forms.Button();
            this.CBox_Serial = new System.Windows.Forms.ComboBox();
            this.TB_DataField = new System.Windows.Forms.TextBox();
            this.GB_Packet = new System.Windows.Forms.GroupBox();
            this.B_Clear = new System.Windows.Forms.Button();
            this.B_Send = new System.Windows.Forms.Button();
            this.L_Checksum = new System.Windows.Forms.Label();
            this.L_StartSymbol = new System.Windows.Forms.Label();
            this.GB_Locus = new System.Windows.Forms.GroupBox();
            this.B_Dump = new System.Windows.Forms.Button();
            this.B_Erase = new System.Windows.Forms.Button();
            this.SS1 = new System.Windows.Forms.StatusStrip();
            this.ToolStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.GB_Connection.SuspendLayout();
            this.GB_Packet.SuspendLayout();
            this.GB_Locus.SuspendLayout();
            this.SS1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GB_Connection
            // 
            this.GB_Connection.Controls.Add(this.CB_Baudrate);
            this.GB_Connection.Controls.Add(this.B_Close);
            this.GB_Connection.Controls.Add(this.L_ComPort);
            this.GB_Connection.Controls.Add(this.B_Open);
            this.GB_Connection.Controls.Add(this.CBox_Serial);
            this.GB_Connection.Location = new System.Drawing.Point(12, 12);
            this.GB_Connection.Name = "GB_Connection";
            this.GB_Connection.Size = new System.Drawing.Size(470, 52);
            this.GB_Connection.TabIndex = 4;
            this.GB_Connection.TabStop = false;
            this.GB_Connection.Text = "Connection";
            // 
            // CB_Baudrate
            // 
            this.CB_Baudrate.FormattingEnabled = true;
            this.CB_Baudrate.Items.AddRange(new object[] {
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.CB_Baudrate.Location = new System.Drawing.Point(193, 19);
            this.CB_Baudrate.Name = "CB_Baudrate";
            this.CB_Baudrate.Size = new System.Drawing.Size(105, 21);
            this.CB_Baudrate.TabIndex = 7;
            // 
            // B_Close
            // 
            this.B_Close.Location = new System.Drawing.Point(389, 17);
            this.B_Close.Name = "B_Close";
            this.B_Close.Size = new System.Drawing.Size(75, 23);
            this.B_Close.TabIndex = 6;
            this.B_Close.Text = "Close";
            this.B_Close.UseVisualStyleBackColor = true;
            this.B_Close.Click += new System.EventHandler(this.B_Close_Click);
            // 
            // L_ComPort
            // 
            this.L_ComPort.AutoSize = true;
            this.L_ComPort.Location = new System.Drawing.Point(20, 22);
            this.L_ComPort.Name = "L_ComPort";
            this.L_ComPort.Size = new System.Drawing.Size(56, 13);
            this.L_ComPort.TabIndex = 0;
            this.L_ComPort.Text = "Com Port :";
            // 
            // B_Open
            // 
            this.B_Open.Location = new System.Drawing.Point(308, 17);
            this.B_Open.Name = "B_Open";
            this.B_Open.Size = new System.Drawing.Size(75, 23);
            this.B_Open.TabIndex = 5;
            this.B_Open.Text = "Open";
            this.B_Open.UseVisualStyleBackColor = true;
            this.B_Open.Click += new System.EventHandler(this.B_Open_Click);
            // 
            // CBox_Serial
            // 
            this.CBox_Serial.FormattingEnabled = true;
            this.CBox_Serial.Location = new System.Drawing.Point(82, 19);
            this.CBox_Serial.Name = "CBox_Serial";
            this.CBox_Serial.Size = new System.Drawing.Size(105, 21);
            this.CBox_Serial.TabIndex = 0;
            // 
            // TB_DataField
            // 
            this.TB_DataField.Location = new System.Drawing.Point(38, 19);
            this.TB_DataField.Name = "TB_DataField";
            this.TB_DataField.Size = new System.Drawing.Size(381, 20);
            this.TB_DataField.TabIndex = 5;
            this.TB_DataField.TextChanged += new System.EventHandler(this.TB_DataField_TextChanged);
            // 
            // GB_Packet
            // 
            this.GB_Packet.Controls.Add(this.B_Clear);
            this.GB_Packet.Controls.Add(this.B_Send);
            this.GB_Packet.Controls.Add(this.L_Checksum);
            this.GB_Packet.Controls.Add(this.L_StartSymbol);
            this.GB_Packet.Controls.Add(this.TB_DataField);
            this.GB_Packet.Location = new System.Drawing.Point(12, 70);
            this.GB_Packet.Name = "GB_Packet";
            this.GB_Packet.Size = new System.Drawing.Size(470, 92);
            this.GB_Packet.TabIndex = 6;
            this.GB_Packet.TabStop = false;
            this.GB_Packet.Text = "Packet transmitter";
            // 
            // B_Clear
            // 
            this.B_Clear.Location = new System.Drawing.Point(244, 54);
            this.B_Clear.Name = "B_Clear";
            this.B_Clear.Size = new System.Drawing.Size(190, 23);
            this.B_Clear.TabIndex = 10;
            this.B_Clear.Text = "Clear";
            this.B_Clear.UseVisualStyleBackColor = true;
            this.B_Clear.Click += new System.EventHandler(this.B_Clear_Click);
            // 
            // B_Send
            // 
            this.B_Send.Location = new System.Drawing.Point(38, 54);
            this.B_Send.Name = "B_Send";
            this.B_Send.Size = new System.Drawing.Size(190, 23);
            this.B_Send.TabIndex = 9;
            this.B_Send.Text = "Send";
            this.B_Send.UseVisualStyleBackColor = true;
            this.B_Send.Click += new System.EventHandler(this.B_Send_Click);
            // 
            // L_Checksum
            // 
            this.L_Checksum.AutoSize = true;
            this.L_Checksum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Checksum.Location = new System.Drawing.Point(425, 19);
            this.L_Checksum.Name = "L_Checksum";
            this.L_Checksum.Size = new System.Drawing.Size(37, 20);
            this.L_Checksum.TabIndex = 8;
            this.L_Checksum.Text = "* 00";
            // 
            // L_StartSymbol
            // 
            this.L_StartSymbol.AutoSize = true;
            this.L_StartSymbol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_StartSymbol.Location = new System.Drawing.Point(20, 19);
            this.L_StartSymbol.Name = "L_StartSymbol";
            this.L_StartSymbol.Size = new System.Drawing.Size(18, 20);
            this.L_StartSymbol.TabIndex = 7;
            this.L_StartSymbol.Text = "$";
            // 
            // GB_Locus
            // 
            this.GB_Locus.Controls.Add(this.B_Dump);
            this.GB_Locus.Controls.Add(this.B_Erase);
            this.GB_Locus.Location = new System.Drawing.Point(12, 168);
            this.GB_Locus.Name = "GB_Locus";
            this.GB_Locus.Size = new System.Drawing.Size(470, 78);
            this.GB_Locus.TabIndex = 7;
            this.GB_Locus.TabStop = false;
            this.GB_Locus.Text = "Locus";
            // 
            // B_Dump
            // 
            this.B_Dump.Location = new System.Drawing.Point(244, 21);
            this.B_Dump.Name = "B_Dump";
            this.B_Dump.Size = new System.Drawing.Size(190, 38);
            this.B_Dump.TabIndex = 11;
            this.B_Dump.Text = "Dump Flash Memory";
            this.B_Dump.UseVisualStyleBackColor = true;
            this.B_Dump.Click += new System.EventHandler(this.B_Dump_Click);
            // 
            // B_Erase
            // 
            this.B_Erase.Location = new System.Drawing.Point(38, 21);
            this.B_Erase.Name = "B_Erase";
            this.B_Erase.Size = new System.Drawing.Size(190, 38);
            this.B_Erase.TabIndex = 10;
            this.B_Erase.Text = "Erase Flash Memory";
            this.B_Erase.UseVisualStyleBackColor = true;
            this.B_Erase.Click += new System.EventHandler(this.B_Erase_Click);
            // 
            // SS1
            // 
            this.SS1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripLabel});
            this.SS1.Location = new System.Drawing.Point(0, 251);
            this.SS1.Name = "SS1";
            this.SS1.Size = new System.Drawing.Size(494, 22);
            this.SS1.TabIndex = 8;
            this.SS1.Text = "statusStrip1";
            // 
            // ToolStripLabel
            // 
            this.ToolStripLabel.Name = "ToolStripLabel";
            this.ToolStripLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 273);
            this.Controls.Add(this.SS1);
            this.Controls.Add(this.GB_Locus);
            this.Controls.Add(this.GB_Packet);
            this.Controls.Add(this.GB_Connection);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main_Form";
            this.Text = "PMTK Terminal";
            this.Load += new System.EventHandler(this.Main_Form_Load);
            this.GB_Connection.ResumeLayout(false);
            this.GB_Connection.PerformLayout();
            this.GB_Packet.ResumeLayout(false);
            this.GB_Packet.PerformLayout();
            this.GB_Locus.ResumeLayout(false);
            this.SS1.ResumeLayout(false);
            this.SS1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GB_Connection;
        private System.Windows.Forms.Button B_Close;
        private System.Windows.Forms.Label L_ComPort;
        private System.Windows.Forms.Button B_Open;
        private System.Windows.Forms.ComboBox CBox_Serial;
        private System.Windows.Forms.TextBox TB_DataField;
        private System.Windows.Forms.GroupBox GB_Packet;
        private System.Windows.Forms.Label L_StartSymbol;
        private System.Windows.Forms.Button B_Clear;
        private System.Windows.Forms.Button B_Send;
        private System.Windows.Forms.Label L_Checksum;
        private System.Windows.Forms.ComboBox CB_Baudrate;
        private System.Windows.Forms.GroupBox GB_Locus;
        private System.Windows.Forms.Button B_Dump;
        private System.Windows.Forms.Button B_Erase;
        private System.Windows.Forms.StatusStrip SS1;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripLabel;
    }
}

