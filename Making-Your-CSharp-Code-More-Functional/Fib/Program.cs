using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fib
{
    class Program
    {
        static long NaiveFibonacci(int n) => n < 2 ? n : NaiveFibonacci(n-1) + NaiveFibonacci(n-2);

        static void Demonstrate(Func<int, long> fibonacci)
        {
            for (int i=0;i<10;i++)
                Console.WriteLine($"{i}\t{fibonacci(i)}");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Demonstrate(NaiveFibonacci);
            Console.ReadLine();
        }
    }
}
