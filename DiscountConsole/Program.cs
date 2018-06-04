using System;
using Discount;
using static System.Console;

namespace DiscountConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var isException = false;
            var product = new Product();
            var secondProduct = new Product();
//TODO: Косяк c RSDN
            DiscountBase Discount;
            //TODO: Итого - 4 почти полных дубля...
            while (!isException)
            {
                try
                {
                    WriteLine("Введите цену первого товара!");
                    product.Price = Convert.ToDouble(ReadLine());
                    WriteLine();
                    isException = true;
                }
                catch (Exception e)
                {
                    WriteLine(e.Message + "\nВведите заново!\n\n\n");
                }
            }

            isException = false;
            while (!isException)
            {
                try
                {
                    WriteLine("Введите размер скидки в %: ");
                    Discount = new PercentDiscount(Convert.ToDouble(ReadLine()));
                    WriteLine("Итоговая цена со скидкой в процентах = ");
                    WriteLine(Discount.Calculation(product.Price));
                    WriteLine("\n\n\n");
                    isException = true;
                }
                catch (Exception e)
                {
                    WriteLine(e.Message + "\nВведите заново!\n\n\n");
                }
            }
                
            isException = false;
            while (!isException)
            {
                try
                {
                    WriteLine("Введите цену второго товара!");
                    secondProduct.Price = Convert.ToDouble(ReadLine());
                    isException = true;
                }
                catch (Exception e)
                {
                    WriteLine(e.Message + "\nВведите заново!\n\n\n");
                }
            }

            isException = false;
            while (!isException)
            {
                try
                {
                    WriteLine("Введите размер скидки по купону: ");
                    Discount = new CouponDiscount(Convert.ToDouble(ReadLine()));
                    WriteLine("Итоговая цена со скидкой по купону = ");
                    WriteLine(Discount.Calculation(secondProduct.Price));
                    ReadKey();
                    isException = true;
                }
                catch (Exception e)
                {
                    WriteLine(e.Message + "\nВведите заново!\n\n\n");
                }
            }
        }
    }
}