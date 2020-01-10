using System;

namespace HelloEnum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Person person = new Person();
            person.Level = Level.Employee ;

            Person boss = new Person();
            boss.Level = Level.Boss;

            Console.WriteLine(boss.Level > person.Level);
            Console.WriteLine((int)Level.Employee);
            Console.WriteLine((int)Level.BigBoss);

            person.Name = "Tim";
            person.Skill = Skill.Drive | Skill.Cook | Skill.Program | Skill.Teach;
            Console.WriteLine((person.Skill & Skill.Cook)>0 );

            Student student1 = new Student() { ID = 101, Name = "Tim" };
            //object obj = student1;
            //Student student2 = (Student)obj;
            Student student2 = student1;
            student2.ID = 1001;
            student2.Name = "Mike";
            student1.Speak();
            Console.WriteLine($"#{student2.ID} Name:{student2.Name }");

            Student stu = new Student(1, "Ann");
            stu.Speak();

        }
    }

    interface ISpeak
    {
        void Speak();
    }

    struct Student : ISpeak
    {
       public Student(int id, string name) //must have parameters
        {
            this.ID = id;
            this.Name = name;
        }
        public int ID { get; set; }
        public string Name { get; set; }

        public void Speak()
        {
            Console.WriteLine($"I am #{this.ID} student {this.Name}.");
        }
    }

    enum Level
    {
        Employee ,
        Manager =200,
        Boss =300,
        BigBoss,
    }

    enum Skill
    {
        Drive =1,
        Cook =2,
        Program =4,
        Teach =8,
    }

    class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Level Level { get; set; }
        public Skill Skill { get; set; }
    }
}
