using System;
using discount;
using static System.Console;

namespace SalesConsole
{
    internal class main
    {
        private static void Main(string[] args)
        {
            try
            {
                var product = new Product();
                WriteLine("Введите цену товара!");
                product.Price = Convert.ToDouble(ReadLine());

                //WriteLine("Выберите тип скидки!");
                //WriteLine("1 - Процентная " +
                //          "2 - Купон");
                WriteLine();


                var percent = new PercentDiscount();

                WriteLine("Введите размер скидки в %: ");
                percent.Percent = Convert.ToDouble(ReadLine());
                WriteLine("Итоговая цена со скидкой в процентах = ");
                WriteLine(percent.Cost(product.Price));
                WriteLine("\n\n\n");

                var secondProduct = new Product();
                WriteLine("Введите цену товара!");
                secondProduct.Price = Convert.ToDouble(ReadLine());

                var coupon = new CouponDiscount();

                WriteLine("Введите размер скидки по купону: ");
                coupon.CouponValue = Convert.ToDouble(ReadLine());
                WriteLine("Итоговая цена со скидкой по купону = ");
                WriteLine(coupon.Cost(secondProduct.Price));
                Read();
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
                Read();
            }
        }
    }
}