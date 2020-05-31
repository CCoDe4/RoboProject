using Android.Bluetooth;
using Java.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHMI.Common
{
    public class MobileRoboManager
    {
        public BluetoothSocket BluetoothConnection { get; set; }
        public bool IsConnected { get; set; }

        public MobileRoboManager()
        {

        }

        public void StopMotors()
        {
            try
            {
                byte[] MessageLength = { 0x0C, 0x00 };
                byte[] Command = { 0x80, 0x04, 0xFF, 0x00, 0x07, 0x00, 0x00, 0x20, 0x00, 0x00, 0x00, 0x00 }; //test

                MessageLength[0] = (byte)Command.Length; //set the LSB(least significant bit) to the length of the message 

                this.BluetoothConnection.OutputStream.Write(MessageLength, 0, MessageLength.Length); //send the 2 bytes header 
                this.BluetoothConnection.OutputStream.Write(Command, 0, Command.Length); // send the message itself
            }
            catch (Exception ex)
            {
                //test
                return;
            }
        }

        public void MoveForwards()
        {
            try
            {
                byte[] MessageLength = { 0x0C, 0x00 };
                byte[] Command = { 0x80, 0x04, 0xFF, 0xCE, 0x07, 0x00, 0x00, 0x20, 0x00, 0x00, 0x00, 0x00 }; //test

                MessageLength[0] = (byte)Command.Length; //set the LSB(least significant bit) to the length of the message 

                this.BluetoothConnection
                    .OutputStream
                    .Write(MessageLength, 0, MessageLength.Length); //send the 2 bytes header 

                this.BluetoothConnection
                    .OutputStream
                    .Write(Command, 0, Command.Length); // send the message itself

            }
            catch (Exception ex)
            {
                return;
            }

        }

        public void MoveBackwards()
        {
            try
            {
                byte[] MessageLength = { 0x0C, 0x00 };
                //byte[] Command = { 0x6d, 0x6f, 0x74, 0x6f, 0x72, 0xC0, 0x80};
                byte[] Command = { 0x80, 0x04, 0xFF, 0x32, 0x07, 0x00, 0x00, 0x20, 0x00, 0x00, 0x00, 0x00 }; //test

                MessageLength[0] = (byte)Command.Length; //set the LSB(least significant bit) to the length of the message 

                this.BluetoothConnection.OutputStream.Write(MessageLength, 0, MessageLength.Length); //send the 2 bytes header 
                this.BluetoothConnection.OutputStream.Write(Command, 0, Command.Length); // send the message itself

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

        }

        public bool Connect(BluetoothDevice device)
        {
            try
            {
                //Note that the UUID specified below is the standard UUID for SPP
                this.BluetoothConnection = device.
                    CreateRfcommSocketToServiceRecord(UUID.FromString("00001101-0000-1000-8000-00805f9b34fb"));
                this.BluetoothConnection.Connect();

                this.IsConnected = true;

                return true;
            }
            catch (Exception ex)
            {
                this.IsConnected = false;

                return false;
            }
        }

        public void RightMotor()
        {
            try
            {
                byte[] MessageLength = { 0x0C, 0x00 };
                //byte[] Command = { 0x6d, 0x6f, 0x74, 0x6f, 0x72, 0xC0, 0x80};
                byte[] Command = { 0x80, 0x04, 0x00, 0x4B, 0x07, 0x00, 0x00, 0x20, 0x00, 0x00, 0x00, 0x00 }; //test

                MessageLength[0] = (byte)Command.Length; //set the LSB(least significant bit) to the length of the message 

                this.BluetoothConnection.OutputStream.Write(MessageLength, 0, MessageLength.Length); //send the 2 bytes header 
                this.BluetoothConnection.OutputStream.Write(Command, 0, Command.Length); // send the message itself


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
        }

        public void LeftMotor()
        {
            try
            {
                byte[] MessageLength = { 0x0C, 0x00 };
                byte[] Command = { 0x80, 0x04, 0x01, 0x4B, 0x07, 0x00, 0x00, 0x20, 0x00, 0x00, 0x00, 0x00 }; //test


                MessageLength[0] = (byte)Command.Length; //set the LSB(least significant bit) to the length of the message 

                this.BluetoothConnection.OutputStream.Write(MessageLength, 0, MessageLength.Length); //send the 2 bytes header 
                this.BluetoothConnection.OutputStream.Write(Command, 0, Command.Length); // send the message itself

            }
            catch (Exception ex)
            {

                return;
            }
        }

        public void Beep()
        {
            try
            {
                //  byte[] MessageLength = { 0x00, 0x00 };
                byte[] MessageLength = { 0x06, 0x00 };
                //  byte[] Command = { 0x01, 0x88 }; //get nxt version command  ----> response: 02 88 00 7C 01 1C 01 
                byte[] Command = { 0x80, 0x03, 0x0B, 0x02, 0xF4, 0x01 }; //beep

                MessageLength[0] = (byte)Command.Length; //set the LSB(least significant bit) to the length of the message 

                this.BluetoothConnection.OutputStream.Write(MessageLength, 0, MessageLength.Length); //send the 2 bytes header 
                this.BluetoothConnection.OutputStream.Write(Command, 0, Command.Length); // send the message itself


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
        }

    }
}
