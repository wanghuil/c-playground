using System;
using System.Collections.Generic;

namespace IndexerExample1
{
    class Program
    {
        static void Main(string[] args)
        {
            Student stu = new Student();
            stu["Math"] = 90;
            var mathScore = stu["Math"];
            Console.WriteLine(mathScore );
            Console.WriteLine(URL.url);
            Console.WriteLine(URL.Location.Address);
        }
    }

    class Student
    {
        private Dictionary<string, int> scoreDictionary = new Dictionary<string, int>();

        public int? this[string subject]
        {
            get
            {
                if (this.scoreDictionary.ContainsKey(subject))
                {
                    return this.scoreDictionary[subject];
                }
                else
                {
                    return null;
                }

            }

            set
            {
                if (this.scoreDictionary.ContainsKey(subject))
                {
                    this.scoreDictionary[subject] = value.Value;
                }
                else
                {
                    this.scoreDictionary.Add(subject, value.Value);
                }
            }
        }

    }

    class URL
    {
        public const string url ="http://www.aaa.com.au";
        public static readonly Building Location = new Building("some addresses");
    }

    class Building
    {
        public Building(string address)
        {
            this.Address = address;
        }
        public string Address { get; set; }

    }
}
