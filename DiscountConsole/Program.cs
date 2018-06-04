using System;
using Discount;
using static System.Console;

namespace DiscountConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //TODO: Название плохое.
            //сменил
            var isException = false;
            var product = new Product();
            var secondProduct = new Product();
            DiscountBase Discount;

            while (!isException)
            {
                //TODO: Зачем?
                //+
                try
                {
                    //TODO: Косяк c RSDN
                    //+
                    WriteLine("Введите цену первого товара!");
                    product.Price = Convert.ToDouble(ReadLine());
                    WriteLine();
                    isException = true;
                }
                catch (Exception e)
                {
                    //TODO: Обработка должно происходить на уровне ввода каждого параметра!
                    //+
                    WriteLine(e.Message + "\nВведите заново!\n\n\n");
                }
            }

            isException = false;
            while (!isException)
            {
                try
                {
                    WriteLine("Введите размер скидки в %: ");
                    //TODO: Бага, ввожу 321 - всё работает.
                    //+
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
                    //TODO: При вводе некорректного числа - нужно будет всё вводить заново - что не правильно.
                    //+
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