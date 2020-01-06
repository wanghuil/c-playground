using System;
using MyLib;
using static MyLib.Classes;

namespace HelloAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Vehicle vehicle = new Vehicle();
            //vehicle.Owner = "Tim";
            //Console.WriteLine(vehicle.Owner);
            Car car = new Car();
            car.Accelerate();
            car.Accelerate();
            Console.WriteLine(car.Speed);
            car.Refuel();
            car.TurboAccelerate();
            Console.WriteLine(car.Speed);
            Bus bus = new Bus();
            bus.SlowAccelerate();
            Console.WriteLine(bus.Speed);
            
        }
    }

    class Bus:Vehicle
    {
        public void SlowAccelerate()
        {
            Burn(1);
            _rpm += 500;
        }
    }
}
