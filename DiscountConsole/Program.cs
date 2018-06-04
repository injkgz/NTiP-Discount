using System;
using Discount;
using static System.Console;

namespace DiscountConsole
{
    internal class Program
    {
        private static double TrueRead(Product tempProduct)
        {
            var isException = false;
            while (!isException)
            {
                try
                {
                    tempProduct.Price = Convert.ToDouble(ReadLine());
                    isException = true;
                }
                catch (Exception e)
                {
                    WriteLine(e.Message + "\nВведите заново!\n");
                }
            }

            return tempProduct.Price;
        }

        //discountType = true - Процентная скидка
        //discountType = false - Скидка по купону
        private static DiscountBase TrueConstruct(bool discountType, double tempPrice)
        {
            double tempValue;
            PercentDiscount percentDiscount;
            CouponDiscount couponDiscount;
            var isException = false;
            while (!isException)
            {
                try
                {
                    tempValue = Convert.ToDouble(ReadLine());
                    if (discountType)
                    {
                        percentDiscount = new PercentDiscount(tempValue);
                        return percentDiscount;
                    }

                    couponDiscount = new CouponDiscount(tempValue, tempPrice);
                    return couponDiscount;
                    isException = true;
                }
                catch (Exception e)
                {
                    WriteLine(e.Message + "\nВведите заново!\n");
                }
            }

            return null;
        }

        private static void Main(string[] args)
        {
            var product = new Product();
            var secondProduct = new Product();
            //TODO: Косяк c RSDN
            //переменная с нижнего регистра? или где-то в другом месте косяк?
            //TODO: Итого - 4 почти полных дубля...
            //сделано.

            WriteLine("Введите цену первого товара!");
            product.Price = TrueRead(product);
            WriteLine();

            WriteLine("Введите размер скидки в %: ");
            var discount = TrueConstruct(true, 0);
            WriteLine("Итоговая цена со скидкой в процентах = ");
            WriteLine(discount.Calculate(product.Price));
            WriteLine("\n\n\n");


            WriteLine("Введите цену второго товара!");
            secondProduct.Price = TrueRead(secondProduct);


            WriteLine("Введите размер скидки по купону: ");
            discount = TrueConstruct(false, secondProduct.Price);
            WriteLine("Итоговая цена со скидкой по купону = ");
            WriteLine(discount.Calculate(secondProduct.Price));
            ReadKey();
        }
    }
}