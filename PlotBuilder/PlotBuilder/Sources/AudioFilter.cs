using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlotBuilder.Sources
{
    public class AudioFilter
    { 
        public static string fileDirectory = "input.wav";

        public static double[] readWav(string filename, out int rate, out WaveFormat format)
        {
            WaveFileReader reader = new WaveFileReader(filename);
            format = reader.WaveFormat;
            float[] buffer;
            double[] data = new double[reader.SampleCount];
            int counter = 0;
            rate = reader.WaveFormat.SampleRate;

            while ((buffer = reader.ReadNextSampleFrame()) != null)
            {
                for (int i = 0; i < buffer.Length; i++)
                {
                    data[counter++] = buffer[i];
                }
            }
            reader.Close();
            return data;
        }
        public static void writeWav(string path, WaveFormat format, float[] samples)
        {
            using (WaveFileWriter writer = new WaveFileWriter(path, format))
            {
                writer.WriteSamples(samples, 0, samples.Length);
                writer.Flush();
            }
        }

    }
    }

