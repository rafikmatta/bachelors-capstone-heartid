﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Reflection;
using System.Globalization;
using System.IO.Ports;

namespace Heart_ID_Csharp
{
    public class comm
    {

        #region Manager Enums

        /// <summary>
        /// enumeration to hold our message types
        /// </summary>
        public enum MessageType { Incoming, Outgoing, Normal, Warning, Error };
        public enum portNames { };
        #endregion
        
        #region Manager Variables

        //property variables
        private string _baudRate = string.Empty;
        private string _parity = string.Empty;
        private string _stopBits = string.Empty;
        private string _dataBits = string.Empty;
        private string _portName = string.Empty;
        private double[] ecg = new double[1500];
        private SerialPort comPort = new SerialPort();
        private RichTextBox _displayWindow;
        private ComboBox _comboBox;
        
        

        //global manager variables
        string transType = string.Empty;
        

        #endregion

        #region WriteData
        public void WriteData(string msg)
        {
            if (!(comPort.IsOpen == true)) comPort.Open();
            //send the message to the port
            comPort.Write(msg);
        }
        #endregion

        #region Manager Properties
        /// <summary>
        /// Property to hold the BaudRate
        /// of our manager class
        /// </summary>
        public string BaudRate
        {
            get { return _baudRate; }
            set { _baudRate = value; }
        }

        /// <summary>
        /// property to hold the Parity
        /// of our manager class
        /// </summary>
        public string Parity
        {
            get { return _parity; }
            set { _parity = value; }
        }

        /// <summary>
        /// property to hold the StopBits
        /// of our manager class
        /// </summary>
        public string StopBits
        {
            get { return _stopBits; }
            set { _stopBits = value; }
        }

        /// <summary>
        /// property to hold the DataBits
        /// of our manager class
        /// </summary>
        public string DataBits
        {
            get { return _dataBits; }
            set { _dataBits = value; }
        }

        /// <summary>
        /// property to hold the PortName
        /// of our manager class
        /// </summary>
        public string PortName
        {
            get { return _portName; }
            set { _portName = value; }
        }

        /// <summary>
        /// property to hold our display window
        /// value
        /// </summary>
        public RichTextBox DisplayWindow
        {
            get { return _displayWindow; }
            set { _displayWindow = value; }
        }
        #endregion

        #region HexToByte
        /// <summary>
        /// method to convert hex string into a byte array
        /// </summary>
        /// <param name="msg">string to convert</param>
        /// <returns>a byte array</returns>
        private byte[] HexToByte(string msg)
        {
            //remove any spaces from the string
            msg = msg.Replace(" ", "");
            //create a byte array the length of the
            //divided by 2 (Hex is 2 characters in length)
            byte[] comBuffer = new byte[msg.Length / 2];
            //loop through the length of the provided string
            for (int i = 0; i < msg.Length; i += 2)
                //convert each set of 2 characters to a byte
                //and add to the array
                comBuffer[i / 2] = (byte)Convert.ToByte(msg.Substring(i, 2), 16);
            //return the array
            return comBuffer;
        }
        #endregion

        #region OpenPort
        public bool OpenPort()
        {
            try
            {
                //first check if the port is already open
                //if its open then close it
                if (comPort.IsOpen == true) comPort.Close();

                //set the properties of our SerialPort Object
                comPort.BaudRate = int.Parse(_baudRate);    //BaudRate
                comPort.DataBits = int.Parse(_dataBits);    //DataBits
                comPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), _stopBits);    //StopBits
                comPort.Parity = (Parity)Enum.Parse(typeof(Parity), _parity);    //Parity
                comPort.PortName = _portName;   //PortName
                //now open the port
                comPort.Open();
                //display message
                DisplayData(MessageType.Normal, "Port opened at " + DateTime.Now + "\n");
                //return true
                return true;
            }
            catch (Exception ex)
            {
                DisplayData(MessageType.Error, ex.Message);
                return false;
            }
        }

        #endregion

        #region ClosePort

        public void ClosePort()
        {
            comPort.Close();
        }

        #endregion

        #region DisplayData
        /// <summary>
        /// method to display the data to & from the port
        /// on the screen
        /// </summary>
        /// <param name="type">MessageType of the message</param>
        /// <param name="msg">Message to display</param>
        [STAThread]
        private void DisplayData(MessageType type, string msg)
        {
            _displayWindow.AppendText(msg);
            _displayWindow.ScrollToEnd();

        }
        #endregion

        #region comPort_DataReceived
        /// <summary>
        /// method that will be called when theres data waiting in the buffer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //public byte[] comPort_DataReceived()
        //{

        //    int bytes = comPort.BytesToRead;
        //    //create a byte array to hold the awaiting data
        //    byte[] comBuffer = new byte[bytes];
        //    //read the data and store it
        //    comPort.Read(comBuffer, 0, bytes);
        //    //mask the data
        //    return comBuffer;
        //}

        //public void comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        //{

        //    int bytes = comPort.BytesToRead;
        //    comPort.
        //    //create a byte array to hold the awaiting data
        //    byte[] comBuffer = new byte[bytes];
        //    //read the data and store it
        //    comPort.Read(comBuffer, 0, bytes);
        //    //mask the data
        //    data = comBuffer;
        //}
        
        public int comPort_DataReceived()
        {

            //create a byte array to hold the awaiting data
            return comPort.ReadByte();
            //mask the data
            //return comBuffer;

        }

        #endregion

        #region GetPortNames

        public string[] get_names()
        {
            string[] ports = SerialPort.GetPortNames();
            return ports;
        }
        #endregion

        #region Manager Constructors
        /// <summary>
        /// Constructor to set the properties of our Manager Class
        /// </summary>
        /// <param name="baud">Desired BaudRate</param>
        /// <param name="par">Desired Parity</param>
        /// <param name="sBits">Desired StopBits</param>
        /// <param name="dBits">Desired DataBits</param>
        /// <param name="name">Desired PortName</param>
        public comm(ComboBox cbo)
        {
            _baudRate = "115200";
            _parity = "None";
            _stopBits = "1";
            _dataBits = "8";
            _portName = "COM4";
            _displayWindow = null;
            _comboBox = cbo;
            //now add an event handler
            //comPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
            _comboBox.ItemsSource = get_names();
        }

        #endregion

    }
}
