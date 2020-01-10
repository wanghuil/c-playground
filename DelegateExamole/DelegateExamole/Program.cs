using System;

namespace DelegateExample
{
    public delegate double Calc(double x, double y);

    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            Calc calc1 = new Calc(calculator.Add);
            Calc calc2 = new Calc(calculator.Sub );
            Calc calc3 = new Calc(calculator.Mul );
            Calc calc4 = new Calc(calculator.Div );

            double a = 100;
            double b = 200;
            double c = 0;

            c = calc1.Invoke(a, b);
            Console.WriteLine(c);
            c = calc2.Invoke(a, b);
            Console.WriteLine(c);
            c = calc3.Invoke(a, b);
            Console.WriteLine(c);
            c = calc4.Invoke(a, b);
            Console.WriteLine(c);


            //ProductFactory productFactory = new ProductFactory();
            IProductFactory pizzaFactory = new PizzaFactory();
            IProductFactory toycarFactory = new ToyCarFactory();
            WrapFactory wrapFactory = new WrapFactory();

            //Func<Product> func1 = new Func<Product>(productFactory.MakePizza);
            //Func<Product> func2 = new Func<Product>(productFactory.MakeToyCar);

            Logger logger = new Logger();
            Action<Product> log = new Action<Product>(logger.Log);

            //Box box1 = wrapFactory.WrapProduct(func1, log);
            //Box box2 = wrapFactory.WrapProduct(func2, log);
            Box box1 = wrapFactory.WrapProduct(pizzaFactory , log);
            Box box2 = wrapFactory.WrapProduct(toycarFactory , log);

            Console.WriteLine(box1.Product.Name);
            Console.WriteLine(box2.Product.Name);


        }
    }

    interface IProductFactory
    {
        Product Make();
    }

    class PizzaFactory : IProductFactory
    {
        public Product Make()
        {
            Product product = new Product();
            product.Name = "Pizza";
            product.Price = 20;
            return product;
        }
    }

    class ToyCarFactory : IProductFactory
    {
        public Product Make()
        {
            Product product = new Product();
            product.Name = "Toy Car";
            product.Price = 100;
            return product;
        }
    }


    class Logger
    {
        public void Log(Product product)
        {
            Console.WriteLine("Product '{0}' created at {1}. Price is {2}.", product.Name, DateTime.UtcNow, product.Price);
        }
    }

    class Calculator
    {
        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Sub(double x, double y)
        {
            return x - y;
        }

        public double Mul(double x, double y)
        {
            return x +y;
        }

        public double Div(double x, double y)
        {
            return x / y;
        }
    }

    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

    }

    class Box
    {
        public Product Product { get; set; }

    }

    class WrapFactory
    {
        //public Box WrapProduct (Func<Product> getProduct, Action<Product> logCallback)
        public Box WrapProduct(IProductFactory productFactory, Action<Product> logCallback)
        {
            Box box = new Box();
            //Product product = getProduct.Invoke();
            Product product = productFactory.Make();
            box.Product = product;
            if (product.Price >= 50)
            {
                logCallback(product);
            }
            box.Product = product;
            return box;
        }
    }

    //class ProductFactory
    //{
    //    public Product MakePizza()
    //    {
    //        Product product = new Product();
    //        product.Name = "Pizza";
    //        product.Price = 20;
    //        return product;
    //    }

    //    public Product MakeToyCar()
    //    {
    //        Product product = new Product();
    //        product.Name = "Toy Car";
    //        product.Price = 100;
    //        return product;
    //    }
    //}


}
