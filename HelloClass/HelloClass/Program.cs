using System;

namespace HelloClass
{
    class Program
    {
        static void Main(string[] args)
        {
            //Student stu = new Student(1, "Tim");
            //Console.WriteLine(stu.Name );
            //stu.Report();
            //Type t = typeof(Student);
            //object o = Activator.CreateInstance(t, 1, "Tim");
            //Console.WriteLine(o.GetType().Name);
            //Student stu = o as Student;
            //dynamic stu = Activator.CreateInstance(t, 1, "Tim");
            //Console.WriteLine(stu.ID);
            Student s1 = new Student(1, "Tim");
            Student s2 = new Student(2, "Tom");
            Console.WriteLine(Student.Amount);
        }
    }

    class Student
    {
        public static int Amount { get; set; }
        static Student()
        {
            Amount = 100;
        }
        public Student(int id, string name)
        {
            this.ID = id;
            this.Name = name;
            Amount++;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public void Report()
        {
            Console.WriteLine($"I'm #{this.ID} student, my name is {this.Name}.");
        }
    }
}
