using System;
namespace Fun
{
    internal class Program
    {
        public static void Main(string[] args)
        
        { int fun(int n)
            {

                if (n < 2) return n;

                if (n % 2 == 0) return fun(n - 1) + 1;

                else return fun(n - 1);
            }

            Console.WriteLine("Fun 6  ->" + fun(6));
            Console.WriteLine("Fun 7  ->" + fun(7));
            Console.WriteLine("Fun 8  ->" + fun(8));
        }
    }
}