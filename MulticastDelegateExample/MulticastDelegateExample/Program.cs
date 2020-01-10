using System;
using System.Threading;
using System.Threading.Tasks;

namespace MulticastDelegateExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            Student stu1 = new Student() { ID = 1, PenColor = ConsoleColor.Yellow };
            Student stu2 = new Student() { ID = 2, PenColor = ConsoleColor.Green };
            Student stu3 = new Student() { ID = 2, PenColor = ConsoleColor.Red };


            //Synchronous call
            //method1
            //stu1.DoHomework();
            //stu2.DoHomework();
            //stu3.DoHomework();

            //method2
            Action action1 = new Action(stu1.DoHomework);
            Action action2 = new Action(stu2.DoHomework);
            Action action3 = new Action(stu3.DoHomework);

            //action1.Invoke();
            //action2.Invoke();
            //action3.Invoke();

            //method 3
            //action1 += action2;
            //action1 += action3;
            //action1.Invoke();


            // Asynchronous call
            //method1
            //action1.BeginInvoke(null,null);
            //action2.BeginInvoke(null,null);
            //action3.BeginInvoke(null,null);

            //method2
            Task task1 = new Task(new Action(stu1.DoHomework));
            Task task2 = new Task(new Action(stu2.DoHomework));
            Task task3 = new Task(new Action(stu3.DoHomework));

            task1.Start();
            task2.Start();
            task3.Start();

            for (int i=0; i<10; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Main thread {0}.", i);
                Thread.Sleep (1000);
            }

            
            
        
        }
    }

    class Student
    {
        public int ID { get; set; }
        public ConsoleColor PenColor { get; set; }

        public void DoHomework()
        {
            for (int i=0; i<5; i++)
            {
                Console.ForegroundColor = this.PenColor;
                Console.WriteLine("Student {0} doing homework {1} hour(s).", this.ID, i);
                Thread.Sleep(1000);

            }
        }

    }
}
