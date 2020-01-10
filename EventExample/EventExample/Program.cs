using System;
using System.Timers;

namespace EventExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer();
            timer.Interval = 1000;
            Boy boy = new Boy();
            timer.Elapsed += boy.Action; //1 event with 2 event handlers
            timer.Elapsed += Girl.Action;
            timer.Start();
            Console.ReadLine();
            //Console.WriteLine("Hello World!");
        }
    }

    class Boy
    {
        internal void Action(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Jump!");
        }
    }

    class Girl
    {
        internal static void Action(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Sing!");
        }
    }
}
