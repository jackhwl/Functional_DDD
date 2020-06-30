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
            int offset = 30;
            for (int i=0;i<10;i++)
                Console.WriteLine($"{offset+i}\t{fibonacci(offset+i)}");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Demonstrate(NaiveFibonacci);
            Console.ReadLine();
        }
    }
}
