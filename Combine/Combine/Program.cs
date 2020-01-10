using System;

namespace Combine
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //MyDele dele1 = new MyDele(M1);
            //dele1 += (new Student()).SayHello ;
            //dele1.Invoke();
            //dele1();
            MyDele dele = new MyDele(Add);
            int res = dele(100, 200);
            Console.WriteLine(res);

            MyDele<int> deleAdd = new MyDele<int>(Add);
            int result = deleAdd(100, 200);
            MyDele<double> deleMul = new MyDele<double>(Mul);
            double mulRes = deleMul(3.0, 4.0);
            Console.WriteLine(mulRes);
            Console.WriteLine(deleAdd.GetType().IsClass);

            //Action<string,string > action = new Action<string,string> (SayHello);
            //action("Tim","Mike");
            Action<string, int> action = new Action<string, int>(SayHello);
            action("Tim", 3);

            Func<int, int, int> func = new Func<int, int, int>(Add);
            int res2 = func(100, 200);
            Console.WriteLine(res2);


            //lambda --anonymous,inline method
            var func1 = new Func<int, int, int>( (a, b) =>{ return a + b; } );
            int res3 = func(100, 200);
            func = (x, y) => { return x * y; };
            res3 = func(3, 4);
            Console.WriteLine(res3);

            DoSomeCalc((a, b) => { return a * b; }, 100, 200);



        }

        static void DoSomeCalc <T>(Func<T,T,T> func,T x,T y)
        {
            func(x, y);

        }

        static void M1()
        {
           Console.WriteLine("M1 is called");
        }

        static int Add(int x, int y)
        {
            return x + y;
        }

        static double Mul(double x, double y)
        {
            return x * y;
        }

        //static void SayHello(string name1, string name2)
        //{
        //    Console.WriteLine($"Hello, {name1} and {name2}!");
        //}

        static void SayHello(string name1, int round)
        {
            for (int i = 0; i < round; i++)
            {
                Console.WriteLine($"Hello, {name1}!");
            }
        }
    }

    class Student
    {
        public void SayHello()
        {
            Console.WriteLine("Hello, I am a student!");
        }
    }

    delegate int MyDele(int a, int b);

    delegate T MyDele<T>(T a, T b);

}
