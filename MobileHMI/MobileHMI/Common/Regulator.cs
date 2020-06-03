using Android.Bluetooth;
using MobileHMI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace MobileHMI.Common
{
    public class Regulator
    {
        private int currentDistance;
        private const double wheelCircumference = 17.59291886010284; //cm

        public Regulator()
        {            
           
        }

        public BluetoothSocket BluetoothConnection { get; set; }

        public bool IsConnected { get; set; }

        public int TargetDistance { get; set; }

        public int Kp { get; set; } = 1;
        public int Ki { get; set; } = 0;
        public int Kd { get; set; } = 0;

        public Timer Timer { get; set; } //100ms

        public void Run()
        {
            RunTimer();
        }
      
        private string GetState()
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

        private void RunTimer()
        {
            this.Timer = new Timer();
            Timer.Interval = 100; //ms
            this.Timer.Elapsed += OnTimedEvent;

            this.Timer.Start();
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            var response = GetState().ToList();
            byte[] responseBytes = new byte[4];

            //2 motors

            for (int i = 0; i < responseBytes.Length; i++)
            {
                responseBytes[i] = byte.Parse(response[21 + i].ToString(), System.Globalization.NumberStyles.HexNumber);
                
            }

            var encoderImpulses = BitConverter.ToInt32(responseBytes, 0);

        }

    }
}
