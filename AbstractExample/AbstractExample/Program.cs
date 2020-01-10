using System;

namespace AbstractExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Vehicle v = new Truck();
            v.Run();
        }
    }
    
    //abstract class VehicleBase
    //{
    //    abstract public void Stop();
    //    abstract public void Fill();
    //    abstract public void Run();
    //}

    interface IVehicle
    {
        void Stop();
        void Fill();
        void Run();

    }

    abstract class Vehicle : IVehicle
    {
    

        public void Stop()
        {
            Console.WriteLine("Stopped!");
        }

        public void Fill()
        {
            Console.WriteLine("Pay and fill ...");
        }

        abstract public void Run();
    }

    class Truck: Vehicle 
    {
        public override void Run()
        {
            Console.WriteLine("Turck is running ...");
        }

        //public void Stop()
        //{
        //    Console.WriteLine("Stopped!");
        //}
    }

    class Car : Vehicle
    {
        public override void Run()
        {
            Console.WriteLine("Car is running ...");
        }

        //public void Stop()
        //{
        //    Console.WriteLine("Stopped!");
        //}
    }

    class RaceCar : Vehicle
    {
        public override void Run()
        {
            Console.WriteLine("Race car is running ...");
        }

        //public void Stop()
        //{
        //    Console.WriteLine("Stopped!");
        //}
    }

}
