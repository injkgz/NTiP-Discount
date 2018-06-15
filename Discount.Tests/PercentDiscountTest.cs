using System;
using NUnit.Framework;

namespace Discount.Tests
{
    [TestFixture]
    public class PercentDiscountTest
    {
        //TODO: Забыл раньше сказать - XML комментарии в тестах писать не нужно.
        //TODO: Тесты должны покрывать всю публичную часть класса!
        //покрывают
        //TODO: Нет.
        /// <summary>
        ///     Позитивное тестирование метода Calculate
        /// </summary>
        /// <param name="price"></param>
        /// <param name="value"></param>
        /// <param name="result"></param>
        [Test]
        [TestCase(1000, 10, 900, TestName = "Проверка " +
                                            "присваивания рандомных значений")]
        [TestCase(2000, 20, 1600, TestName = "Проверка " +
                                             "присваивания рандомных значений")]
        public void PercentCalculateTest(double price, double value, double result)
        {
            var discount = new PercentDiscount(value);
            Assert.That(() => discount.Calculate(price), Is.EqualTo(result));
        }

        /// <summary>
        ///     Негативное тестирование метода Calculate
        /// </summary>
        /// <param name="price"></param>
        /// <param name="value"></param>
        [Test]
        [TestCase(-1, 99, TestName = "Проверка присваивания " +
                                     "некорректного значения price")]
        [TestCase(double.MinValue, 99, TestName = "Проверка присваивания " +
                                                  "минимального значения Double")]
        public void PercentCalculateTestThrows(double price, double value)
        {
            var discount = new PercentDiscount(value);
            Assert.That(() => discount.Calculate(price), Throws.TypeOf<ArgumentException>());
        }

        /// <summary>
        ///     Положительное тестирование конструктора
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Test]
        [TestCase(1, ExpectedResult = 1, TestName = "Проверка присваивания " +
                                                    "минимального логического значения")]
        [TestCase(100, ExpectedResult = 100, TestName = "Проверка присваивания " +
                                                        "максимального логического значения")]
        [TestCase(11, ExpectedResult = 11, TestName = "Проверка " +
                                                      "присваивания значений 11, 11")]
        public double PercentDiscountConstructorTest(double value)
        {
            var discount = new PercentDiscount(value);
            return discount.Percent;
        }

        /// <summary>
        ///     Негативное тестирование конструктора
        /// </summary>
        /// <param name="value"></param>
        [Test]
        [TestCase(0, TestName = "Проверка присваивания 0")]
        [TestCase(-1, TestName = "Проверка присваивания отрицательного значения")]
        [TestCase(101, TestName = "Проверка присваивания значения, " +
                                  "не входящего в логический диапазон")]
        [TestCase(double.MinValue, TestName = "Проверка присваивания " +
                                              "минимального значения Double")]
        [TestCase(double.MaxValue, TestName = "Проверка присваивания " +
                                              "максимального значения Double")]
        public void PercentDiscountConstructorTestThrows(double value)
        {
            Assert.That(() => new PercentDiscount(value), Throws.TypeOf<ArgumentException>());
        }
    }
}