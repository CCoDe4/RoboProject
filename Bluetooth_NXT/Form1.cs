using Lego.Mindstorms;
using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace Bluetooth_NXT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

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
                int length =
                    BluetoothConnection.ReadByte() + 256 * BluetoothConnection.ReadByte();

                // retrieve the reply data 
                for (int i = 0; i < length; i++)
                {
                    responseBox.Text += BluetoothConnection.ReadByte().ToString("X2") + " ";
                }

                BluetoothConnection.Close();
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string portName = "COM3";

            using (BluetoothCommunication bluetoothCommunication = new BluetoothCommunication(portName))
            {
                bluetoothCommunication.ConnectAsync();

                Command command = new Command();
                command.TurnMotorAtSpeed(OutputPort.A, 50);
                command.TurnMotorAtSpeed(OutputPort.B, 50);

            }

        }

        //NXT Program file extensions: *RBT*, RIC, RPG, *RXE*
        //Null terminator 0x00
        private void btnRightMotor_Click(object sender, EventArgs e)
        {
            byte[] MessageLength = { 0x0C, 0x00 };
            //byte[] Command = { 0x6d, 0x6f, 0x74, 0x6f, 0x72, 0xC0, 0x80};
            byte[] Command = { 0x80, 0x04, 0x02, 0x64, 0x07, 0x00, 0x00, 0x20, 0x00, 0x00, 0x00, 0x00 }; //test
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
            byte[] Command = { 0x80, 0x04, 0x01, 0x64, 0x07, 0x00, 0x00, 0x20, 0x00, 0x00, 0x00, 0x00 }; //test

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

        private void btnStop_Click(object sender, EventArgs e)
        {
            //Send async commands to both motors
        }
    }
}
