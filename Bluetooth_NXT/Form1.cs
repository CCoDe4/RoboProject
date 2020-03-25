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

            roboManager = new RoboManager();
            bluetooth = new SerialPort();
            this.ActiveControl = null;
            
        }

        public RoboManager roboManager { get; set; }
        private SerialPort bluetooth { get; set; }

        /// <summary>
        /// makes the NXT beep
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnPing_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                roboManager.Beep();
            });
        }

        //NXT Program file extensions: *RBT*, RIC, RPG, *RXE*
        //Null terminator 0x00
        private async void btnRightMotor_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                roboManager.LeftMotor(); //In order to turn right, left motor is activated.
            });

        }

        private async void btnLeftMotor_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                roboManager.RightMotor(); //In order to turn left, right motor is activated.
            });
        }

        private async void btnStop_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                roboManager.StopMotors();
            });
        }

        private async void btnUp_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                roboManager.MoveForwards();
            });
        }

        private async void btnDown_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                roboManager.MoveBackwards();
            });
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            bool isConnected = roboManager.Connect(portName.Text);

            if (isConnected)
            {
                lblConnectionStatus.Text = "Connected";
                lblConnectionStatus.ForeColor = Color.Green;
            }
            else
            {
                lblConnectionStatus.Text = "Disconnected";
                lblConnectionStatus.ForeColor = Color.Red;

                MessageBox.Show("Check if robot is ON or the bluetooth device", "ERROR");
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (!roboManager.BluetoothConnection.IsOpen) return;

            roboManager.StopMotors();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
         {
            if (!roboManager.BluetoothConnection.IsOpen) return; 

            switch (e.KeyData)
            {
                case Keys.Up:
                    roboManager.MoveForwards();
                    break;
                case Keys.Down:
                    roboManager.MoveBackwards();
                    break;
                case Keys.Left:
                    roboManager.RightMotor();
                    break;
                case Keys.Right:
                    roboManager.LeftMotor();
                    break;
                case Keys.Space:
                    roboManager.StopMotors();
                    break;
                case Keys.Back:
                    roboManager.Beep();
                    break;
            }
        }
    }
}
