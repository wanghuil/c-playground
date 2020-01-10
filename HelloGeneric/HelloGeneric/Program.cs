using System;
using System.Collections.Generic;

namespace HelloGeneric
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Apple apple = new Apple() { Color = "Red" };
            //AppleBox box = new AppleBox() { Cargo = apple };
            //Console.WriteLine(box.Cargo.Color);

            Book book = new Book() { Name = "New Book" };
            //BookBox bookBox = new BookBox() { Cargo = book };
            //Console.WriteLine(bookBox.Cargo.Name); 
            //Box box1 = new Box() { Apple = apple };
            //Box box2 = new Box() { Book = book };

            //Box box1 = new Box() { Cargo = apple };
            //Box box2 = new Box() { Cargo = book };
            //Console.WriteLine ((box2.Cargo as Apple)?.Color);

            Box<Apple> box1 = new Box<Apple>() { Cargo = apple };
            Box<Book> box2 = new Box<Book>() { Cargo = book };
            Console.WriteLine(box1.Cargo.Color);
            Console.WriteLine(box2.Cargo.Name);

            //Student<int> stu = new Student<int>();
            Student<ulong> stu = new Student<ulong>();
            stu.ID = 10000000000001;
            stu.Name = "Tim";

            IList<int> list = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);

            }

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            IDictionary<int, string> dict = new Dictionary<int, string>();
            dict[1] = "Tim";
            dict[2] = "Mike";
            Console.WriteLine($"Student #1 is {dict[1]}");
            Console.WriteLine($"Student #1 is {dict[2]}");

            int[] a1 = { 1, 2, 3, 4, 5 };
            int[] a2 = { 1, 2, 3, 4, 5 };
            double[] a3 = { 1.1, 2.2, 3.3, 4.4, 5.5 };
            double[] a4 = { 1.1, 2.2, 3.3, 4.4, 5.5, 6.6 };
            var result = Zip(a1, a2);
            Console.WriteLine(string.Join(",", result));

            Action<string> s1 = Say;
            //s1.Invoke("Tim");
            s1("Tim");

            Func<double,double,double > func1 = Add;
            var re = func1(100.1, 200.2);
            Console.WriteLine(re);

            Func<double, double, double> func2 = (a, b) => { return a + b; };
            var re1 = func2(100.1, 200.2);
            Console.WriteLine(re1);

        }

        static T[] Zip<T>(T[] a, T[] b) // a or b not null
        {
            T[] zipped = new T[a.Length + b.Length];
            int ai = 0; int bi = 0; int zi = 0;
            do
            {
                if (ai < a.Length) zipped[zi++] = a[ai++];
                if (bi < b.Length) zipped[zi++] = b[bi++];
            } while (ai < a.Length || bi < b.Length);

            return zipped;

        }

        static void Say(string str)
        {
            Console.WriteLine($"Hello, {str}!");
        }

        static void Mul(int x)
        {
            Console.WriteLine(x * 100);
        }

        static int Add(int a, int b)
        {
            return a + b;
        }

        static double Add(double a, double b)
        {
            return a + b;
        }
    }



    class Apple
    {
        public string Color { get; set; }
    }
    class Book
    {
        public string Name { get; set; }
    }

    class Box<TCargo>
    {
        //member expansion
        //public Apple Apple { get; set; }
        //public Book Book { get; set; }
        //public Object Cargo { get; set; }
        public TCargo Cargo { get; set; }
    }

    //type expansion
    //class AppleBox
    //{
    //    public Apple Cargo { get; set; }
    //}

    //class BookBox
    //{
    //    public Book Cargo { get; set; }
    //}
    interface IUnique<TId>
    {
        TId ID { get; set; }
    }

    //class Student<TId> : IUnique<TId>
    //{
    //    public TId ID { get; set; }
    //    public string Name { get; set; }
    //}

    class Student<TId> : IUnique<ulong>
    {
        
        public string Name { get; set; }
        public ulong ID { get ; set; }
    }


}
