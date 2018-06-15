using System;
using NUnit.Framework;

namespace Discount.Tests
{
    [TestFixture]
    public class СouponDiscountTest
    {
        //TODO: Тесты должны покрывать всю публичную часть класса!
        /// <summary>
        ///     Положительное тестирование конструктора сущности CouponDiscount
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Test]
        [TestCase(1, ExpectedResult = 1, TestName = "Проверка " +
                                                    "присваивания рандомных значений")]
        [TestCase(100, ExpectedResult = 100, TestName = "Проверка " +
                                                        "присваивания рандомных значений")]
        [TestCase(11, ExpectedResult = 11, TestName = "Проверка " +
                                                      "присваивания рандомных значений")]
        public double CouponDiscountConstructorTest(double value)
        {
            var discount = new CouponDiscount(value);
            return discount.CouponValue;
        }

        /// <summary>
        ///     Негативное тестирование конструктора сущности CouponDiscount
        /// </summary>
        /// <param name="value"></param>
        [Test]
        [TestCase(-1, TestName = "Проверка присваивания отрицательных значений")]
        [TestCase(double.MinValue, TestName = "Проверка присваивания " +
                                              "минимального значения Double")]
        public void CouponDiscountConstructorTestThrows(double value)
        {
            Assert.That(() => new CouponDiscount(value), Throws.TypeOf<ArgumentException>());
        }

        /// <summary>
        ///     Тестирование метода Calculate
        /// </summary>
        /// <param name="price"></param>
        /// <param name="value"></param>
        /// <param name="result"></param>
        [Test]
        [TestCase(1000, 10, 990, TestName = "Проверка " +
                                            "присваивания рандомных значений")]
        [TestCase(2000, 2020, 0, TestName = "Проверка " +
                                            "присваивания рандомных значений")]
        public void PercentCalculateTest(double price, double value, double result)
        {
            var discount = new CouponDiscount(value);
            Assert.That(() => discount.Calculate(price), Is.EqualTo(result));
        }
    }
}