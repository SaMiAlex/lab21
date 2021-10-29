using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace lab21
{
    class Program
    {
        static int n = 6;
        static int m = 3;
        static int[,] array;
        static void Main(string[] args)
        {
            array = new int[n, m];
            Thread ostin1 = new Thread(garden1);
            Thread ostin2 = new Thread(garden2);
            ostin1.Start();
            ostin2.Start();
            ostin1.Join();
            ostin2.Join();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0,-5} ", array[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        static void garden1()
        {
            int a = 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (array[i, j] == 0)
                        array[i, j] = a++;
                    Thread.Sleep(1);
                }
            }
        }
        static void garden2()
        {
            int b = 100;
            for (int i = m - 1; i >= 0; i--)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    if (array[j, i] == 0)
                        array[j, i] = b++;
                    Thread.Sleep(1);
                }
            }
        }
    }
}
