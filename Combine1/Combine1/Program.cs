using System;
using Combine1.Models;

namespace Combine1
{
    class Program
    {
        static void Main(string[] args)
        {
            //linq
            var dbContext = new AdventureWorks2014Entities();
            var allFirstNames = dbContext.People.Select(p => p.FirstName).ToList();
            var allFullNames = dbContext.People.Select(p => p.FirstName + " " + p.LastName).ToList();
            var allTims = dbContext.People.Where(p => p.FirstName == "Tim")
                .Select(p => p.FirstName + " " + p.LastName).ToList();
            var boolTim = dbContext.People.Any(p => p.FirstName == "Tim");
            var groups = dbContext.People.GroupBy(p => p.FirstName).ToList();
            foreach (var g in groups)
            {
                Console.WriteLine("Name:{0}\tCount:{1}", g.Key, g.Count());
            }

            var count = dbContext.People.Count(p => p.FirstName == "Tim");
            Console.WriteLine(count);
            //var allPeople = dbContext.People.ToList();
            //foreach (var p in allPeople)
            //{
            //    Console.WriteLine(p.FirstName);
            //}
            //Console.WriteLine("Hello World!");
        }
    }
}
