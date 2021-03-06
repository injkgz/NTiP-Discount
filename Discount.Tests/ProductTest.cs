﻿using System;
using NUnit.Framework;

namespace Discount.Tests
{
    [TestFixture]
    public class ProductTest
    {
        [Test]
        [TestCase(1, ExpectedResult = 1, TestName = "Проверка " +
                                                    "присваивания минимального логического значения")]
        [TestCase(99999, ExpectedResult = 99999, TestName = "Проверка " +
                                                            "присваивания рандомных значений")]
        [TestCase(1.5, ExpectedResult = 1.5, TestName = "Проверка " +
                                                        "присваивания рандомных значений")]
        public double PriceTest(double value)
        {
            var product = new Product(1) {Price = value};
            return product.Price;
        }

        [Test]
        [TestCase(0, TestName = "Проверка присваивания 0")]
        [TestCase(-1, TestName = "Проверка присваивания отрицательного значения")]
        public void PriceTestThrows(double value)
        {
            var product = new Product(1);
            Assert.That(() => product.Price = value, Throws.TypeOf<Exception>());
        }

        [Test]
        [TestCase(1, ExpectedResult = 1, TestName = "Проверка " +
                                                    "присваивания минимального логического значения")]
        [TestCase(99999, ExpectedResult = 99999, TestName = "Проверка " +
                                                            "присваивания рандомных значений")]
        [TestCase(1.5, ExpectedResult = 1.5, TestName = "Проверка " +
                                                        "присваивания рандомных значений")]
        public double ProductConstructorTest(double value)
        {
            var product = new Product(value);
            return product.Price;
        }

        [Test]
        [TestCase(0, TestName = "Проверка присваивания 0")]
        [TestCase(-1, TestName = "Проверка присваивания отрицательного значения")]
        public void ProductConstructorThrows(double value)
        {
            Assert.That(() => new Product(value), Throws.TypeOf<Exception>());
        }
    }
}