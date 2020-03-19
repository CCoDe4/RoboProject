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
                roboManager.Beep(bluetooth);
            });
        }

        //NXT Program file extensions: *RBT*, RIC, RPG, *RXE*
        //Null terminator 0x00
        private async void btnRightMotor_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                roboManager.LeftMotor(bluetooth); //In order to turn right, left motor is activated.
            });

        }

        private async void btnLeftMotor_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                roboManager.RightMotor(bluetooth); //In order to turn left, right motor is activated.
            });
        }

        private async void btnStop_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                roboManager.StopMotors(bluetooth);
            });
        }

        private async void btnUp_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                roboManager.MoveForwards(bluetooth);
            });
        }

        private async void btnDown_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                roboManager.MoveBackwards(bluetooth);
            });
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            bluetooth = roboManager.Connect(bluetooth, portName.Text);

            if (bluetooth.IsOpen)
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
            if (!bluetooth.IsOpen) return;

            roboManager.StopMotors(bluetooth);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
         {
            if (!bluetooth.IsOpen) return; 

            switch (e.KeyData)
            {
                case Keys.Up:
                    roboManager.MoveForwards(bluetooth);
                    break;
                case Keys.Down:
                    roboManager.MoveBackwards(bluetooth);
                    break;
                case Keys.Left:
                    roboManager.RightMotor(bluetooth);
                    break;
                case Keys.Right:
                    roboManager.LeftMotor(bluetooth);
                    break;
                case Keys.Space:
                    roboManager.StopMotors(bluetooth);
                    break;
                case Keys.Back:
                    roboManager.Beep(bluetooth);
                    break;
            }
        }
    }
}
