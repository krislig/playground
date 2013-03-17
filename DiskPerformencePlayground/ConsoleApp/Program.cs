using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamDiskTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string ssdPath = @"C:\images\image.exe";
            string ramDiskPath = @"E:\image.exe";
            string hddPath = @"D:\images\image.exe";

            int repeats = 10;
            
            MesaureTime(hddPath, repeats, "HDD");

            MesaureTime(ssdPath, repeats, "SSD");

            MesaureTime(ramDiskPath, repeats, "RamDisk");

            Console.ReadLine();
        }

        private static void MesaureTime(string path, int repeats, string name = "Disk")
        {
            List<long> times = new List<long>();
            
            Stopwatch stoper = new Stopwatch();

            for (int i = 0; i < repeats; i++)
            {
                stoper.Start();

                byte[] data = File.ReadAllBytes(path);

                stoper.Stop();

                Console.WriteLine("{0} time: {1}", name, stoper.ElapsedMilliseconds);
                times.Add(stoper.ElapsedMilliseconds);
            }

            Console.WriteLine("{0} avg. time: {1}", name, times.Sum() / repeats);
            Console.WriteLine();
        }
    }
}
