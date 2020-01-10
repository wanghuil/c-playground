﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Loader;
using BabyStroller.SDK;

namespace BabyStroller
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Environment.CurrentDirectory );
            var folder = Path.Combine(Environment.CurrentDirectory, "Animals");
            var files = Directory.GetFiles(folder);
            var animalTypes = new List<Type>();
            foreach (var file in files)
            {
                var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(file);
                var types = assembly.GetTypes();
                foreach (var t in types)
                {
                    //if (t.GetMethod("Voice") != null)
                    //{
                    //    animalTypes.Add(t);
                    //}
                    if (t.GetInterfaces().Contains(typeof(IAnimal)))
                    {
                        var isUnfinished = t.GetCustomAttributes(false).Any(a => a.GetType() == typeof(UnfinishiedAttribute));
                        if (isUnfinished)
                        {
                            continue;
                        }
                        animalTypes.Add(t);
                    }
                }
            }

            while (true)
            {
                for (int i = 0; i < animalTypes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}.{animalTypes[i].Name}");
                }
                Console.WriteLine("=============================");
                Console.WriteLine("Please choose animal:");
                int index = int.Parse(Console.ReadLine());
                if(index>animalTypes.Count || index < 1)
                {
                    Console.WriteLine("No such animal. Try again!");
                    continue;
                }

                Console.WriteLine("How many times?");
                int times = int.Parse(Console.ReadLine());
                var t = animalTypes[index - 1];
                var m = t.GetMethod("Voice");
                var o = Activator.CreateInstance(t);
                // m.Invoke(o, new object[] { times });
                var a = o as IAnimal;
                a.Voice(times);


            }
        }

    }
}
