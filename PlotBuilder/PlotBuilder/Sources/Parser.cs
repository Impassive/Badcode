using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlotBuilder.Sources
{
    public static class Parser
    {
        static string fileDirectory = "php.dat";
        static FileStream fs = new FileStream(fileDirectory, FileMode.Open);
        static BinaryReader br = new BinaryReader(fs);
        public static List<float> parser = new List<float>();
        public static void Do()
        {
            int hexIn;
            float res;
            parser.Clear();
            for (int i = 0; i < 1000; i++)
            {
                res = br.ReadSingle();
                parser.Add(res);
            }
            String hex;
        }
        public static double[] GetData(string fileDirectory)
        {
            List<double> data = new List<double>();
            string line = null;
            System.IO.StreamReader file = new System.IO.StreamReader(fileDirectory);
            while ((line = file.ReadLine()) != null)
            {
                data.Add(Convert.ToDouble(line, System.Globalization.CultureInfo.InvariantCulture));
            }
            file.Close();

            return data.ToArray();
        }
    }
}
