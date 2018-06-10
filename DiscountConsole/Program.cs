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
            //TODO: Этот метод должен просто выполнять корректное считывание в double и всё, он ничего не должен знать про продукт!
            //TODO: А где обработка исключения после ввода некорректной строки для Double?
            //+
            var isCorrectEntering = false;
            double tempValue = -1;
            while (!isCorrectEntering)
            {
                try
                {
                    tempValue = Convert.ToDouble(ReadLine());
                    return tempValue;
                }
                catch (Exception e)
                {
                    WriteLine(e.Message + "\nВведите заново!\n");
                }
            }

            return tempValue;
        }

        /// <summary>
        ///     Корректная инициализация сущности Product
        /// </summary>
        /// <returns></returns>
        private static Product ReadProduct()
        {
            //TODO: Название!
            //+
            var isCorrectInitialization = false;
            var product = new Product();
            while (!isCorrectInitialization)
            {
                try
                {
                    product.Price = ReadDouble();
                    return product;
                }
                catch (Exception e)
                {
                    WriteLine(e.Message + "\nВведите заново!\n");
                }
            }

            return product;
        }

        /// <summary>
        ///     Корректная инициализация сущностей CouponDiscount и PercentDiscount
        /// </summary>
        /// <param name="discountType"></param>
        /// <returns></returns>
        // TODO: Название метода
        // TODO: price не используется!
        // +
        private static DiscountBase ReadDiscount(Discounts discountType)
        {
            //TODO: Название!
            var isCorrectInitialization = false;
            while (!isCorrectInitialization)
            {
                try
                {
                    //TODO: Почему описание вводимого параметра из консоли оторвано от самого ввода?
                    //+
                    double tempValue;
                    switch (discountType)
                    {
                        case Discounts.Coupon:
                        {
                            WriteLine("Введите размер скидки по купону: ");
                            tempValue = ReadDouble();
                            //TODO: Можно сразу return!
                            //+
                            return new CouponDiscount(tempValue);
                        }
                        case Discounts.Percent:
                        {
                            WriteLine("Введите размер скидки в %: ");
                            tempValue = ReadDouble();
                            //TODO: Можно сразу return!
                            //+, почему ReSharper такие вещи не отрабатывает :(
                            return new PercentDiscount(tempValue);
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
            WriteLine("Введите цену первого товара!");
            var product = ReadProduct();
            WriteLine();

            var discount = ReadDiscount(Discounts.Percent);
            WriteLine("Итоговая цена со скидкой в процентах = ");
            WriteLine(discount.Calculate(product.Price));
            WriteLine("\n\n\n");


            WriteLine("Введите цену второго товара!");
            var secondProduct = ReadProduct();


            discount = ReadDiscount(Discounts.Coupon);
            WriteLine("Итоговая цена со скидкой по купону = ");
            WriteLine(discount.Calculate(secondProduct.Price));
            ReadKey();
        }
    }
}