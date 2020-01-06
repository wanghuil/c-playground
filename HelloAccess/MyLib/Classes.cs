using System;
using static MyLib.Classes;

namespace MyLib
{
    public class Classes
    {
        public class Vehicle
        {
            protected int _rpm; //for method //internal protected //private protected
            private int _fuel;
            public void Refuel()
            {
                _fuel = 100;

            }
            protected void Burn(int fuel) 
            {
                _fuel-=fuel;
            }

            internal string Owner { get; set; }
            public void Accelerate()
            {
                Burn(1);
                _rpm += 1000;
            }

            public int Speed { get { return _rpm / 100; } }
        }
    }

    public class Car : Vehicle
    {
        public void ShowOwner()
        {
            Console.WriteLine(Owner);
        }

        public void TurboAccelerate()
        {
            Burn(2);
            _rpm += 3000;

        }
    
    }

}
