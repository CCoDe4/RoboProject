using Android.Bluetooth;
using MobileHMI.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHMI.Common
{
    public class Regulator
    {
        public BluetoothSocket BluetoothConnection { get; set; }
        public bool IsConnected { get; set; }

        public int TargetDistance { get; set; }

        public string GetState()
        {
            try
            {
                byte[] MessageLength = { 0x0C, 0x00 };
                byte[] Command = { 0x00, 0x06, 0x00 }; //test

                MessageLength[0] = (byte)Command.Length; //set the LSB(least significant bit) to the length of the message 

                this.BluetoothConnection
                    .OutputStream
                    .Write(MessageLength, 0, MessageLength.Length); //send the 2 bytes header 

                this.BluetoothConnection
                    .OutputStream
                    .Write(Command, 0, Command.Length); // send the message itself

                // retrieve the reply length 
                if (Command[0] == 0x00)
                {
                    int length =
                        BluetoothConnection.InputStream.ReadByte() + 256 * BluetoothConnection.InputStream.ReadByte();

                    string response = string.Empty;

                    //retrieve the reply data
                    for (int i = 0; i < length; i++)
                    {
                        response += BluetoothConnection.InputStream.ReadByte().ToString("X2") + " ";
                    }

                    if (!string.IsNullOrEmpty(response))                    
                        return response;                    
                    else
                        return Constants.error;
                }

                return Constants.error;

            }
            catch (Exception ex)
            {
                return "error";
            }
        }
    }
}
