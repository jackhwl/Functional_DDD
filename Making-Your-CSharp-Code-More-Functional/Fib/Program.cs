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
            for (int i=0;i<3;i++)
                Console.WriteLine($"{offset+i}\t{fibonacci(offset+i)}");
            Console.WriteLine();
        }

        static IList<long> dynamicCache = new List<long>() {0, 1};
        static long DynamicFibonacci (int n)
        {
            while(dynamicCache.Count <= n)
            {
                dynamicCache.Add(-1);
            }

            if (dynamicCache[n] < 0)
            {
                dynamicCache[n] = n < 2 ? n : DynamicFibonacci(n - 1) + DynamicFibonacci(n - 2);
            }

            return dynamicCache[n];
        }

        static IList<long> forwardCache = new List<long>() { 0, 1 };
        static long ForwardFibonacci(int n)
        {
            while (forwardCache.Count <= n)
            {
                forwardCache.Add(forwardCache[forwardCache.Count - 1] + forwardCache[forwardCache.Count - 2]);
            }

            return forwardCache[n];
        }

        static long QuickFibonacci(int n)
        {
            if (n < 2) return n;

            long a = 0;
            long b = 1;

            for (int k = 2; k <= n; k++)
            {
                long c = a + b;
                a = b;
                b = c;
            }    

            return b;
        }

        static IDictionary<int, long> dynamicCache2 = new Dictionary<int, long>();
        static long DynamicFibonacci2(int n)
        {
            long value;
            if (!dynamicCache2.TryGetValue(n, out value))
            {
                value = n < 2 ? n : DynamicFibonacci2(n - 1) + DynamicFibonacci2(n - 2);
                dynamicCache2[n] = value;
            }

            return value;
        }
        static void Main(string[] args)
        {
            Demonstrate(NaiveFibonacci);

            Demonstrate(DynamicFibonacci);

            Demonstrate(ForwardFibonacci);

            Demonstrate(QuickFibonacci);

            Demonstrate(DynamicFibonacci2);

            Console.ReadLine();
        }
    }
}
