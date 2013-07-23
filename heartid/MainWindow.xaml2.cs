using System;
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
using System.Threading;
using System.Windows.Threading;
using System.Windows.Forms.Integration;

namespace Heart_ID_Csharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml


    
    public partial class MainWindow : Window
    {
        
        
        algorithm a = new algorithm();
        comm c = new comm();
        WindowsFormsHost host = new WindowsFormsHost();
        ZedGraphUserControl graph = new ZedGraphUserControl();
        
        private int id = 6;
        StreamWriter tw = new StreamWriter("log.txt");

        //Graphing variables
        private double[] ecg = new double[1000];
        private int ecg_counter = 0;
        private int graph_counter = 0;
        private Thread t;
        public enum Situation{ Resting,Engaged,Active };
        
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, EventArgs e)
        {
            a.train();
            identify.IsEnabled = false;
            enrol.IsEnabled = false;
            host.Child = graph;
            grdMain.Children.Add(host);
            this.Width = graph.Width + 2 * 20;
            this.Height = graph.Height + 3 * 20;
            SetDefaults();
            SetControlState();
            string[] ports = SerialPort.GetPortNames();
        }
                      
        #region SetDefaults
        /// <summary>
        /// Method to initialize serial port
        /// values to standard defaults
        /// </summary>
        private void SetDefaults()
        {
            cboPort.SelectedIndex = 0;
        }

        #endregion

        #region SetControlState
        /// <summary>
        /// method to set the state of controls
        /// when the form first loads
        /// </summary>
        private void SetControlState()
        {
            cmdSend.IsEnabled = false;
        }
        #endregion

        private void identify_Click(object sender, RoutedEventArgs e)
        {
            getData();
            int[] results = new int[3];
            string result1;
            string result2;
            string result3;
            results = a.identification(ecg);
            result1 = results[0].ToString();
            result2 = results[1].ToString();
            result3 = results[2].ToString();
            rtbResults.
                AppendText(result1);
            rtbResults.ScrollToEnd();
            rtbResults.AppendText(result2);
            rtbResults.ScrollToEnd();
            rtbResults.AppendText(result3);
            rtbResults.ScrollToEnd();
        }
        private void enrol_Click(object sender, RoutedEventArgs e)
        {
            //string name = tx.Text + ".txt";
            //tw = File.CreateText(name);
            //a.train();
            getData();
            a.enrollment(ecg, id);
            id++;
        }

        private void getData()
        {
            byte[] comByte = c.comPort_DataReceived();
            string line;
            int newval = 0;
            double val = 0.0;
            //loop through each byte in the array
            for (int i = 0; i < comByte.Length - 2; i++)
            {
                //if the byte is an 'e' indicating ecg1
                if (comByte[i].Equals(101))
                {
                    int i1 = comByte[i + 1] - 32;
                    int i2 = comByte[i + 2] - 32;
                    newval = i2 << 6 | i1;
                    newval = newval & 1023;
                    // write a line of text to the file
                    line = newval.ToString();
                    val = System.Convert.ToDouble(newval);
                    if (ecg_counter <= 999)
                    {
                        ecg[ecg_counter] = val;
                        ecg_counter++;
                    }
                    else if (ecg_counter > 999)
                    {
                        ecg_counter = 0;
                    }

                }
            }
        }
        
        private void graphing()
        {
            byte[] comByte = c.comPort_DataReceived();
            while (comByte != null)
            {
                // create a writer and open the file

                string line;
                int newval = 0;
                double val = 0.0;
                double count = 0;
                //loop through each byte in the array
                for (int i = 0; i < comByte.Length - 2; i++)
                {
                    //if the byte is an 'e' indicating ecg1
                    if (comByte[i].Equals(101))
                    {
                        int i1 = comByte[i + 1] - 32;
                        int i2 = comByte[i + 2] - 32;
                        newval = i2 << 6 | i1;
                        newval = newval & 1023;
                        // write a line of text to the file
                        line = newval.ToString();
                        tw.WriteLine(line);
                        val = System.Convert.ToDouble(newval);
                        count = System.Convert.ToDouble(graph_counter);
                        graph.SetData(val);
                        graph.SetXAxis(count);
                        graph.graph();
                        graph_counter++;
                    }
                }
            }
        }
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            tw.Close();
            t.Abort();
            Close();
        }
        private void connect_Click(object sender, RoutedEventArgs e)
        {
            c.DisplayWindow = rtbDisplay;
            c.PortName = cboPort.Text;
            c.OpenPort();
            connect.IsEnabled = false;
            cmdSend.IsEnabled = true;
            identify.IsEnabled = true;
            enrol.IsEnabled = true;
            t = new Thread(new ThreadStart(graphing));
            t.Start();
        }
    }
}
