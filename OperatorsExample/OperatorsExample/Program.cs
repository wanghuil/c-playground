using System;

namespace OperatorsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new { Name = "Mr.Okay", Age = 34 };
            Console.WriteLine(person.Age);

            uint x = uint.MaxValue;
            checked
            {
                try
                {
                    //uint y = checked(x + 1);
                    uint y = x + 1;
                    Console.WriteLine(y);
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine("There is overflow!");
                }
            }

            unsafe
            {
                Student stu;
                stu.ID = 1;
                stu.Score = 99;
                Student* pStu = &stu;
                pStu->Score = 100;
                (*pStu).Score = 101;
                Console.WriteLine(stu.Score);
            
            }

            Stone stone = new Stone();
            stone.Age = 5000;
            //Monkey wukongSun = (Monkey)stone;  for explicit
            Monkey wukongSun = stone; //implict
            Console.WriteLine(wukongSun.Age);


            int x1 = 7;
            int y1 = 28;
            int z1 = x1 ^ y1;
            String strX = Convert.ToString(x1, 2).PadLeft(32, '0');
            String strY = Convert.ToString(y1, 2).PadLeft(32, '0');
            String strZ = Convert.ToString(z1, 2).PadLeft(32, '0');
            Console.WriteLine(strX);
            Console.WriteLine(strY);
            Console.WriteLine(strZ);

            if (x1>y1 && x1++>8) //skip x1++, better avoid
            {
                Console.WriteLine("Hello");
            }
            Console.WriteLine(x1);

            Nullable<int> x2 = null; //int? x2 = null;
            int y2 = x2 ?? 1;
            string str = (x2 >= 60) ? "Pass" : "Failed";
            Console.WriteLine(x2);

        }
    }

    struct Student { public int ID; public int Score; }

    class Monkey { public int Age; }
    
    class Stone { 
        public int Age;

        public static implicit operator Monkey (Stone stone)
        {
            Monkey m = new Monkey();
            m.Age = stone.Age / 500;
            return m;
        }

    }
}
