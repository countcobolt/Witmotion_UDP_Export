﻿using System;
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

namespace Motion_Sim
{
    public partial class Form1 : Form
    {
        public JY901 JY901 { get; set; } = new JY901();
        private List<int> SupportBaudRateList { get; set; } = new List<int>() { 2400, 4800, 9600, 19200, 38400, 57600, 115200, 230400 };
        private bool calibrated = false;
        public int cal_count = 50;
        public double Total_X = 0;
        public double Total_Y = 0;

        public bool EnableRefreshDataTh { get; private set; }
        public Form1()
        {
            InitializeComponent();
            combo_load();
            baudComboBox.SelectedItem = 9600;
            toolStripStatusLabel2.Text = "";
            cal_count = (int)CalAmount.Value;
            Recalibate.Enabled = false;
            CNT_Button.Enabled = false;
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
                IPAddress remoteIPAddress = IPAddress.Parse("127.0.0.1"); // Example IP address
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
        private void combo_load()
        {
            foreach ( var i in SerialPort.GetPortNames()) 
            { 
                comboBox1.Items.Add( i );   
            }
            for (int i = 0; i < SupportBaudRateList.Count; i++)
            {
                baudComboBox.Items.Add(SupportBaudRateList[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
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
                    portName = (string)comboBox1.SelectedItem;
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
                if (cal_count > 0 && calibrated == false)
                {
                    try
                    {
                        cal_count--;
                        toolStripStatusLabel1.Text = cal_count + " Calibrating";
                        Total_X = Total_X + (double)JY901.GetDeviceData(WitSensorKey.AngleX);
                        Total_Y = Total_Y + (double)JY901.GetDeviceData(WitSensorKey.AngleY);
                    }
                    catch ( Exception ex) 
                    {
                        //  MessageBox.Show(ex.Message);
                        cal_count++;
                        System.Threading.Thread.Sleep(50);
                    }
                    
                }
                else if (cal_count == 0 && calibrated == false)
                {
                    Total_X = Total_X / (int)CalAmount.Value;
                    Total_Y = Total_Y / (int)CalAmount.Value;
                    calibrated = true;
                    toolStripStatusLabel1.Text = "Calibrated X : " + Total_X.ToString("F2") + " Y:" + Total_Y.ToString("F2");
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
                    if (JY901.IsOpen())
                    {
                        (Int32 currentX, Int32 currentY) = GetDeviceData(JY901);
                        toolStripStatusLabel2.Text = "CX=" + ((double)currentX / 100).ToString() + " CY= " + ((double)currentY / 100).ToString();
                        byte[] currentXBytes = BitConverter.GetBytes(currentX);
                        byte[] currentYBytes = BitConverter.GetBytes(currentY);
                        try
                        {
                            byte[] combinedBytes = new byte[currentXBytes.Length + currentYBytes.Length];
                            Buffer.BlockCopy(currentXBytes, 0, combinedBytes, 0, currentXBytes.Length);
                            Buffer.BlockCopy(currentYBytes, 0, combinedBytes, currentXBytes.Length, currentYBytes.Length);
                            SendDataOverUDP(combinedBytes);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("An error occurred: " + ex.Message);
                        }
                    }
                }
                Thread.Sleep((int)NUP_refresh.Value);
            }
        }
        private (Int32,Int32) GetDeviceData(JY901 JY901)
        {
            Int32 current_X =(Int32)(Math.Round((double)(JY901.GetDeviceData(WitSensorKey.AngleX)) - Total_X, 2)*100);
            Int32 current_Y =(Int32)(Math.Round((double)(JY901.GetDeviceData(WitSensorKey.AngleY)) - Total_Y,2)*100);
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
            return (current_X, current_Y);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0 )
            { CNT_Button.Enabled = true;  }     
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
