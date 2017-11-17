using System;
using System.IO.Ports;
using System.Text;
using System.Windows.Media;

using De.BerndNet2000.PersonalStatusMonitor.Domain;

using ReactiveUI;

namespace De.BerndNet2000.PersonalStatusMonitor.Service {
    public class StripeConnector : ReactiveObject {
        private SerialPort _com;
        private int _lastReceived;

        public int LastReceived {
            get { return _lastReceived; }
        }

        public void Connect(string comPort) {
            _com = new SerialPort(comPort, 9600, Parity.None, 8, StopBits.One);
            _com.Encoding = new UTF8Encoding();
            _com.DataReceived += ComDataReceived;
            _com.Open();
        }

        public void SendColor(StripeQuadrant quadrant, Color color) {
            switch (quadrant) {
                case StripeQuadrant.Top:
                    SendByte(ToByte(new[] { '1', '1', '0', '0', '0', '0', '0', '0' }));
                    break;
                case StripeQuadrant.Left:
                    SendByte(ToByte(new[] { '0', '1', '0', '0', '0', '0', '0', '0' }));
                    break;
                case StripeQuadrant.Right:
                    SendByte(ToByte(new[] { '0', '0', '1', '0', '0', '0', '0', '0' }));
                    break;
                case StripeQuadrant.Bottom:
                    SendByte(ToByte(new[] { '1', '0', '0', '0', '0', '0', '0', '0' }));
                    break;
            }
            _com.WriteLine(color.R + ";" + color.G + ";" + color.B);
        }

        /// <summary>
        ///     Dreht die Bitfolge des Kommandos und wandelt sie in ein Byte.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public byte ToByte(char[] command) {
            string arrayAsString = "";
            for (int index = command.Length - 1; index >= 0; index--) {
                char c = command[index];
                arrayAsString = arrayAsString + c;
            }
            return Convert.ToByte(arrayAsString, 2);
        }

        private void ComDataReceived(object sender, SerialDataReceivedEventArgs e) {
            int received = _com.ReadByte();
            this.RaiseAndSetIfChanged(ref _lastReceived, received);
        }

        private void SendByte(byte @byte) {
            if (_com.IsOpen) {
                byte[] bytes = { @byte };
                _com.Write(bytes, 0, 1);
            }
        }
    }
}