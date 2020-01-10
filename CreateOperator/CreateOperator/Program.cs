using System;
using System.Collections.Generic;

namespace CreateOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            Person p2 = new Person();
            p1.Name = "MAN";
            p2.Name = "WOMAN";
            List<Person> nation = p1 + p2;
            foreach (var p in nation)
            {
                Console.WriteLine(p.Name);
            }

            int[] myIntArray = new int[] { 1, 2, 3, 4, 5 };
            Console.WriteLine(myIntArray[myIntArray.Length - 1]);

            Dictionary<string, Student> stuDic = new Dictionary<string, Student>();
            for (int i = 0; i < 100;  i++)
            {
                Student stu = new Student();
                stu.Name = "s_" + i.ToString();
                stu.Score = 100 + i;
                stuDic.Add(stu.Name, stu);
            }
            Student num6 = stuDic["s_6"];
            Console.WriteLine(num6.Score);
            Student stu1= new Student();
            Action myAction = new Action(stu1.PrintHello);
            myAction();

            Level level = default(Level);
            Console.WriteLine(level);

        }
    }

    class Person
    {
        public string Name;
        public static List<Person> operator + ( Person p1, Person p2) {
            List<Person> people = new List<Person>();
            people.Add(p1);
            people.Add(p2);
            for (int i = 0; i < 11; i++)
            {
                Person child = new Person();
                child.Name = p1.Name + " & " + p2.Name + " 's child "+ i;
                people.Add(child);
            }
            return people;
        }

    }

    class Student
    {
        public int Score;
        public string Name;

        public void PrintHello() { Console.WriteLine("Hello World !"); }
    }

    enum Level { 
        Mid=2 , 
        Low=0,//have to set a defauly value(0)
        High=3
    }
}
