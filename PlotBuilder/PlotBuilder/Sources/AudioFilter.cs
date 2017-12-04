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
        static string fileDirectory = "input.mp3";
        public static byte[] audio;
        static WaveOut player;
        //static FileStream fs = new FileStream(fileDirectory, FileMode.Open);
        //static BinaryReader br = new BinaryReader(fs);
        public static void Do()
        {
            var bytes = File.ReadAllBytes(fileDirectory);
            var mp3Stream = new MemoryStream(bytes);
            var mp3FileReader = new Mp3FileReader(mp3Stream);
            var wave32 = new WaveChannel32(mp3FileReader, 0.1f, 1f);
            var ds = new DirectSoundOut();
            ds.Init(wave32);
            ds.Play();
            audio = bytes;
        }
        public static void Reverse(string name, byte[] arr)
        {
            //if (arr.Length == 0)
            //    arr = audio;
            //player = new WaveOut();
            //IWaveProvider provider = new RawSourceWaveStream(
            //             new MemoryStream(audio), new WaveFormat());

            //player.Init(provider);
            //player.Play();

            //for (int i=0; i<25;i++)
            //{
            //    arr[i] = audio[i];
            //}
            var mp3Stream = new MemoryStream(arr);
            var mp3FileReader = new Mp3FileReader(mp3Stream);
            var wave32 = new WaveChannel32(mp3FileReader, 0.1f, 1f);
            var ds = new DirectSoundOut();
            ds.Init(wave32);
            ds.Play();
        }
    }
}

