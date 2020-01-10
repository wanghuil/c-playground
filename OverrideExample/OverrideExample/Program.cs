using System;

namespace OverrideExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            var car = new Car();
            car.Run();
            var v = new Car();
           // var v = new Vehicle();
            v.Run();
            Console.WriteLine(v.Speed);
        }
    }

    class Vehicle
    {
        public int _speed;
        public virtual int Speed { get { return _speed; } set { _speed = value; } }
        public virtual void Run()
        {
            Console.WriteLine("I am running!");
        }
    }

    class Car :Vehicle
    {
        public int _rpm;
        public override int Speed { get { return _rpm / 100; } set { _rpm = value * 100; } }
        public override void Run()
        {
            _rpm = 5000;
            Console.WriteLine("Car is running!");
        }
    }

    class RaseCar : Car
    {
        public override void Run() //public void Run(){} then Rasecar rc = new RaseCar();
        {
            Console.WriteLine("RaseCar is running!");
        }
    }
}
