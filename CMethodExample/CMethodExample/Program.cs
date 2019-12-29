using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMethodExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator c = new Calculator();
            Console.WriteLine(c.getCircleArea(10));
            Student stu = new Student(2,"Mr Okay");
            Console.WriteLine(stu.Name);
            Student stu2 = new Student();
            Console.WriteLine(stu2.ID);
        }

        class Calculator { 
            public double getCircleArea (double r) { return Math.PI* r * r; }

            public double GetCylinderVolume(double r, double h) { return getCircleArea(r) * h; }

            public double GetCloneVolume(double r, double h) { return GetCylinderVolume(r,h) / 3; }

            public int Add(int a, int b) { return a + b; }

            public int Add<T>(int a, int b) { T t; return a + b; }

            public int Add(out int a, int b) { a = 0;  return a + b; }
        }

        class Student
        {
            public Student(int initId, string initName)
            {
                this.ID = initId ;
                this.Name = initName;
            }
            public Student()
            {
                this.ID = 1;
                this.Name = "No Name";
            }

            public int ID;
            public string Name;
        }

       
    }
}
