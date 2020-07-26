using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueObjectsDemo
{
    class Program
    {
        static void Reserve(MoneyAmount cost)
        {
            Console.WriteLine("\nReserving an item that costs {0}.", cost);
        }
        static void Buy(MoneyAmount wallet, MoneyAmount cost)
        {
            bool enoughMoney = wallet.Amount >= cost.Amount;

            Reserve(cost);

            if (enoughMoney)
                Console.WriteLine("You will pay {0} with your {1}.", cost, wallet);
            else
                Console.WriteLine("You cannot pay {0} with your {1}.", cost, wallet);
        }

        static void Main(string[] args)
        {
            Buy(new MoneyAmount() { Amount = 12, CurrencySymbol = "USD"},
                new MoneyAmount() { Amount = 10, CurrencySymbol = "USD" });
            Buy(new MoneyAmount() { Amount = 7, CurrencySymbol = "USD" },
                new MoneyAmount() { Amount = 10, CurrencySymbol = "USD" });

            Console.ReadLine();
        }
    }
}
