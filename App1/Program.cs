using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace App1
{
    class Program
    {
        const int n = 5;
        const int m = 5;
        static int[,] path = new int[n, m] { { 5, 7, 3, 9, 2 }, { 3, 10, 1, 14, 10 }, { 6, 4, 2, 1, 20 }, { 35, 10, 18, 14, 30 }, { 35, 40, 11, 24, 17 } };
        static void Main(string[] args)
        {
            ThreadStart threadStart = new ThreadStart(Gardner1);
            Thread thread = new Thread(threadStart);
            thread.Start();

            Gardner2();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0}", path[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        static void Gardner1()
        {
            for(int i=0; i<n; i++)
            {
                for(int j=0; j<m; j++)
                {
                    if(path[i,j]>=0)
                    {
                        int delay = path[i, j];
                        path[i, j] = -1;
                        Thread.Sleep(delay);
                    }
                }
            }
        }
        static void Gardner2()
        {
            for (int i = n-1; i >=0; i--)
            {
                for (int j = m-1; j >=0; j--)
                {
                    if (path[i, j] >= 0)
                    {
                        int delay = path[i, j];
                        path[i, j] = -2;
                        Thread.Sleep(delay);
                    }
                }
            }
        }
    }
}
