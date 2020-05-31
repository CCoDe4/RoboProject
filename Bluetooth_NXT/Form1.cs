using Bluetooth_NXT.Common;
using System;
using System.Drawing;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bluetooth_NXT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            portName.Text = "COM3";

            RoboManager = new RoboManager();
            RoboManager.BluetoothConnection = new SerialPort();
            this.ActiveControl = null;

        }

        public RoboManager RoboManager { get; set; }
        /// <summary>
        /// makes the NXT beep
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnPing_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                RoboManager.Beep();
            });
        }

        //NXT Program file extensions: *RBT*, RIC, RPG, *RXE*
        //Null terminator 0x00
        private async void btnRightMotor_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                RoboManager.LeftMotor(); //In order to turn right, left motor is activated.
            });

        }

        private async void btnLeftMotor_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                RoboManager.RightMotor(); //In order to turn left, right motor is activated.
            });
        }

        private async void btnStop_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                RoboManager.StopMotors();
            });
        }

        private async void btnUp_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                RoboManager.MoveForwards();
            });
        }

        private async void btnDown_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                RoboManager.MoveBackwards();
            });
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            bool isConnected = RoboManager.Connect(portName.Text);

            if (isConnected)
            {
                lblConnectionStatus.Text = "Connected";
                lblConnectionStatus.ForeColor = Color.Green;
            }
            else
            {
                lblConnectionStatus.Text = "Disconnected";
                lblConnectionStatus.ForeColor = Color.Red;

                MessageBox.Show("Check if robot is ON or the bluetooth device" , "ERROR");
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (!RoboManager.BluetoothConnection.IsOpen) return;

            RoboManager.StopMotors();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!RoboManager.BluetoothConnection.IsOpen) return;

            switch (e.KeyData)
            {
                case Keys.Up:
                    RoboManager.MoveForwards();
                    break;
                case Keys.Down:
                    RoboManager.MoveBackwards();
                    break;
                case Keys.Left:
                    RoboManager.RightMotor();
                    break;
                case Keys.Right:
                    RoboManager.LeftMotor();
                    break;
                case Keys.Space:
                    RoboManager.StopMotors();
                    break;
                case Keys.Back:
                    RoboManager.Beep();
                    break;
            }
        }
    }
}
