using Bluetooth_NXT.Common;
using System;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bluetooth_NXT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            motorManager = new MotorManager();
        }

        public MotorManager motorManager { get; set; }

        /// <summary>
        /// makes the NXT beep
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPing_Click(object sender, EventArgs e) 
        {
            //  byte[] MessageLength = { 0x00, 0x00 };
            byte[] MessageLength = { 0x06, 0x00 };
            //  byte[] Command = { 0x01, 0x88 }; //get nxt version command  ----> response: 02 88 00 7C 01 1C 01 
            byte[] Command = { 0x80, 0x03, 0x0B, 0x02, 0xF4, 0x01 }; //beep
            //byte[] Command = { 0x01, 0x9B }; //get nxt version command ----> response: 02 9B 00 4E 58 54 00 00 00 00 00 00 00 00 00 00 00 00 00 16 53 0B 73 88 00 00 00 00 00 2C 55 01 00             

            using (SerialPort BluetoothConnection = new SerialPort())
            {
                BluetoothConnection.PortName = "COM3";
                BluetoothConnection.Open();
                BluetoothConnection.ReadTimeout = 1500;

                MessageLength[0] = (byte)Command.Length; //set the LSB(least significant bit) to the length of the message 

                BluetoothConnection.Write(MessageLength, 0, MessageLength.Length); //send the 2 bytes header 
                BluetoothConnection.Write(Command, 0, Command.Length); // send the message itself


                // retrieve the reply length 
                //int length =
                //    BluetoothConnection.ReadByte() + 256 * BluetoothConnection.ReadByte();

                //// retrieve the reply data 
                //for (int i = 0; i < length; i++)
                //{
                //    responseBox.Text += BluetoothConnection.ReadByte().ToString("X2") + " ";
                //}

                BluetoothConnection.Close();
            }
        }

        //NXT Program file extensions: *RBT*, RIC, RPG, *RXE*
        //Null terminator 0x00
        private void btnRightMotor_Click(object sender, EventArgs e)
        {
            byte[] MessageLength = { 0x0C, 0x00 };
            //byte[] Command = { 0x6d, 0x6f, 0x74, 0x6f, 0x72, 0xC0, 0x80};
            byte[] Command = { 0x80, 0x04, 0x02, 0x32, 0x07, 0x00, 0x00, 0x20, 0x00, 0x00, 0x00, 0x00 }; //test
            //6d6f746f72    727865

            using (SerialPort BluetoothConnection = new SerialPort())
            {
                BluetoothConnection.PortName = "COM3";
                BluetoothConnection.Open();
                BluetoothConnection.ReadTimeout = 5000;

                MessageLength[0] = (byte)Command.Length; //set the LSB(least significant bit) to the length of the message 

                BluetoothConnection.Write(MessageLength, 0, MessageLength.Length); //send the 2 bytes header 
                BluetoothConnection.Write(Command, 0, Command.Length); // send the message itself


                // retrieve the reply length 
                //if (Command[0] == 0x80)
                //{
                //    int length =
                //   BluetoothConnection.ReadByte() + 256 * BluetoothConnection.ReadByte();

                //    retrieve the reply data
                //    for (int i = 0; i < length; i++)
                //    {
                //        responseBox.Text += BluetoothConnection.ReadByte().ToString("X2") + " ";
                //    }
                //}

                BluetoothConnection.Close();
            }
        }

        private void btnLeftMotor_Click(object sender, EventArgs e)
        {
            byte[] MessageLength = { 0x0C, 0x00 };
            byte[] Command = { 0x80, 0x04, 0x01, 0x32, 0x07, 0x00, 0x00, 0x20, 0x00, 0x00, 0x00, 0x00 }; //test

            using (SerialPort BluetoothConnection = new SerialPort())
            {
                BluetoothConnection.PortName = "COM3";
                BluetoothConnection.Open();
                BluetoothConnection.ReadTimeout = 5000;

                MessageLength[0] = (byte)Command.Length; //set the LSB(least significant bit) to the length of the message 

                BluetoothConnection.Write(MessageLength, 0, MessageLength.Length); //send the 2 bytes header 
                BluetoothConnection.Write(Command, 0, Command.Length); // send the message itself

                BluetoothConnection.Close();
            }
        }

        private async void btnStop_Click(object sender, EventArgs e)
        {
            //Send async commands to both motors
            Task<int> t1 = motorManager.StopRightMotor();
            Task<int> t2 = motorManager.StopLeftMotor();

            await Task.WhenAll(t1, t2);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {

        }

        private void btnDown_Click(object sender, EventArgs e)
        {

        }

     
    }
}
