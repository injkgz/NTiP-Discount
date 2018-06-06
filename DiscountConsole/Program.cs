using System;
using Discount;
using static System.Console;

namespace DiscountConsole
{
    internal class Program
    {
        //TODO: XML
        private static double TrueRead(Product tempProduct)
        { //TODO: Этот метод должен просто выполнять корректное считывание в double и всё, он ничего не должен знать про продукт!
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

        //TODO: Использовать bool - тупо, под тип скидки нужно завести enum
        //discountType = true - Процентная скидка
        //discountType = false - Скидка по купону
        private static DiscountBase TrueConstruct(bool discountType, double tempPrice)
        {//TODO: Тут уже для ввода каждого параметра нужно вызвать метод TrueRead
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
                    //TODO: Это место не будет достигнуто программой
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

            WriteLine("Введите цену первого товара!");
            product.Price = TrueRead(product);
            WriteLine();
            //TODO: Лучше сделать 2 метода для ввода параметров каждого из типов скидки или совместить всё это в один метод
            //TODO: Но возвращать по базовому классу, чтобы в Main не было понятно - с какой реализацией мы работаем
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