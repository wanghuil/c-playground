using System;
using System.IO;

namespace HelloCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var stream = File.Create(@"C:\Users\hslwli\Desktop\playground\HelloCSharp\Hello.txt");
            var writer = new StreamWriter(stream);
            writer.WriteLine("Hello C# World!");
            writer.Flush();
            writer.Close();
            Console.WriteLine("Done!");
        }
    }
}
