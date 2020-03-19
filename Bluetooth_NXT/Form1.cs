using Bluetooth_NXT.Common;
using System;
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
            motorManager = new MotorManager();

            PrepareBluetoothConnection();
        }

        private void PrepareBluetoothConnection()
        {
            bluetooth = new SerialPort();
            bluetooth.PortName = "COM3";

            bluetooth.Open();
            bluetooth.ReadTimeout = 1500;

        }

        public MotorManager motorManager { get; set; }
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
               
                    try
                    {
                        //  byte[] MessageLength = { 0x00, 0x00 };
                        byte[] MessageLength = { 0x06, 0x00 };
                        //  byte[] Command = { 0x01, 0x88 }; //get nxt version command  ----> response: 02 88 00 7C 01 1C 01 
                        byte[] Command = { 0x80, 0x03, 0x0B, 0x02, 0xF4, 0x01 }; //beep

                        MessageLength[0] = (byte)Command.Length; //set the LSB(least significant bit) to the length of the message 

                        bluetooth.Write(MessageLength, 0, MessageLength.Length); //send the 2 bytes header 
                        bluetooth.Write(Command, 0, Command.Length); // send the message itself


                        // retrieve the reply length 
                        //int length =
                        //    BluetoothConnection.ReadByte() + 256 * BluetoothConnection.ReadByte();

                        //// retrieve the reply data 
                        //for (int i = 0; i < length; i++)
                        //{
                        //    responseBox.Text += BluetoothConnection.ReadByte().ToString("X2") + " ";
                        //}

                    }
                    catch (Exception ex)
                    {

                        return;
                    }

            });

        }

        //NXT Program file extensions: *RBT*, RIC, RPG, *RXE*
        //Null terminator 0x00
        private async void btnRightMotor_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                try
                {
                    byte[] MessageLength = { 0x0C, 0x00 };
                    //byte[] Command = { 0x6d, 0x6f, 0x74, 0x6f, 0x72, 0xC0, 0x80};
                    byte[] Command = { 0x80, 0x04, 0x00, 0x32, 0x07, 0x00, 0x00, 0x20, 0x00, 0x00, 0x00, 0x00 }; //test

                    MessageLength[0] = (byte)Command.Length; //set the LSB(least significant bit) to the length of the message 

                    bluetooth.Write(MessageLength, 0, MessageLength.Length); //send the 2 bytes header 
                    bluetooth.Write(Command, 0, Command.Length); // send the message itself


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

                }
                catch (Exception ex)
                {
                    return;
                }
            });

        }

        private async void btnLeftMotor_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {

                try
                {
                    byte[] MessageLength = { 0x0C, 0x00 };
                    byte[] Command = { 0x80, 0x04, 0x01, 0x32, 0x07, 0x00, 0x00, 0x20, 0x00, 0x00, 0x00, 0x00 }; //test


                    MessageLength[0] = (byte)Command.Length; //set the LSB(least significant bit) to the length of the message 

                    bluetooth.Write(MessageLength, 0, MessageLength.Length); //send the 2 bytes header 
                    bluetooth.Write(Command, 0, Command.Length); // send the message itself

                }
                catch (Exception ex)
                {

                    return;
                }

            });
        }

        private async void btnStop_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                try
                {
                    byte[] MessageLength = { 0x0C, 0x00 };
                    byte[] Command = { 0x80, 0x04, 0xFF, 0x00, 0x07, 0x00, 0x00, 0x20, 0x00, 0x00, 0x00, 0x00 }; //test

                    MessageLength[0] = (byte)Command.Length; //set the LSB(least significant bit) to the length of the message 

                    bluetooth.Write(MessageLength, 0, MessageLength.Length); //send the 2 bytes header 
                    bluetooth.Write(Command, 0, Command.Length); // send the message itself

                }
                catch (Exception ex)
                {

                    return;
                }
            });

        }

        private async void btnUp_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {

                try
                {
                    byte[] MessageLength = { 0x0C, 0x00 };
                    //byte[] Command = { 0x6d, 0x6f, 0x74, 0x6f, 0x72, 0xC0, 0x80};
                    byte[] Command = { 0x80, 0x04, 0xFF, 0x32, 0x07, 0x00, 0x00, 0x20, 0x00, 0x00, 0x00, 0x00 }; //test


                    MessageLength[0] = (byte)Command.Length; //set the LSB(least significant bit) to the length of the message 

                    bluetooth.Write(MessageLength, 0, MessageLength.Length); //send the 2 bytes header 
                    bluetooth.Write(Command, 0, Command.Length); // send the message itself


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

                }
                catch (Exception ex)
                {
                    return;
                }

            });
        }

        private async void btnDown_Click(object sender, EventArgs e)
        {

            await Task.Run(() =>
            {

              
                    try
                    {
                        byte[] MessageLength = { 0x0C, 0x00 };
                        //byte[] Command = { 0x6d, 0x6f, 0x74, 0x6f, 0x72, 0xC0, 0x80};
                        byte[] Command = { 0x80, 0x04, 0xFF, 0xCE, 0x07, 0x00, 0x00, 0x20, 0x00, 0x00, 0x00, 0x00 }; //test

                        MessageLength[0] = (byte)Command.Length; //set the LSB(least significant bit) to the length of the message 

                        bluetooth.Write(MessageLength, 0, MessageLength.Length); //send the 2 bytes header 
                        bluetooth.Write(Command, 0, Command.Length); // send the message itself

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

                    }
                    catch (Exception ex)
                    {
                        return;
                    }

            });

        }


    }
}
