using System;
using System.Collections;
using System.Collections.Generic;

namespace StatesmentsExample2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            int score = 0;
            //bool canContinue = true;
            int sum = 0;
            //while(canContinue)
            do
            {
                Console.WriteLine("Please input first number:");
                string str1 = Console.ReadLine();

                if (str1.ToLower()=="end")
                {
                    break;
                }

                int x = 0;
                try
                {
                    x = int.Parse(str1);
                }
                catch
                {
                    Console.WriteLine("The first number has error. Restart");
                    continue;
                }

                Console.WriteLine("Plase input second number:");
                string str2 = Console.ReadLine();

                if (str2.ToLower() == "end")
                {
                    break;
                }

                int y = 0;
                try
                {
                    y = int.Parse(str2);
                }
                catch 
                {

                    //throw;
                    Console.WriteLine("The second number has error. Restart");
                    continue;
                }
             
                sum = x + y;
                if (sum == 100)
                {
                    score++;
                    Console.WriteLine("Correct! {0}+{1}={2}", x, y, sum);
                }
                else
                {
                    Console.WriteLine("Error! {0}+{1}={2}", x, y, sum);
                    //canContinue = false;
                }

            } while (sum == 100);
            //while (canContinue);
            Console.WriteLine("Your score is {0}.", score);
            Console.WriteLine("Game over!");



            //9*9 Multiplication table
            for (int i = 1; i <=9; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.WriteLine("{0}*{1}={2}\t", i, j, i * j);
                }
                Console.WriteLine();
            }


            int[] intArray = new int[] { 1, 2, 3, 4, 5, 6 };
            IEnumerator enumerator = intArray.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
            enumerator.Reset();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }


            List<int> inList = new List<int>() { 1, 2, 3, 4, 5, 6 };
            foreach (var current in inList)
            {
                Console.WriteLine(current);
            }

            //return early
            Greeting("Hello World");
            
            static void Greeting(string name)
            {
                if(string.IsNullOrEmpty(name))
                {
                    return;
                }
                Console.WriteLine("Hello, {0}!", name);
            }


        }
    }
}
