using System;
using Discount;
using static System.Console;

namespace DiscountConsole
{
    /// <summary>
    ///     Типы скидок
    /// </summary>
    public enum Discounts
    {
        Percent,
        Coupon
    }

    internal class Program
    {
        //TODO: XML
        //+
        /// <summary>
        ///     Корректное считывание стоимости товара
        /// </summary>
        /// <returns></returns>
        private static double ReadPrice()
        {
            //TODO: Этот метод должен просто выполнять корректное считывание в double и всё, он ничего не должен знать про продукт!
            //+
            var isException = false;
            var product = new Product();
            while (!isException)
            {
                try
                {
                    product.Price = Convert.ToDouble(ReadLine());
                    isException = true;
                }
                catch (Exception e)
                {
                    WriteLine(e.Message + "\nВведите заново!\n");
                }
            }

            return product.Price;
        }

        //TODO: Использовать bool - тупо, под тип скидки нужно завести enum
        //+
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
            var isException = false;
            while (!isException)
            {
                try
                {
                    var tempValue = Convert.ToDouble(ReadLine());
                    switch (discountType)
                    {
                        case Discounts.Coupon:
                        {
                            var couponDiscount = new CouponDiscount(tempValue, tempPrice);
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
            var product = new Product();
            var secondProduct = new Product();

            WriteLine("Введите цену первого товара!");
            product.Price = ReadPrice();
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
            secondProduct.Price = ReadPrice();


            WriteLine("Введите размер скидки по купону: ");
            discount = TrueConstruct(Discounts.Coupon, secondProduct.Price);
            WriteLine("Итоговая цена со скидкой по купону = ");
            WriteLine(discount.Calculate(secondProduct.Price));
            ReadKey();
        }
    }
}