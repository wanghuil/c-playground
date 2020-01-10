using System;
using System.Collections;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace IspExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            var driver = new Driver(new HeavyTank ());
            driver.Drive();
            int[] nums1 = { 1, 2, 3, 4, 5 };
            ArrayList nums2 = new ArrayList { 1, 2, 3, 4, 5 };
            Console.WriteLine(Sum(nums1));
            Console.WriteLine(Sum(nums2));

            var roc = new ReadOnlyCollection(nums1);
            Console.WriteLine(Sum(roc));
            //foreach(var n in roc)
            //{
            //    Console.WriteLine(n);
            //}

            IKiller killer = new WarmKiller();
            killer.Kill();
            //var wk =killer as WarmKiller;
            var wk = (IGentleman)killer;
            wk.Love();

            ITank tank = new HeavyTank();
            var t = tank.GetType();
            object o = Activator.CreateInstance(t);
            MethodInfo fireMi = t.GetMethod("Fire");
            MethodInfo runMi = t.GetMethod("Run");
            fireMi.Invoke(o,null);
            runMi.Invoke(o, null); //reflection



            var sc = new ServiceCollection();
            sc.AddScoped(typeof(ITank), typeof(HeavyTank));
            sc.AddScoped(typeof(IVehicle), typeof(LightTank));
            sc.AddScoped<Driver>();
            var sp = sc.BuildServiceProvider();
            var driver1 = sp.GetService<Driver>();
            driver1.Drive();

            ITank tank1 = sp.GetService<ITank>();
            tank1.Fire();
            tank1.Run();



        }

        static int Sum(IEnumerable nums)
            {
                int sum = 0;
                foreach (var n in nums)
                {
                    sum += (int)n;
                }
                return sum;
            }
        
    }

    public class ReadOnlyCollection : IEnumerable
    {
        public int[] _array;

        public ReadOnlyCollection (int[] array)
        {
            _array = array;
        }
        public IEnumerator GetEnumerator()
        {
            return new Enumerator(this);
        }
    }

    public class Enumerator : IEnumerator
    {
        private ReadOnlyCollection _collection;
        private int _head;

        public Enumerator(ReadOnlyCollection collection)
        {
            _collection = collection;
            _head = -1;

        }
        public object Current
        {
            get
            {
                object o = _collection._array[_head];
                return o;
            }
        }

        public bool MoveNext()
        {
            if(++_head < _collection._array.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            _head = -1;
        }
    }
    class Driver
    {
        private IVehicle _vehicle;
        public Driver (IVehicle vehicle)
        {
            _vehicle = vehicle;
        }

        public void Drive()
        {
            _vehicle.Run();
        }
    }

    interface IVehicle
    {
        void Run();
    }

    interface IWeapon
    {
        void Fire();
    }

    class Car : IVehicle
    {
        public void Run()
        {
            Console.WriteLine("Car is running ...");
        }
    }

    class Truck : IVehicle
    {
        public void Run()
        {
            Console.WriteLine("Truck is running ...");
        }

    }

    interface ITank:IVehicle, IWeapon 
    {
        void Fire();
        void Run();
    }

    class LightTank : ITank
    {
        public void Fire()
        {
            Console.WriteLine("Boom!");
        }

        public void Run()
        {
            Console.WriteLine("Ka ka ka ...");
        }
    }

    class MediumTank : ITank
    {
        public void Fire()
        {
            Console.WriteLine("Boom!!");
        }

        public void Run()
        {
            Console.WriteLine("Ka! ka! ka! ...");
        }
    }

    class HeavyTank : ITank
    {
        public void Fire()
        {
            Console.WriteLine("Boom!!!");
        }

        public void Run()
        {
            Console.WriteLine("Ka!! ka!! ka!! ...");
        }
    }

    interface IGentleman
    {
        void Love();
    }

    interface IKiller
    {
        void Kill();
    }

    class WarmKiller : IGentleman, IKiller
    {


        public void Love()
        {
            Console.WriteLine("I will love you for ever...");
        }

        void IKiller.Kill()
        {
            Console.WriteLine("Let me kill the enemy...");
        }
    }
}
