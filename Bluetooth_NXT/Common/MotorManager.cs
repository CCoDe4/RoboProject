using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluetooth_NXT.Common
{
    public class MotorManager
    { 
        public async Task<int> StopLeftMotor()
        {
            try
            {
                byte[] MessageLength = { 0x0C, 0x00 };
                byte[] Command = { 0x80, 0x04, 0x01, 0x00, 0x07, 0x00, 0x00, 0x20, 0x00, 0x00, 0x00, 0x00 }; //test

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
            catch (Exception)
            {
                return 0;
            }            

            return 1;
        }

        public async Task<int> StopRightMotor()
        {
            try
            {
                byte[] MessageLength = { 0x0C, 0x00 };
                byte[] Command = { 0x80, 0x04, 0x02, 0x00, 0x07, 0x00, 0x00, 0x20, 0x00, 0x00, 0x00, 0x00 }; //test

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
            catch (Exception)
            {
                return 0; 
            }

            return 1;
        }
    }
}
