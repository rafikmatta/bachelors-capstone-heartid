using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

// MathWorks assemblies that ship with Builder for .NET
// and should be registered in Global Assembly Cache
using MathWorks.MATLAB.NET.Utility;
using MathWorks.MATLAB.NET.Arrays;

// Assembly built by Builder for .NET containing 
// math_on_numbers.m
using dotnet;

namespace Heart_ID_Csharp
{
    public class algorithm
    {
        //Initializing Classwide Variable 
        MWArray gallery = new MWNumericArray(); //generic gallery + enrollee gallery
        MWArray enrollee_gallery = new MWNumericArray();  //gallery of just the enrollee only


        MWArray id = new MWNumericArray(); //generic id + enrollee id    
        MWArray enrollee_id = new MWNumericArray(); //enrollee id

        MWArray weights = new MWNumericArray(); //weight matrix from the dlda 
        MWArray projected_gallery = new MWNumericArray(); //projected enrollee gallery

        MWNumericArray M = new MWNumericArray(60);

        dotnetclass AClass = new dotnetclass(); //MatLab function wrapper class handler

        double[] ecg = new double[1280]; //Double array to hold indivdual sample of a ECG signal
        int [] output = new int[3]; //ouput value to identification function
        

        public algorithm()
        {
            output[0] = 0;
            output[1] = 0;
            output[2] = 0;      
        }


        //@param s_id subject id
        //@param ecg_in a single sample value of the subject's ECG

        public void enrollment (double[] ecg_in, int s_id)
        {
            for( int i = 0; i < ecg_in.Length; i++)
            {
                ecg[i] = ecg_in[i];
            }
            
            //Create a MWArray to pass value into converted matlab function
                MWNumericArray subj_id = new MWNumericArray(s_id);
                MWNumericArray ecg_raw = new MWNumericArray(1280, 1, ecg);
                MWArray temp = AClass.process(ecg_raw, M);  //process ecg data(filter and AC)

                //autocorrelated signal is added to both gallery
                MWArray gal = new MWNumericArray();
                gal = gallery;
                gallery = AClass.addtogallery(gal, temp);

                MWArray gal1 = new MWNumericArray();
                gal1 = enrollee_gallery;
                enrollee_gallery = AClass.addtogallery(gal1, temp);

                //subject id is added to the id vector
                MWArray id_temp = new MWNumericArray();
                id_temp = id;
                id = AClass.addtoid(id_temp, subj_id);

                MWArray id_temp1 = new MWNumericArray();
                id_temp1 = enrollee_id;
                enrollee_id = AClass.addtoid(id_temp1, subj_id);

                //the weight matric is calculated
                weights = AClass.dlda(gallery, id);

                //enrollee gallery is projected
                projected_gallery = AClass.projection(gallery, weights); //use enrollee gallery if want to project enrollee gallery
         }

            

        public int[] identification(double[] ecg)
        {
         
                MWNumericArray ecg_raw = new MWNumericArray(1280, 1, ecg);
                MWArray ac_input = AClass.process(ecg_raw, M);

                MWArray gal = new MWNumericArray();
                gal = AClass.addtogallery(gal, ac_input);

                MWArray projected_input = AClass.projection(gal, weights);
                MWArray best_id = AClass.classify_input(projected_input, projected_gallery, id); //should be change to enrollee_id if projected_gallery is enrollee 

                string temp = best_id.ToString();

                string best_id1 = temp.Substring(0, temp.IndexOf(" "));
                temp = temp.Substring(temp.IndexOf(" "));
                temp = temp.Trim();

                string best_id2 = temp.Substring(0, temp.IndexOf(" "));
                temp = temp.Substring(temp.IndexOf(" "));
                temp = temp.Trim();
          
                output[0] = Convert.ToInt32(best_id1);
                output[1] = Convert.ToInt32(best_id2);
                output[2] = Convert.ToInt32(temp);

                return output;

        }

        public void train()
        {
            dotnetclass AClass = new dotnetclass();

            int s_id = 1;

            while (s_id < 6)
            {
                MWNumericArray subj_id = new MWNumericArray(s_id);
                StreamReader sr = new StreamReader("ecg" + s_id + ".txt");

                while (sr.Peek() != -1)
                {
                    double[] ecg = new double[1280];
                    string line;
                    int i = 0;
                    int b = 0;
                    for (i = 0; i < 1280; i++)
                    {
                        if ((line = sr.ReadLine()) != null)
                        {
                            if (String.IsNullOrWhiteSpace(line))
                            {
                                b = 1;
                                break;
                            }
                            double line1 = Convert.ToDouble(line);
                            ecg[i] = line1;
                        }
                    }
                    if (b == 1) break;
                    MWNumericArray ecg_raw = new MWNumericArray(1280, 1, ecg);
                    MWArray RetVal = AClass.process(ecg_raw, M);

                    MWArray gal = new MWNumericArray();
                    gal = gallery;
                    gallery = AClass.addtogallery(gal, RetVal);

                    MWArray id_temp = new MWNumericArray();
                    id_temp = id;
                    id = AClass.addtoid(id_temp, subj_id);
                }
                if (sr != null) sr.Close();
                s_id++;
            }
            weights = AClass.dlda(gallery, id);
            projected_gallery = AClass.projection(gallery, weights);
        }

        public void save()
        {

            BinaryFormatter bFormatter = new BinaryFormatter();

            Stream stream = File.Open("weights", FileMode.OpenOrCreate);
            bFormatter.Serialize(stream, weights);
            stream.Close();

            stream = File.Open("gallery", FileMode.OpenOrCreate);
            bFormatter.Serialize(stream, gallery);
            stream.Close();

            stream = File.Open("projected_gallery", FileMode.OpenOrCreate);
            bFormatter.Serialize(stream, projected_gallery);
            stream.Close();

            stream = File.Open("id", FileMode.OpenOrCreate);
            bFormatter.Serialize(stream, id);
            stream.Close();

            //stream = File.Open("enrollee_gallery", FileMode.OpenOrCreate);
            //bFormatter.Serialize(stream, enrollee_gallery);
            //stream.Close();

            //stream = File.Open("enrollee_id", FileMode.OpenOrCreate);
            //bFormatter.Serialize(stream, enrollee_id);
            //stream.Close();
        }

        public void load()
        {
            
            BinaryFormatter bFormatter = new BinaryFormatter();

            Stream stream = File.Open("weights", FileMode.Open);
            weights = (MWArray)bFormatter.Deserialize(stream);
            stream.Close();

            stream = File.Open("gallery", FileMode.Open);
            gallery = (MWArray)bFormatter.Deserialize(stream);
            stream.Close();

            stream = File.Open("projected_gallery", FileMode.Open);
            projected_gallery = (MWArray)bFormatter.Deserialize(stream);
            stream.Close();

            stream = File.Open("id", FileMode.Open);
            id = (MWArray)bFormatter.Deserialize(stream);
            stream.Close();

            //stream = File.Open("enrollee_gallery", FileMode.Open);
            //enrollee_gallery = (MWArray)bFormatter.Deserialize(stream);
            //stream.Close();

            //stream = File.Open("enrollee_id", FileMode.Open);
            //enrollee_id = (MWArray)bFormatter.Deserialize(stream);
            //stream.Close();
        }

        public void delete(double id_num)
        {
            MWNumericArray delete_id = new MWNumericArray(id_num);
            gallery = AClass.delete_gallery(gallery, id, delete_id);
            id = AClass.delete_id(id, delete_id);
        }

        public double verification(double[] ecg, double thresh, int claim_id)
        {
            MWNumericArray threshold = new MWNumericArray(thresh);
            MWNumericArray id_num = new MWNumericArray(claim_id);

            MWNumericArray ecg_raw = new MWNumericArray(1280, 1, ecg);
            MWArray ac_input = AClass.process(ecg_raw, M);

            MWArray gal = new MWNumericArray();
            gal = AClass.addtogallery(gal, ac_input);

            MWArray claimed_gallery = AClass.claim_gallery(gallery, id, id_num);
            claimed_gallery = AClass.projection(claimed_gallery, weights);

            MWArray projected_input = AClass.projection(gal, weights);
            MWArray result = AClass.authentication(projected_input, claimed_gallery, threshold); //should be change to enrollee_id if projected_gallery is enrollee 

            return Convert.ToDouble(result.ToString());
        }

    }

        
}
