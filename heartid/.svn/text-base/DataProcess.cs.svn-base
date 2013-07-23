using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace Heart_ID_Csharp
{
    class DataProcess
    {
        
        comm c;
        StreamWriter tw = new StreamWriter("log.txt");
        private bool graphing_done;
        private bool function_done;
        double[] graph_buffer = new double[1280];
        double[] ecg = new double[1280];
        private System.Object lockthis = new System.Object();

        public DataProcess(comm comPort)
        {
            c= comPort;
        }

        public void getData()
        {

            int comByte;
            string line;
            int newval = 0;
            double val = 0.0;
            int ecg_counter= 0;
            
            while (ecg_counter < 1279)
            {
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


                    if (ecg_counter <= 1279)
                    {
                        ecg[ecg_counter] = val;
                        graph_buffer[ecg_counter] = val;
                        ecg_counter++;
                        //newdat = false;
                    }

                    else if (ecg_counter > 1279)
                    {
                        ecg_counter = 0;
                        //newdat = true;
                    }


                }
            }
        }

        public double[] getGraphData()
        {
            return graph_buffer;
        }

        public double[] data()
        {
            return ecg;
        }
        public void setGraphingState(bool state)
        {
            graphing_done = state;
        }
        public void setDataState(bool state)
        {
            function_done = state;
        }

    }
}
