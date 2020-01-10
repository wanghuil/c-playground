using System;

namespace classpractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator c = new Calculator();
            int x= c.Add(3, 4);
            string str = c.Today();
            Console.WriteLine(x);
            Console.WriteLine(str);
            c.PrintSum(4, 6);
            //c.PrintXTo1(10);
            int result = c.SumFrom1ToX(100);
            Console.WriteLine(result);
        }
    }

    class Calculator
    {
        public int Add(int a, int b)
        {
            int result = a + b;
            return result;
        }


        public string Today()
        {
            int day = DateTime.Now.Day;
            return day.ToString();
        }

        public void PrintSum(int a, int b)
        {
            int result = a + b;
          Console.WriteLine(result);     }

        //public void printxto1(int x)
        //{
        //    for (int i = x; i > 0; i--)
        //    {
        //        console.writeline(i);
        //    }
        //}

        public void PrintXTo1(int x)
        {
            if (x == 1) { Console.WriteLine(x); }
            else { Console.WriteLine(x);
                PrintXTo1(x - 1);
            }
        }

        //public int SumFrom1ToX(int x)
        //{   int result=0;
        //    for (int i = 1; i < x+1; i++)
        //    {
        //        result = result + i;
        //    }
        //    return result;
        //}

        public int SumFrom1ToX(int x)
        {
            if (x == 1) { return 1; }
            else { 
                int result = x + SumFrom1ToX(x - 1);
                return result;
            }
        }
    }
}
