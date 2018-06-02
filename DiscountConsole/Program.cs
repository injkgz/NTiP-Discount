using System;
using Discount;
using static System.Console;

namespace DiscountConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var isTrue = false;
            while (!isTrue)
            {
                isTrue = false;
                try
                {
                    DiscountBase discount;
                    var product = new Product();
                    WriteLine("Введите цену первого товара!");
                    product.Price = Convert.ToDouble(ReadLine());
                    WriteLine();

                    WriteLine("Введите размер скидки в %: ");
                    discount = new PercentDiscount(Convert.ToDouble(ReadLine()));
                    WriteLine("Итоговая цена со скидкой в процентах = ");
                    WriteLine(discount.Calculation(product.Price));
                    WriteLine("\n\n\n");

                    var secondProduct = new Product();
                    WriteLine("Введите цену второго товара!");
                    secondProduct.Price = Convert.ToDouble(ReadLine());
                    WriteLine("Введите размер скидки по купону: ");
                    discount = new CouponDiscount(Convert.ToDouble(ReadLine()));
                    WriteLine("Итоговая цена со скидкой по купону = ");
                    WriteLine(discount.Calculation(secondProduct.Price));
                    ReadKey();
                    isTrue = true;
                }
                catch (Exception e)
                {
                    WriteLine(e.Message + "\nПрограмма запущена заново!\n\n\n");
                }
            }
        }
    }
}