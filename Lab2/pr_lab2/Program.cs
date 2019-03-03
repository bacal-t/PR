using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace pr_lab2
{
    class Program
    {
        static AutoResetEvent[] waitall = 
        {
           new AutoResetEvent(false),
           new AutoResetEvent(false),
           new AutoResetEvent(false),

        };

        static ManualResetEvent waitone = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            Thread five = new Thread(() => { Console.WriteLine("5"); waitall[0].Set(); });
            Thread six = new Thread(() => { Console.WriteLine("6"); waitall[1].Set(); });
            Thread seven = new Thread(() => {Console.WriteLine("7"); waitall[2].Set(); });
            Thread four = new Thread(() => {  WaitHandle.WaitAll(waitall); Console.WriteLine("4"); waitone.Set(); });
            Thread three = new Thread(() => { waitone.WaitOne(); Console.WriteLine("3"); });
            Thread two = new Thread(() => {  waitone.WaitOne(); Console.WriteLine("2"); });
            Thread one = new Thread(() => { waitone.WaitOne(); Console.WriteLine("1"); });


            List<Thread> list = new List<Thread>();

            list.Add(five);
            list.Add(six);
            list.Add(seven);
            list.Add(four);
            list.Add(three);
            list.Add(two);
            list.Add(one);

            foreach (var x in list)
            {
                x.Start();
            }
            Console.ReadKey();

        }
    }
}
