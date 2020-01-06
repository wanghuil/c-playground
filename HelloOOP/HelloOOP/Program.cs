using System;

namespace HelloOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            //Type t = typeof(Car);
            //Type tb = t.BaseType;
            //Type tTop = tb.BaseType;
            //Console.WriteLine(tb.FullName );
            //RaceCar raceCar = new RaceCar();
            Car car = new Car("Tim");
            Console.WriteLine(car.Owner );

        }
    }

    class Vehicle //:Object
    {
        public string Owner { get; set; }

        public Vehicle(string owner)
        {
            this.Owner = owner;
        }
    }


    class Car:Vehicle
    {
        public Car(string owner):base(owner)
        {
            this.Owner = owner;
        }

        public void ShowOwner()
        {
            Console.WriteLine(Owner);
        }
    }

    //internal class RaceCar : Car
    //{

    //}

}
