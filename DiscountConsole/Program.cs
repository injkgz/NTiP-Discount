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
            //+
            return Convert.ToDouble(ReadLine());
        }

        private static Product ReadProduct()
        {
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
        private static DiscountBase TrueConstruct(Discounts discountType, double tempPrice)
        {
            //TODO: Тут уже для ввода каждого параметра нужно вызвать метод TrueRead
            //метод был переделан только для считывания цены.
            var isCorrectConstruct = false;
            while (!isCorrectConstruct)
            {
                try
                {
                    var tempValue = ReadDouble();
                    switch (discountType)
                    {
                        case Discounts.Coupon:
                        {
                            var couponDiscount = new CouponDiscount(tempValue);
                            return couponDiscount;
                        }
                        case Discounts.Percent:
                        {
                            var percentDiscount = new PercentDiscount(tempValue);
                            return percentDiscount;
                        }
                    }

                    //TODO: Это место не будет достигнуто программой
                    //+
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
            //TODO: Лучше сделать 2 метода для ввода параметров каждого из типов скидки или совместить всё это в один метод
            //TODO: Но возвращать по базовому классу, чтобы в Main не было понятно - с какой реализацией мы работаем
            //у меня так и сделано, один метод, возвращается по базовому классу...
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