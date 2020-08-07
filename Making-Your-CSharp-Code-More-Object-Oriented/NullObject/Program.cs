 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    class Program
    {
        static void ClaimWarranty(SoldArticle article)
        {
            DateTime now = DateTime.Now;

            if (article.MoneyBackGuarantee.IsValidOn(now))
            {
                Console.WriteLine("Offer money back.");
            }

            if (article.ExpressWarranty.IsValidOn(now))
            {
                Console.WriteLine("Offer repair.");
            }
        }
        static void Main(string[] args)
        {
            DateTime sellingDate = new DateTime(2020, 8, 6);
            TimeSpan moneyBackSpan = TimeSpan.FromDays(30);
            TimeSpan warrantySpan = TimeSpan.FromDays(365);

            IWarranty moneyBack = new TimeLimitedWarranty(sellingDate, moneyBackSpan);
            IWarranty warranty = new TimeLimitedWarranty(sellingDate, warrantySpan);

            //IWarranty noMoneyBack = VoidWarranty.Instance;
            IWarranty lifetimeWarranty = new LifetimeWarranty(sellingDate);
            SoldArticle goods = new SoldArticle(VoidWarranty.Instance, lifetimeWarranty);

            ClaimWarranty(goods);

            Console.ReadLine();
        }
    }
}
