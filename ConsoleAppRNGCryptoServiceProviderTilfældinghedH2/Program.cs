using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Diagnostics;

namespace ConsoleAppRNGCryptoServiceProviderTilfældinghedH2
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            // System.Random / Pseudo
            Random random = new Random();
            Console.WriteLine("System.Random");
            int num = 10000;
            stopwatch.Start();
            byte[] num1 = new byte[4];

            for (int i = 0; i < num; i++)
            {
                //int num = random.Next(10);

                random.NextBytes(num1);

                int value = BitConverter.ToInt32(num1,0);
                //Console.WriteLine(i + ") " + value);
            }
            stopwatch.Stop();

            Console.WriteLine("Stopwatch time : " + stopwatch.Elapsed);

            Console.WriteLine();

            // RNGCrptoServiceProvider / sikre tilfældige tal
            Console.WriteLine("RNGCrptoServiceProvider");
            stopwatch.Start();
            using (RNGCryptoServiceProvider scuoreRandom = new RNGCryptoServiceProvider())
            {
                byte[] num2 = new byte[4];

                for (int i = 0; i < num; i++)
                {
                    scuoreRandom.GetBytes(num2);

                    int value = BitConverter.ToInt32(num2, 0);
                    //Console.WriteLine(i +") "+ value);
                }
            }
            stopwatch.Stop();
            Console.WriteLine("Stopwatch time : " + stopwatch.Elapsed);
            Console.ReadKey();
        }
    }
}
