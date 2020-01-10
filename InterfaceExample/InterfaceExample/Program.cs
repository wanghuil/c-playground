using System;
using System.Collections;

namespace InterfaceExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            int[] nums1 = new int[] { 1, 2, 3, 4, 5 };
            ArrayList nums2 = new ArrayList { 1, 2, 3, 4, 5 };
            Console.WriteLine(Sum(nums1));
            Console.WriteLine(Avg(nums2));

            var engine = new Engine();
            var car = new Car(engine);
            car.Run(3);
            Console.WriteLine(car.Speed);

            var user = new PhoneUser(new NokiaPhone());
            user.UsePhone();

            var fan = new DeskFan(new PowerSupply());
            Console.WriteLine(fan.Work());
        }



        static int Sum(IEnumerable  nums)
        {
            int sum = 0;
            foreach (var n in nums) { sum += (int)n; }
            return sum;
        }


        static double Avg(IEnumerable  nums)
        {
            int sum = 0; double count = 0;
            foreach (var n in nums) { sum +=(int) n; count++; }
            return sum / count;

        }
    }

    class Engine
    {
        public int RPM { get; private set; }
        public void Work(int gas) { this.RPM = 1000 * gas; }
    }

    class Car
    {
        private Engine _engine;
        public Car(Engine engine)
        {
            _engine = engine;
        }

        public int Speed { get; private set; }
        public void Run(int gas)
        {
            _engine.Work(gas);
            this.Speed = _engine.RPM / 100;
        }
    }
    
    class PhoneUser
    {
        private IPhone _phone;
        public PhoneUser(IPhone phone)
        {
            _phone = phone;
        }

        public void UsePhone()
        {
            _phone.Dail();
            _phone.Pickup();
            _phone.Send();
            _phone.Receive();
        }
    }

    interface IPhone
    {
        void Dail();
        void Pickup();
        void Send();
        void Receive();
    }

    class NokiaPhone : IPhone
    {
        public void Dail()
        {
            Console.WriteLine ("Nokia is calling ...");
        }

        public void Pickup()
        {
            Console.WriteLine("Hello! This is Tim!");
        }

        public void Receive()
        {
            Console.WriteLine("Nokia message ring ...");
        }

        public void Send()
        {
            Console.WriteLine("Hello!");
        }
    }

    class EricssonPhone: IPhone
    {
        public void Dail()
        {
            Console.WriteLine("Ericsson is calling ...");
        }

        public void Pickup()
        {
            Console.WriteLine("Hello! This is Tim!");
        }

        public void Receive()
        {
            Console.WriteLine("Ericsson message ring ...");
        }

        public void Send()
        {
            Console.WriteLine("Hello!");
        }
    }

    public interface IPowerSupply
    {
        int GetPower();

    }
    public class PowerSupply:IPowerSupply 
    {
        public int GetPower()
        {
            return 110;
        }
    }

    public class DeskFan
    {
        private IPowerSupply _powerSupply;
        public DeskFan(IPowerSupply powerSupply)
        {
            _powerSupply = powerSupply;
        }

        public string Work()
        {
            int power = _powerSupply.GetPower();
            if(power <= 0)
            {
                return "Won't Work";
            }else if (power < 100)
            {
                return "Slow";
            }else if(power < 200)
            {
                return "Work fine";
            }
            else
            {
                return "Warning";
            }
        }
    }
}
