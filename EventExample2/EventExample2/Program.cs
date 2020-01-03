using System;
using System.Threading;

namespace EventExample2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            Customer customer = new Customer();
            Waiter waiter = new Waiter();
            customer.Order += waiter.Action;
            customer.Action();

            //bad guy example
            //OrderEventArgs e = new OrderEventArgs();
            //e.DishName = "Manhanquanxi";
            //e.Size = "large";

            //OrderEventArgs e2 = new OrderEventArgs();
            //e2.DishName = "beer";
            //e2.Size = "large";

            //Customer badGuy = new Customer();
            //badGuy.Order += waiter.Action;
            //badGuy.Order.Invoke(customer, e);
            //badGuy.Order.Invoke(customer, e2);

            customer.PayTheBill();



        }
    }

    public class OrderEventArgs:EventArgs 
    {
        public string DishName { get; set; }
        public string Size { get; set; }
    }

    public delegate void OrderEventHandler(Customer customer, OrderEventArgs e);

    public class Customer
    {
        //private OrderEventHandler orderEventHandler;
        //public event OrderEventHandler Order;
        //public OrderEventHandler Order;
        public event EventHandler Order;

        //public event OrderEventHandler Order
        //{
        //    add
        //    {
        //        this.orderEventHandler += value;
        //    }

        //    remove
        //    {
        //        this.orderEventHandler -= value;
        //    }
        //}
        public double Bill { get; set; }

        public void PayTheBill()
        {
            Console.WriteLine("I will pay ${0}.", this.Bill);
        }

        public void WalkIn()
        {
            Console.WriteLine("Walk into the restuarant.");
        }

        public void SitDown()
        {
            Console.WriteLine("Sit down.");
        }

        public void Think()
        {
            for(int i=0; i<5; i++)
            {
                Console.WriteLine("Let me think...");
                Thread.Sleep(1000);
            }

            this.OnOrder("Kongbaochicken","large");
        }

        protected void OnOrder(string dishName, string size)
        {
            //if(this.orderEventHandler != null)
            if (this.Order != null)
            {
                OrderEventArgs e = new OrderEventArgs();
                //e.DishName = "Kongpao Chicken";
                e.DishName = dishName;
                //e.Size = "large";
                e.Size = size;
                //this.orderEventHandler.Invoke(this, e);
                this.Order.Invoke(this, e);
            }
        }

        public void Action()
        {
            Console.ReadLine(); //press enter
            this.WalkIn();
            this.SitDown();
            this.Think();

        }
    }



    public class Waiter
    {
        // public void Action(Customer customer, OrderEventArgs e)
        public void Action(object sender, EventArgs orderInfo)
        {
            Customer customer = sender as Customer;
            OrderEventArgs e = orderInfo as OrderEventArgs;

            Console.WriteLine("I will serve you the dish -{0}.", e.DishName);
            double price = 10;
            switch (e.Size )
            {
                case "small":
                    price = price * 0.5;
                    break;
                case "large":
                    price = price * 1.5;
                    break;
                default:
                    break;
            }

            customer.Bill += price;
        }
    }
}
