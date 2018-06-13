using System;
using NUnit.Framework;

namespace Discount.Tests
{
    [TestFixture]
    public class PercentDiscountTest
    {
        /// <summary>
        ///     Тестирование метода Calculate
        /// </summary>
        /// <param name="price"></param>
        /// <param name="value"></param>
        /// <param name="result"></param>
        [Test]
        [TestCase(1000, 10, 900)]
        [TestCase(2000, 20, 1600)]
        public void PercentCalculateTest(double price, double value, double result)
        {
            var discount = new PercentDiscount(value);
            Assert.That(() => discount.Calculate(price), Is.EqualTo(result));
        }

        //[Test]
        //[TestCase(1000, 200)]
        //[TestCase(2000, 300)]
        //public void PercentCalculateTest(double price, double value)
        //{
        //    var discount = new PercentDiscount(value);
        //    Assert.That(() => discount.Calculate(price), Throws.TypeOf<ArgumentException>());
        //}

        /// <summary>
        ///     Положительное тестирование конструктора
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Test]
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(100, ExpectedResult = 100)]
        [TestCase(11, ExpectedResult = 11)]
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
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(int.MinValue)]
        [TestCase(int.MaxValue)]
        public void PercentDiscountConstructorTestThrows(double value)
        {
            Assert.That(() => new PercentDiscount(value), Throws.TypeOf<ArgumentException>());
        }
    }
}