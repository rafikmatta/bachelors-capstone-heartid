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
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Globalization;
using System.IO.Ports;
using System.Threading;
using System.Windows.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing.Drawing2D;
using System.Messaging;
using System.Diagnostics;

namespace Heart_ID_Csharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml



    public partial class MainWindow : Window
    {

        /* Main Class Calls for the program*/
        algorithm a = new algorithm();
        Browser b = new Browser();
        comm c;
        WindowsFormsHost host = new WindowsFormsHost();
        /***********************************/

        //GraphingWindow g;
        private int id = 5;
        private int temp_id;
        StreamWriter tw = new StreamWriter("log.txt");

        Boolean newdat = false;

        private int operation = 0;
        public int[] results = new int[3];

        public delegate void methodcall();           
        private bool not_stop = true;
        private string[] name = new string[1000000];
        private string[] usernames = new string[100000];
        private string[] passwords = new string[100000];

        /*Graphing variables*/ 

        public double[] ecg = new double[1280];
        private int ecg_counter = 0;

        //private int graph_counter = 0;
        //bool stop_graphing;
        
        //ZedGraphUserControl graph = new ZedGraphUserControl();


        MessageQueue queue = null; 

        //ComboBox Fillers
        public enum Situation { Resting, Engaged, Active };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, EventArgs e)
        {
            a.train();
            identify.IsEnabled = false;
            enrol.IsEnabled = false;
            verify.IsEnabled = false;
            SetDefaults();
            SetControlState();
            c = new comm(cboPort);
            name[1] = "null";
            name[2] = "null";
            name[3] = "null";
            name[4] = "null";
            name[5] = "null";
            if (MessageQueue.Exists(@".\Private$\MyQueue"))
                queue = new System.Messaging.MessageQueue(@".\Private$\MyQueue");
            else
                queue = MessageQueue.Create(@".\Private$\MyQueue");

        }


        private void SetDefaults()
        {
            cboPort.SelectedIndex = 0;
        }

        private void SetControlState()
        {
            cmdSend.IsEnabled = false;
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // textBox3.Text = listBox1.SelectedItem.ToString();

        }

        private void identify_f()
        {

            string result1 = "";
            string result2 = "";
            string result3 = "";

            while (!newdat && not_stop)
            {
                getData();
            }

            if (not_stop)
            {
                newdat = false;
                results = a.identification(ecg);

                result1 = name[results[0]];
                result2 = name[results[1]];
                result3 = name[results[2]];
                rank1.Clear();
                rank2.Clear();
                rank3.Clear();
                rank1.AppendText(result1);
                rank2.AppendText(result2);
                rank3.AppendText(result3);

                identify.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.SystemIdle, new methodcall(this.identify_f));
            }


        }

        private void enrol_f()
        {

            while (!newdat && not_stop)
            {
                getData();
            }

            if (not_stop)
            {
                newdat = false;
                a.enrollment(ecg, id);

                enrol.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.SystemIdle, new methodcall(this.enrol_f));
            }
        }

      
        private void getData()
        {

            int comByte;
            string line;
            int newval = 0;
            double val = 0.0;
            comByte = c.comPort_DataReceived();
            if (comByte.Equals(101))
            {
                comByte = c.comPort_DataReceived();
                int i1 = comByte - 32;
                comByte = c.comPort_DataReceived();
                int i2 = comByte - 32;
                newval = i2 << 6 | i1;
                newval = newval & 1023;

                // write a line of text to the file
                line = newval.ToString();
                tw.WriteLine(line);
                val = System.Convert.ToDouble(newval);

                queue.Send(line);
                if (ecg_counter <= 1279)
                {
                    ecg[ecg_counter] = val;
                    ecg_counter++;
                    newdat = false;
                }
                else if (ecg_counter > 1279)
                {
                    ecg_counter = 0;
                    newdat = true;
                }

            }  
            
        }


        #region ClickEvents

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            enrol.Dispatcher.BeginInvokeShutdown(DispatcherPriority.SystemIdle);
            tw.Close();
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
            Thread.Sleep(1280);
            enrol.IsEnabled = true;

        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            a.save();

            BinaryFormatter bFormatter = new BinaryFormatter();

            Stream stream = File.Open("name", FileMode.OpenOrCreate);
            bFormatter.Serialize(stream, name);
            stream.Close();

            stream = File.Open("name_id", FileMode.OpenOrCreate);
            bFormatter.Serialize(stream, id);
            stream.Close();

            rtbResults.AppendText("Save Done\n");
        }

        private void load_Click(object sender, RoutedEventArgs e)
        {
            a.load();

            BinaryFormatter bFormatter = new BinaryFormatter();

            Stream stream = File.Open("name", FileMode.Open);
            name = (string[])bFormatter.Deserialize(stream);
            stream.Close();

            stream = File.Open("name_id", FileMode.Open);
            id = (int)bFormatter.Deserialize(stream);
            stream.Close();

            rtbResults.AppendText("Load Done\n");

            listBox1.Items.Clear();
            listBox2.Items.Clear();
            for (int i = 6; i <= id; i++)
            {
                listBox1.Items.Add(name[i]);
                listBox2.Items.Add(name[i]);
            }
            load.IsEnabled = false;
            load1.IsEnabled = false;

        }

        private void portClose_Click(object sender, RoutedEventArgs e)
        {
            c.ClosePort();
            connect.IsEnabled = true;
        } 
        
        private void enrol_stop_Click(object sender, RoutedEventArgs e)
        {
            not_stop = false;

            if (operation == 0)
            {
                rtbResults.AppendText("Enroll Done\n");
                rtbResults.ScrollToEnd();
                enrol.IsEnabled = true;
                identify.IsEnabled = true;
                verify.IsEnabled = true;
                if (temp_id > id) id = temp_id;
                
            }

        }

        private void identify_stop_Click(object sender, RoutedEventArgs e)
        {
            not_stop = false;

            if (operation == 1)
            {
                identify.IsEnabled = true;
                enrol.IsEnabled = true;

                rtbResults.AppendText("Identify Stop\n");
                rtbResults.ScrollToEnd();

            }
        }

        private void graph_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("graphing.exe");
            
        }

        private void identify_Click(object sender, RoutedEventArgs e)
        {
            operation = 1;
            identify.IsEnabled = false;
            enrol.IsEnabled = false;
            not_stop = true;
            identify.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new methodcall(identify_f));
        }

        private void enrol_Click(object sender, RoutedEventArgs e)
        {
            operation = 0;
            StreamWriter file = new StreamWriter("userbase");
            string temp = textBox3.GetLineText(0);
            string username = user_text.Text;
            string pass = pass_text.Text;
            if (temp != "")
            {
                for (int i = 5; i <= id; i++)
                {
                    if (name[i] == temp)
                    {
                        string message = "Name already exist, re-enroll " + temp + "?";
                        MessageBoxResult result = System.Windows.MessageBox.Show(message, "Duplicate Name", System.Windows.MessageBoxButton.YesNo,
                                System.Windows.MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            temp_id = id;
                            id = i - 1;
                            break;
                        }
                        else if (result == MessageBoxResult.No)
                        {
                            string messageBoxText = "Please enter another name!";
                            string caption = "Error";
                            System.Windows.MessageBox.Show(messageBoxText, caption);
                            return;
                        }
                    }
                }

                id++;
                textBox3.Clear();
                enrol.IsEnabled = false;
                identify.IsEnabled = false;
                verify.IsEnabled = false;
                not_stop = true;
                name[id] = temp;
                string line = name[id] + " " + username + " " + pass;
                file.WriteLine(line);
                file.Close();
                listBox1.Items.Add(temp);
                listBox2.Items.Add(temp);
                enrol.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new methodcall(enrol_f));
            }
            else
            {
                string messageBoxText = "Please enter a name!";
                string caption = "Error";
                System.Windows.MessageBox.Show(messageBoxText, caption);

            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            string temp = listBox1.SelectedItem.ToString();
            int delete_index = 5;
            
            for (int i = 5; i <= id; i++)
            {
                if (name[i] == temp)
                {
                    a.delete((double)i);
                    delete_index = i;
                    listBox1.Items.Clear();
                    listBox2.Items.Clear();
                    name[i] = "";
                    for (int x = 6; x <= id; x++)
                    {
                        if (name[x] != "")
                        {
                            listBox1.Items.Add(name[x]);
                            listBox2.Items.Add(name[x]);
                        }
                    }
                    break;
                }
            }
            for (int i = delete_index; i <= id; i++)
            {
                name[i] = name[i + 1];
            }
            id--;

    
        }

        private void verify_Click(object sender, RoutedEventArgs e)
        {

            double thresh = 0.1;
            string temp = textBox4.Text;
            string level = comboBox2.Text;
            string line;
            StreamReader file = new StreamReader("userbase");
            verifyresult.Text = " ";

            if (level == "High")
            {
                thresh = 0.2;
            }
            else if (level == "Medium")
            {
                thresh = 0.4;
            }
            else if (level == "Low")
            {
                thresh = 0.6;
            }

            while (!newdat)
            {
                getData();
            }
            newdat = false;
            for (int i = 5; i <= id; i++)
            {
                if (name[i] == temp)
                {
                    int verify_id = i;
                    verifyresult.Text = Convert.ToString(a.verification(ecg, thresh, verify_id));

                    while (!file.EndOfStream)
                    {
                        line = file.ReadLine();
                        string[] splits = line.Split(' ');
                        if (splits[0].Equals(name[i]))
                        {
                            b.SetUserPass(splits[1], splits[2]);
                        }
                    }

                    break;
                }
            }
            b.browser_fill();

        }

        private void listBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string temp = listBox2.SelectedItem.ToString();
            textBox4.Text = temp;
        }
        private void load1_Click(object sender, RoutedEventArgs e)
        {
            a.load();

            BinaryFormatter bFormatter = new BinaryFormatter();

            Stream stream = File.Open("name", FileMode.Open);
            name = (string[])bFormatter.Deserialize(stream);
            stream.Close();

            stream = File.Open("name_id", FileMode.Open);
            id = (int)bFormatter.Deserialize(stream);
            stream.Close();

            rtbResults.AppendText("Load Done\n");

            listBox1.Items.Clear();
            listBox2.Items.Clear();
            for (int i = 6; i <= id; i++)
            {
                listBox1.Items.Add(name[i]);
                listBox2.Items.Add(name[i]);
            }
            load1.IsEnabled = false;
            load.IsEnabled = false;
            verify.IsEnabled = true;
        }
        #endregion

        private void stop_graph_Click(object sender, RoutedEventArgs e)
        {
            queue.Purge();
        }

        private void browser_Click(object sender, RoutedEventArgs e)
        {
            
            b.Show();
            

        }
    }
}
