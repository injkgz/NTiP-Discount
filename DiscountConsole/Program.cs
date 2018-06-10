using System;
using Discount;
using static System.Console;

namespace DiscountConsole
{
    internal class Program
    {
        /// <summary>
        ///     Корректное считывание double значения
        /// </summary>
        /// <returns></returns>
        private static double ReadDouble()
        {
            var isCorrectEntering = false;
            while (!isCorrectEntering)
            {
                try
                {
                    return Convert.ToDouble(ReadLine());
                }
                catch (Exception e)
                {
                    WriteLine(e.Message + "\nВведите заново!\n");
                }
            }

            return 0;
        }

        /// <summary>
        ///     Корректная инициализация сущности Product
        /// </summary>
        /// <returns></returns>
        private static Product ReadProduct()
        {
            var isCorrectInitialization = false;
            while (!isCorrectInitialization)
            {
                try
                {
                    return new Product(ReadDouble());
                }
                catch (Exception e)
                {
                    WriteLine(e.Message + "\nВведите заново!\n");
                }
            }

            return null;
        }

        /// <summary>
        ///     Корректная инициализация сущностей CouponDiscount и PercentDiscount
        /// </summary>
        /// <param name="discountType"></param>
        /// <returns></returns>
        private static DiscountBase ReadDiscount(Discounts discountType)
        {
            var isCorrectInitialization = false;
            while (!isCorrectInitialization)
            {
                try
                {
                    switch (discountType)
                    {
                        case Discounts.Coupon:
                        {
                            WriteLine("Введите размер скидки по купону: ");
                            return new CouponDiscount(ReadDouble());
                        }
                        case Discounts.Percent:
                        {
                            WriteLine("Введите размер скидки в %: ");
                            return new PercentDiscount(ReadDouble());
                        }
                    }
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
            WriteLine("Введите цену товара!");
            var product =
                ReadProduct(); //TODO: Почему тут есть WriteLine(), а ниже при создании Product нет? (потому что дубль в коде...)
            //+, так?
            //TODO: Строго говоря - нет. Лабу принял, при встрече - можно обсудить, что тут имелось ввиду.
            WriteLine();

            var discount = ReadDiscount(Discounts.Percent);
            WriteLine("Итоговая цена со скидкой в процентах = ");
            WriteLine(discount.Calculate(product.Price));

            WriteLine("\n\n\n");

            WriteLine("Введите цену товара!");
            product = ReadProduct();
            WriteLine();

            discount = ReadDiscount(Discounts.Coupon);
            WriteLine("Итоговая цена со скидкой по купону = ");
            WriteLine(discount.Calculate(product.Price));
            ReadKey();
        }
    }
}