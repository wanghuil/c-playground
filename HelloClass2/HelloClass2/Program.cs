using System;
using MyLib.MyNamespace;

namespace HelloClass2
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            double res = calc.Add(1.1, 2.2);
           // Console.WriteLine("Hello World!");
        }
    }
}
