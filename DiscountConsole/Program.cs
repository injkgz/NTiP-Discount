using System;
using Discount;
using static DiscountConsole.DiscountsEnum;
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
            return Convert.ToDouble(ReadLine());
        }

        private static Product ReadProduct()
        {
            //TODO: Название!
            var isCorrectConstruct = false;
            var product = new Product();
            while (!isCorrectConstruct)
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
        /// <param name="tempPrice"></param>
        /// <returns></returns>
        /// TODO: Название метода
        /// TODO: price не используется!
        private static DiscountBase TrueConstruct(Discounts discountType, double tempPrice)
        {
            //TODO: Название!
            var isCorrectConstruct = false;
            while (!isCorrectConstruct)
            {
                try
                {
                    //TODO: Почему описание вводимого параметра из консоли оторвано от самого ввода?
                    var tempValue = ReadDouble();
                    switch (discountType)
                    {
                        case Discounts.Coupon:
                        {
                            //TODO: Можно сразу return!
                            var couponDiscount = new CouponDiscount(tempValue);
                            return couponDiscount;
                        }
                        case Discounts.Percent:
                        {
                            //TODO: Можно сразу return!
                            var percentDiscount = new PercentDiscount(tempValue);
                            return percentDiscount;
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
            
            WriteLine("Введите размер скидки в %: ");
            var discount = TrueConstruct(Discounts.Percent, 0);
            WriteLine("Итоговая цена со скидкой в процентах = ");
            WriteLine(discount.Calculate(product.Price));
            WriteLine("\n\n\n");


            WriteLine("Введите цену второго товара!");
            var secondProduct = ReadProduct();


            WriteLine("Введите размер скидки по купону: ");
            discount = TrueConstruct(Discounts.Coupon, secondProduct.Price);
            WriteLine("Итоговая цена со скидкой по купону = ");
            WriteLine(discount.Calculate(secondProduct.Price));
            ReadKey();
        }
    }
}