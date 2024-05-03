using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using Wit.SDK.Modular.Sensor.Modular.DataProcessor.Constant;
using Wit.SDK.Modular.WitSensorApi.Modular.JY901;
using System.Net;
using System.Net.Sockets;
using System.Drawing;
using Wit.SDK.Device.Sensor.Device.Utils;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;

namespace Motion_Sim
{
    public struct MmfData
    {
        public double sway, surge, heave, yaw, roll, pitch;
    }

    public partial class Form1 : Form
    {
        public JY901 JY901 { get; set; } = new JY901();
        private List<int> SupportBaudRateList { get; set; } = new List<int>() { 2400, 4800, 9600, 19200, 38400, 57600, 115200, 230400 };
        private bool calibrated = false;
        public int cal_count = 50;
        public double Total_X = 0;
        public double Total_Y = 0;
        public double Total_Z = 0;


        public bool EnableRefreshDataTh { get; private set; }
        public Form1()
        {
            InitializeComponent();
            combo_load_ports();
            combo_load_bauds();
            baudComboBox.SelectedItem = 115200;
            toolStripStatusLabel2.Text = "";
            cal_count = (int)CalAmount.Value;
            Recalibate.Enabled = false;
            //CNT_Button.Enabled = false;
            CMB_RELOAD.Font= new Font("Wingdings 3", 10, FontStyle.Bold);
            CMB_RELOAD.Text = Char.ConvertFromUtf32(81); // or 80
            this.KeyPreview = true; // Enables form-level key events
            this.KeyDown += Form1_KeyDown; // Event handler for key down events
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the tooltip
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;

            // Force the tooltip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the tooltip text for the button
            toolTip1.SetToolTip(CNT_Button, "This connects to the sensor and starts sending data over the UDP Port. Shortcut is CTRL+ALT+F12");
            ToolTip toolTip2 = new ToolTip();

            // Set up the delays for the tooltip
            toolTip2.AutoPopDelay = 5000;
            toolTip2.InitialDelay = 1000;
            toolTip2.ReshowDelay = 500;

            // Force the tooltip text to be displayed whether or not the form is active.
            toolTip2.ShowAlways = true;

            // Set up the tooltip text for the button
            toolTip2.SetToolTip(Recalibate, "This button recalibrates the sensor. Shortcut : CTRL+ALT+F11");
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Alt && e.KeyCode == Keys.F12)
            {
                // Check if the button is enabled and visible
                if (CNT_Button.Enabled && CNT_Button.Visible)
                {
                    CNT_Button.PerformClick(); // Simulate button click
                }
            }
            if (e.Control && e.Alt && e.KeyCode == Keys.F11)
            {
                // Check if the button is enabled and visible
                if (Recalibate.Enabled && Recalibate.Visible)
                {
                    Recalibate.PerformClick(); // Simulate button click
                }
            }
        }
        private void SendDataOverUDP(byte[] data)
        {
            try
            {
                IPAddress remoteIPAddress = IPAddress.Parse(txtIP.Text); // Example IP address
                int remotePort = (int)UDPPort.Value; // Port 20789
                using (UdpClient client = new UdpClient())
                {
                    IPEndPoint remoteEndPoint = new IPEndPoint(remoteIPAddress, remotePort);
                    client.Send(data, data.Length, remoteEndPoint);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while sending data over UDP: " + ex.Message);
            }
        }
        private void combo_load_ports()
        {
            CMB_Serial.Items.Clear();
            foreach ( var i in System.IO.Ports.SerialPort.GetPortNames()) 
            {
                CMB_Serial.Items.Add( i );   
            }
        }
        private void combo_load_bauds()
        {
            for (int i = 0; i < SupportBaudRateList.Count; i++)
            {
                baudComboBox.Items.Add(SupportBaudRateList[i]);
            }
        }

        private void CNT_Button_Click(object sender, EventArgs e)
        {
            if (CNT_Button.Text == "Disconnect")
            {
                if (JY901.IsOpen())
                {
                   try 
                    { 
                        JY901.Close();
                        CNT_Button.Text = "Connect and broadcast";
                        CNT_Button.BackColor = default;
                        Recalibate.Enabled = false;
                    } 
                    catch (Exception ex)  
                    { 
                       MessageBox.Show(ex.Message);  
                    }
                }

            }
            else
            {
                string portName;
                int baudrate;
                try
                {
                    portName = (string)CMB_Serial.SelectedItem;
                    baudrate = (int)baudComboBox.SelectedItem;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                if (JY901.IsOpen())
                {
                    return;
                }
                try
                {
                    JY901.SetPortName(portName);
                    JY901.SetBaudrate(baudrate);
                    JY901.Open();
                    if (JY901.IsOpen() == false)
                    {
                        return;
                    }
                    try
                    {
                        JY901.UnlockReg();
                        JY901.SetReturnRate(0x0B);
                        JY901.SetBandWidth(0x00);
                        Thread thread = new Thread(RefreshDataTh);
                        thread.IsBackground = true;
                        EnableRefreshDataTh = true;
                        thread.Start();
                        CNT_Button.BackColor = Color.Yellow;
                        calibrated = false;
                        cal_count = (int)CalAmount.Value;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }
        private void RefreshDataTh()
        {
            while (EnableRefreshDataTh)
            {
                if (cal_count >= 1 && calibrated == false)
                {
                    try
                    {
                        Total_X += (double)JY901.GetDeviceData(WitSensorKey.AngleX);
                        Total_Y += (double)JY901.GetDeviceData(WitSensorKey.AngleY);
                        Total_Z += (double)JY901.GetDeviceData(WitSensorKey.AngleZ);
                        toolStripStatusLabel1.Text = cal_count + " Calibrating";
                    }
                    catch ( Exception ex) 
                    {
                        Console.WriteLine(" Exception during calibration" + ex.Message);
                        cal_count++;
                        toolStripStatusLabel1.Text = "Initializing";
                        System.Threading.Thread.Sleep(50);
                    }
                    cal_count--;
                }
                else if (cal_count == 0 && calibrated == false)
                {
                    Total_X = Total_X / (int)CalAmount.Value;
                    Total_Y = Total_Y / (int)CalAmount.Value;
                    Total_Z = Total_Z / (int)CalAmount.Value;
                    calibrated = true;
                    //toolStripStatusLabel1.Text = "Calibrated X : " + Total_X.ToString("F2") + " Y:" + Total_Y.ToString("F2") + " Z:" + Total_Z.ToString("F2");
                    toolStripStatusLabel1.Text = "Calibrated ";
                    CNT_Button.BackColor = Color.LightGreen;
                    CNT_Button.Invoke((MethodInvoker)delegate {
                        CNT_Button.Text = "Disconnect";
                    });
                    Recalibate.Invoke((MethodInvoker)delegate {
                         Recalibate.Enabled = true;
                    });
                   
                }
                else
                {
                    (Int32 currentX, Int32 currentY, Int32 currentZ) = GetDeviceDataCST(JY901);
                    if (CHK_SWP_X.Checked) { currentX = -currentX; }
                    if (CHK_SWP_Y.Checked) { currentY = -currentY; }
                    if (!CHK_YAW.Checked) { currentZ = 0; }
                    if (CHK_SWP.Checked) { currentZ = -currentZ; }
                /*    {
                        Int32 temp = currentX;
                        currentX = currentY;
                        currentY = temp;
                    }*/
                    MmfData data = new MmfData
                    {
                        sway = 0.0,     // Assign some value to sway
                        surge = 0.0,    // Assign some value to surge
                        heave = 0.0,    // Assign some value to heave
                        yaw = (double)currentZ / 100,      // Assign some value to yaw
                        roll = (double)currentY/100,     // Assign some value to roll
                        pitch = (double)currentX/100    // Assign some value to pitch
                    };
                    if (CHK_MMF.Checked) { WriteToFile(data); }
                    if (CHK_UDP.Checked) { 
                        byte[] currentXBytes = BitConverter.GetBytes(currentX);
                        byte[] currentYBytes = BitConverter.GetBytes(currentY);
                        byte[] currentZBytes = BitConverter.GetBytes(currentZ);
                        try
                        {
                            byte[] combinedBytes = new byte[currentXBytes.Length + currentYBytes.Length + currentZBytes.Length];
                            Buffer.BlockCopy(currentXBytes, 0, combinedBytes, 0, currentXBytes.Length);
                            Buffer.BlockCopy(currentYBytes, 0, combinedBytes, currentXBytes.Length, currentYBytes.Length);
                            Buffer.BlockCopy(currentZBytes, 0, combinedBytes, currentXBytes.Length + currentYBytes.Length, currentZBytes.Length);
                            SendDataOverUDP(combinedBytes);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("An error occurred while sending over UDP: " + ex.Message);
                        }
                    }
                    toolStripStatusLabel2.Text = "CX=" + ((double)currentX / 100).ToString() + " CY= " + ((double)currentY / 100).ToString() ;
                    if (CHK_YAW.Checked) { toolStripStatusLabel2.Text = toolStripStatusLabel2.Text + " CZ= " + ((double)currentZ / 100).ToString();  }
                }
                Thread.Sleep((int)NUP_refresh.Value);
            }
        }
        public static bool WriteToFile(MmfData data)
        {
            string fileName = "Local\\motionRigPose"; // Use the same file name as in the software
            int size = Marshal.SizeOf<MmfData>(); // Get the size of the data structure

            try
            {
                MemoryMappedFile file;

                try
                {
                    // Attempt to open the file. If it doesn't exist, this will throw a FileNotFoundException
                    file = MemoryMappedFile.OpenExisting(fileName, MemoryMappedFileRights.ReadWrite);
                }
                catch (FileNotFoundException)
                {
                    // If the file doesn't exist, create a new one
                    file = MemoryMappedFile.CreateNew(fileName, size);
                }

                using (MemoryMappedViewAccessor accessor = file.CreateViewAccessor(0, size))
                {
                    accessor.Write(0, ref data); // Write the data to the memory-mapped file
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing to memory-mapped file: " + ex.Message);
                return false;
            }
        }

//THIS FUNCTION CAN BE REWRITTEN AND REMOVE *100

        private (Int32,Int32,Int32) GetDeviceDataCST(JY901 JY901)
        {
            Int32 current_X =(Int32)(Math.Round((double)(JY901.GetDeviceData(WitSensorKey.AngleX)) - Total_X, 2)*100);
            Int32 current_Y =(Int32)(Math.Round((double)(JY901.GetDeviceData(WitSensorKey.AngleY)) - Total_Y,2)*100);
            Int32 current_Z = (Int32)(Math.Round((double)(JY901.GetDeviceData(WitSensorKey.AngleZ)) - Total_Z, 2) * 100);
            Int32 deadzoneValue = 0;
            deadzone.Invoke(new Action(() =>
            {
                deadzoneValue = deadzone.Value*100;
            }));
            if (Math.Abs(current_X) < (deadzoneValue / 20) )
            {
                current_X = 0;
            }
            if (Math.Abs(current_Y) < (deadzoneValue / 20))
            {
                current_Y = 0;
            }
            if (Math.Abs(current_Z) < (deadzoneValue / 20))
            {
                current_Z = 0;
            }
            return (current_X, current_Y,current_Z);
        }

        private void deadzone_Scroll(object sender, EventArgs e)
        {
            float deadzone_value = ((float)deadzone.Value / 20);
            txtDeadZone.Text = deadzone_value.ToString();
        }

        private void Recalibate_Click(object sender, EventArgs e)
        {
            calibrated = false;
            int value = (int)CalAmount.Value;
            cal_count = value;
            Total_X = 0;
            Total_Y = 0;
            Total_Z = 0;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Witmotion to UDP software. Only read Pitch and roll. Open source license GPL 3.0. Feel free to modify. Original dev: steve@blakstraat11.be");
                }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (JY901.IsOpen())
            {
                try
                {
                    JY901.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            Application.Exit();
        }

        private void CMB_RELOAD_Click_1(object sender, EventArgs e)
        {
            combo_load_ports();
        }

        private void CHK_UDP_CheckedChanged(object sender, EventArgs e)
        {
            if (!CHK_UDP.Checked)
            {
                UDPPort.Enabled = false;
                txtIP.Enabled = false;
            }
            else { 
                UDPPort.Enabled = true;
                txtIP.Enabled = true;
            }
        }

        private void CMD_Serial_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
