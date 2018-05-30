using System;
using discount;
using static System.Console;

namespace SalesConsole
{
    class main
    {
        static void Main(string[] args)
        {
            try
            {
                Product product = new Product();
                WriteLine("Введите цену товара!");
                product.Price = Convert.ToDouble(ReadLine());

                WriteLine("Выберите тип скидки!");
                WriteLine("1 - Процентная " +
                          "2 - Купон");
                WriteLine();
                

                PercentDiscount percent = new PercentDiscount();

                WriteLine("Введите размер скидки в %: ");
                percent.Percent = Convert.ToDouble(ReadLine());
                WriteLine(percent.Cost(product.Price));

                Product secondProduct = new Product();
                WriteLine("Введите цену товара!");
                secondProduct.Price = Convert.ToDouble(ReadLine());

                CouponDiscount coupon = new CouponDiscount();

                WriteLine("Введите размер скидки по купону: ");
                coupon.CouponValue = Convert.ToDouble(ReadLine());
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
