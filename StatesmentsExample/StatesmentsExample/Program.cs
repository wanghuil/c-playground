using System;

namespace StatesmentsExample
{
    class Program
    {

        static void Main(string[] args)
        {


            string input = Console.ReadLine();
            try
            {
                int score = int.Parse(input);
                //if (score >= 0 && score <= 100)
                //{
                //    if (score >= 60)
                //    {
                //        if (score >= 80)
                //        {
                //            Console.WriteLine("A");
                //        }
                //        else
                //        {
                //            Console.WriteLine("B");
                //        }
                //    }
                //    else
                //    {
                //        if (score >= 40)
                //        {
                //            Console.WriteLine("C");
                //        }
                //        else
                //        {
                //            Console.WriteLine("D");
                //        }

                //    }
                //}
                //else
                //{
                //    Console.WriteLine("input error!");
                //}

                switch (score / 10)
                {
                    case 10:
                        if (score == 100)
                        {
                            goto case 9;
                        }
                        else
                        {
                            goto default;
                        }
                    case 8:
                    case 9:
                        Console.WriteLine("A");
                        break;
                    case 6:
                    case 7:
                        Console.WriteLine("B");
                        break;
                    case 4:
                    case 5:
                        Console.WriteLine("C");
                        break;
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        Console.WriteLine("D");
                        break;
                    default:
                        Console.WriteLine("input error!");
                        break;
                }



            }
            catch (Exception)
            {

                throw;
            }


            Calculator c = new Calculator();
            int r = 0;
            try
            {
                r = c.Add("9999999999999", "200");
            }
            catch (OverflowException oe)
            {
                Console.WriteLine(oe.Message);
                
            }

            Console.WriteLine(r);
        }


    }


    class Calculator
    {
        public int Add(string arg1, string arg2)
        {
            int a = 0;
            int b = 0;
            bool hasError = false;
            try
            {
                a = int.Parse(arg1);
                b = int.Parse(arg2);
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine("Your argument(s) are null!");
                Console.WriteLine(ane.Message);
                hasError = true;
                //throw;
            }
            catch(FormatException)
            {
                Console.WriteLine("Your argument(s) are not number!");
                hasError = true;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Your argument(s) are not numberstyle value.");
                hasError = true;
            }
            catch(OverflowException)
            {
                hasError = true;
                throw;
            }
            finally
            {
                if (hasError )
                {
                    Console.WriteLine("Excution has error!");
                }
                else
                {
                    Console.WriteLine("Done!");
                }
            }
            int result = a + b;
            return result;

            
        }
    }
}
