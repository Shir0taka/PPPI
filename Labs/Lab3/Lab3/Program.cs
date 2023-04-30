using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Media;
using System.Runtime.Remoting.Messaging;
using System.ComponentModel;
using System.Net.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Timers;

namespace Lab3
{
    internal class Program
    {
        static void ThreadAnnouncer()
        {
            Console.WriteLine("Timer launched");
            Thread.Sleep(1000);
            Console.WriteLine("Thread 1 launched!");
            Thread.Sleep(1500);
            Console.WriteLine("Maybe async method launched");
            Thread.Sleep(10000);
            Console.WriteLine("10 seconds passed");
        }

        static async Task AsyncMethod()
        {
            Console.WriteLine("Yes, AsyncMethod launched");
            await Task.Delay(1500);
            Console.WriteLine("Type something");
            await Task.Delay(12000);
            Console.WriteLine("12 seconds passed");
        }

        static void Timer()
        {
            DateTime startTimer = DateTime.Now;

            if (Console.ReadLine() == "stop")
            {
                Console.WriteLine($"Timer stopped \n" +
                    $"Total time: {(DateTime.Now - startTimer).TotalSeconds}s");
            }
        }

        static async Task Main(string[] args)
        {
            ConsoleKeyInfo cki;

            Thread thrd_first = new Thread(ThreadAnnouncer);
            thrd_first.Start();

            Thread timer = new Thread(Timer);
            Thread.Sleep(1000);
            timer.Start();          

            await Task.Delay(2000);
            await AsyncMethod();

            Console.ReadLine();
            Console.ReadKey();
        }
    }
}