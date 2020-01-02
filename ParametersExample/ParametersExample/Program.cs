using System;
using System.Collections.Generic;
using System.Linq;

namespace ParametersExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Student stu = new Student();
            int y = 100;
            stu.AddOne(y);
            Console.WriteLine(y);


            Student stu1 = new Student();
            stu1.Name = "Torn";
            SomeMethod(stu1);
            Console.WriteLine( "{0},{1}",   stu1.Name,stu1.GetHashCode());
            Console.WriteLine("--------------------");
            Console.WriteLine("");

            UpdateObject(stu1);
            Console.WriteLine ("Hashcode={0}, Name={1}", stu1.GetHashCode(), stu1.Name);
            Console.WriteLine("--------------------");
            Console.WriteLine("");

            Student outterStu = new Student() { Name = "Tam" };
            Console.WriteLine("Hashcode={0}, Name={1}", outterStu.GetHashCode(), outterStu.Name);
            Console.WriteLine("____________________");
            IWantSideEffect(ref outterStu);
            Console.WriteLine("Hashcode={0}, Name={1}", outterStu.GetHashCode(), outterStu.Name);
            Console.WriteLine("--------------------");
            Console.WriteLine("");

            Student outterStu1= new Student() { Name = "Tam" };
            Console.WriteLine("Hashcode={0}, Name={1}", outterStu1.GetHashCode(), outterStu1.Name);
            Console.WriteLine("____________________");
            SomeSideEffect(ref outterStu);
            Console.WriteLine("Hashcode={0}, Name={1}", outterStu1.GetHashCode(), outterStu1.Name);
            Console.WriteLine("--------------------");
            Console.WriteLine("");

            double a = 3.14159;
            double c = a.Round(4);
            Console.WriteLine(c);
            Console.WriteLine("--------------------");
            Console.WriteLine("");


            List<int> myList = new List<int>() { 11, 12, 13, 14, 15 };
            bool result = AllGreaterThanTen(myList);
            bool result1 = myList.All(i => i > 10); //linq
            Console.WriteLine(result);
            Console.WriteLine(result1);
            Console.WriteLine("--------------------");
            Console.WriteLine("");


            double x1 = 100;
            bool b = double.TryParse("ABC", out x1);
            if (b == true)
            {
                Console.WriteLine(x1 + 1);
            }
            else
            {
                Console.WriteLine(x1);
            }
            Console.WriteLine("--------------------");
            Console.WriteLine("");



            Student stu2 = null;
            bool b2 = StudentFactory.Create("Tim", 34, out stu);
            if (b == true)
            {
                Console.WriteLine("Student {0}, age is {1}.", stu2.Name, stu2.Age);
            }


            Console.WriteLine("Please input first number:");
            string arg1 = Console.ReadLine();
            double x= 0;
            bool b1 = double.TryParse(arg1, out x);
            if (b1 == false)
            {
                Console.WriteLine("input error!");
                return;
            }

            Console.WriteLine("Please input second number:");
            string arg2 = Console.ReadLine();
            double x2= 0;
            bool b3 = double.TryParse(arg1, out x2);
            if (b3 == false)
            {
                Console.WriteLine("input error!");
                return;
            }
            double z = x + x2;
            Console.WriteLine("{0}+{1}={2}", x, x2, z);



        }

        static void SomeMethod(Student stu1)
        {
            stu1 = new Student() { Name = "Torn" };
            Console.WriteLine("{0}, {1}", stu1.Name, stu1.GetHashCode());

        }

        static void UpdateObject(Student stu1)
        {
            stu1.Name = "Tom";//side effect
            Console.WriteLine("Hashcode={0}, Name={1}", stu1.GetHashCode(), stu1.Name);
        }

        static void IWantSideEffect(ref Student stu)
        {
            stu = new Student() { Name = "Tim" };
            Console.WriteLine("Hashcode={0}, Name={1}", stu.GetHashCode(), stu.Name);

        }

        static void SomeSideEffect(ref Student stu)
        {
            stu.Name = "A";
            Console.WriteLine ("Hashcode={0}, Name={1}", stu.GetHashCode(), stu.Name);
        }

        //static int CalculateSum(params int[] intArray)
        static bool AllGreaterThanTen (List<int> intList)
        {
            foreach (var item in intList)
            {
                if (item<=10)
                {
                    return false;
                }
            }
            return true;
        }
    }

    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public void AddOne(int x)
        {
            x = x + 1;
            Console.WriteLine(x);        }
    }

    class StudentFactory
    {
        public static bool Create(string stuName, int stuAge, out Student result)
        {
            result = null;
            if (string.IsNullOrEmpty(stuName))
            {
                return false;
            }
            if (stuAge <20 || stuAge > 80)
            {
                return false;
            }
            result = new Student() { Name = stuName, Age = stuAge };
            return true;
        }
    }

    class DoubleParser
    {
        public static bool TryParse (string input, out double result)
        {
            try
            {
                result = double.Parse(input);
                return true;
            }
            catch
            {
                result = 0;
                return false;
            }
        }
    }


    static class DoubleExtension
    {
        public static double Round(this double input, int digits)
        {
            double result = Math.Round(input, digits);
            return result;
        }
    }
}
