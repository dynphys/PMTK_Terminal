using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace PMTK_Terminal
{
    public partial class Main_Form : Form
    {
        #region Variables
        public string frame, export_path;
        public string[] frame_array = new string[65535];
        public string Ack;
        public List<string> LOCUS_Data = new List<string>();
        public string[] stringSeparators = new string[] { "\r\n" };
        

        public SerialPort _serialport = new SerialPort();
        public byte[] serial_buffer = new byte[65535];        //serial com buffer
        public int AllComBytes = 0;                         // Nb bytes reçus

        COM_States com_state = COM_States.Wait;

        public Timer _t = new Timer();
        public int t_cnt = 0;
        public int t_cnt_total = 0;
        public BackgroundWorker bw = new BackgroundWorker();

        public enum COM_States
        {
            WaitForLocusData,   //Attend une trame de données LOCUS
            WaitForAck,         //Attend un aknowledge
            Wait,               //Etat d'attente indéterminé
            Idle                //Dispo
        }
        #endregion

        public Main_Form()
        {
            InitializeComponent();
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            B_Close.Enabled = false;

            EnableGB(false);
            GetComPorts();
            CB_Baudrate.SelectedIndex = 1;
            TB_DataField.TextChanged += new EventHandler(TB_DataField_TextChanged);

            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);

        }

        #region Controls
        private void B_Open_Click(object sender, EventArgs e)
        {
            if (CBox_Serial.Text != "")
            {
                if (_serialport.IsOpen)
                {
                    //Port already opened
                }
                else
                {
                    try
                    {
                        _serialport.PortName = CBox_Serial.Text;
                        _serialport.BaudRate = Convert.ToInt32(CB_Baudrate.Text);
                        _serialport.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
                        _serialport.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "1");
                        _serialport.Handshake = (Handshake)Enum.Parse(typeof(Handshake), "None");
                        _serialport.Open();                                                                      //Open COM port
                        _serialport.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived); //IT Handler for _serialport
                        _serialport.ReceivedBytesThreshold = 1;
                    }
                    catch (Exception ex)
                    {
                        // Essayer de trouver si NumPort fermé, le soft entier est fermé
                        MessageBox.Show("Something went wrong during initialization : " + ex.Message + "\nCheck cables.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(1);
                    }

                    //Update connect buttons
                    B_Open.Enabled = false;
                    B_Close.Enabled = true;

                    EnableGB(true);
                }
            }
            else
            {
                //Pas de port COM sélectionné
                MessageBox.Show("No COM port is selected.", "Connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void B_Send_Click(object sender, EventArgs e)
        {
            string _frame = "$" + TB_DataField.Text + "*" + ComputeCHK().ToString("X2") + "\r\n";
            com_state = COM_States.WaitForAck;
            _serialport.Write(_frame);
            bw.RunWorkerAsync();
        }

        private void B_Close_Click(object sender, EventArgs e)
        {
            Quit();
        }

        private void B_Clear_Click(object sender, EventArgs e)
        {
            TB_DataField.Clear();
            ToolStripLabel.Text = "";
        }
        #endregion

        #region Functions
        private void GetComPorts()
        {
            // Get a list of serial port names.
            string[] ports = SerialPort.GetPortNames();

            foreach (string port in ports)
            {
                CBox_Serial.Items.Add(port);
            }
            CBox_Serial.SelectedIndex = 0;
        }
        private void EnableGB(bool state) /* Disable or enable all groupBox except GB_SerialPort*/
        {
            GB_Packet.Enabled = state;
            GB_Locus.Enabled = state;
        }
        private int ComputeCHK()
        {
            int i = 0;
            int checksum = 0;
            byte[] DataField = Encoding.ASCII.GetBytes(TB_DataField.Text);

            for (i = 0; i < DataField.Length; i++)
            {
                checksum ^= DataField[i];
            }

            return checksum;
        }

        private void RefreshCHK()
        {
            L_Checksum.Text = "* " + ComputeCHK().ToString("X2");
        }

        private void Quit()
        {
            //Update COM buttons
            B_Open.Enabled = true;
            B_Close.Enabled = false;

            //Disable groupBox
            EnableGB(false);

            if (_serialport.IsOpen == true)
            {
                //Close COM port
                _serialport.Close();
            }
        }
        #endregion

        #region EventHandlers
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int ComBytesToRead;

            if (_serialport.IsOpen == false) return;
            ComBytesToRead=_serialport.BytesToRead;

            if (AllComBytes + ComBytesToRead > serial_buffer.Length)
            {
                com_state = COM_States.Idle;
                MessageBox.Show("Overrun!");
                return;
            }

            _serialport.Read(serial_buffer, AllComBytes, ComBytesToRead);
            AllComBytes += ComBytesToRead;       

            //Packet analysis
            if(serial_buffer[0]=='$')
            {
                //If end of frame (CRLF)
                if(serial_buffer[AllComBytes-1]=='\n')
                {
                    frame = System.Text.Encoding.UTF8.GetString(serial_buffer, 0, AllComBytes);
                    frame_array = frame.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string s in frame_array)
                    {
                        //Si on attend un acknowledge...
                        if (com_state == COM_States.WaitForAck)
                        {
                            //Recherche d'un Acknowledge
                            if (s.Substring(0, 8) == "$PMTK001")
                            {
                                Ack = s.Substring(0,s.Length-3);
                                com_state = COM_States.Idle;
                            }
                        }

                        //Si on attend des données LOCUS
                        if (com_state == COM_States.WaitForLocusData)
                        {
                            //Recherche LOCUS
                            if (s.Substring(0, 8) == "$PMTKLOX")
                            {
                                LOCUS_Data.Add(s); //Add LOCUS data to the list
                            }

                            if (s.Substring(0, 10) == "$PMTKLOX,2")
                            {
                                com_state = COM_States.WaitForAck;
                            }
                        }
                    }
                    AllComBytes = 0;
                }
            }
            else
            {
                AllComBytes = 0;
            }
        }

        private void TB_DataField_TextChanged(object sender, EventArgs e)
        {
            RefreshCHK();
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            while(com_state != COM_States.Idle)
            {
                if(com_state == COM_States.WaitForAck)
                {
                    while (com_state == COM_States.WaitForAck)
                    {

                    }

                    //MessageBox.Show(Ack);
                    ToolStripStatusUpdate("ACK packet : " + Ack);
                }

                if(com_state == COM_States.WaitForLocusData)
                {
                    ToolStripStatusUpdate("Flash dump...");

                    while (com_state == COM_States.WaitForLocusData);
                    while (com_state == COM_States.WaitForAck);
                    ToolStripStatusUpdate(Ack);

                    //Save locus data to file here
                    using (StreamWriter sw = new StreamWriter(export_path))
                    {
                        foreach(string s in LOCUS_Data)
                        {
                            sw.WriteLine(s);
                        }
                    }

                    ToolStripStatusUpdate("Flash dump terminated.");
                }
            }
        }

        private void bw_ProgressChanged(object sender , ProgressChangedEventArgs e)
        {
            //Do something here
        }
        #endregion

        private void B_Dump_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            string _frame = "$PMTK622,1*29\r\n";

            sf.Filter = "TXT files| *.txt";
            sf.DefaultExt = "txt";

            if (sf.ShowDialog() == DialogResult.OK)
            {
                export_path = sf.FileName;
            }
            else
            {
                return;
            }

            com_state = COM_States.WaitForLocusData;
            _serialport.Write(_frame);
            bw.RunWorkerAsync();
        }

        private void ToolStripStatusUpdate(string s)
        {
            Invoke(new MethodInvoker(
                delegate { ToolStripLabel.Text = s; }
            ));
        }

        private void B_Erase_Click(object sender, EventArgs e)
        {
            string _frame = "$PMTK184,1*22\r\n";
            ToolStripStatusUpdate("Erasing flash memory...");
            com_state = COM_States.WaitForAck;
            _serialport.Write(_frame);
            bw.RunWorkerAsync();
        }
    }
}
