using System;
using NUnit.Framework;

namespace Discount.Tests
{
    [TestFixture]
    public class CheckPositionTest
    {
        //TODO: Тесты должны покрывать всю публичную часть класса!
        /// <summary>
        ///     Негативное тестирование конструктора CheckPosition
        /// </summary>
        /// <param name="discount"></param>
        /// <param name="product"></param>
        [Test]
        [TestCase(null, null, TestName = "Проверка передачи null значений")]
        public void CheckPositionConstructorTest(DiscountBase discount, Product product)
        {
            Assert.That(() => new CheckPosition(discount, product), Throws.TypeOf<ArgumentException>());
        }
    }
}