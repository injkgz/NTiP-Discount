using System;
using NUnit.Framework;

namespace Discount.Tests
{
    [TestFixture]
    public class PercentDiscountTest
    {
        [Test]
        [TestCase(11, ExpectedResult = "Скидка по процентам",
            TestName = "Проверка корректного возвращения Description")]
        public string DescriptionTest(double value)
        {
            var discount = new PercentDiscount(value);
            return discount.Description;
        }

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

        [Test]
        [TestCase(11, ExpectedResult = 11, TestName = "Проверка корректного возвращения Percent")]
        public double PercentTest(double value)
        {
            var discount = new PercentDiscount(value);
            return discount.Percent;
        }

        [Test]
        [TestCase(11, ExpectedResult = 11, TestName = "Проверка корректного возвращения Value")]
        public double ValueTest(double value)
        {
            var discount = new PercentDiscount(value);
            return discount.Value();
        }
    }
}