using System;
using DiscountForms;
using NUnit.Framework;

namespace Discount.Tests
{
    [TestFixture]
    public class CheckPositionTest
    {
        //TODO: XML убрать
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

        [Test]
        [TestCase(100, Discounts.Coupon, 100, ExpectedResult = 0,
            TestName = "Проверка корректного Get у CheckPositionDiscount")]
        [TestCase(100, Discounts.Percent, 100, ExpectedResult = 0,
            TestName = "Проверка корректного Get у CheckPositionDiscount")]
        public double CheckPositionDiscountTest(double price, Discounts type, double value)
        {
            var checkPosition = new CheckPosition(DiscountFactory.GetDiscount(type, value),
                new Product(price));
            return checkPosition.CheckPositionDiscount;
        }

        [Test]
        [TestCase(100, ExpectedResult = 100, TestName = "Проверка корректного get у CheckPositionPrice")]
        public double CheckPositionPriceTest(double value)
        {
            var discount = DiscountFactory.GetDiscount(Discounts.Coupon, 11);
            var product = new Product(value);
            var checkPosition = new CheckPosition(discount, product);
            return checkPosition.CheckPositionPrice;
        }

        [Test]
        [TestCase(Discounts.Coupon, TestName = "Проверка корректного get у DiscountBase")]
        [TestCase(Discounts.Percent, TestName = "Проверка корректного get у DiscountBase")]
        public void DiscountBaseTest(Discounts type)
        {
            switch (type)
            {
                case Discounts.Coupon:
                {
                    var discount = DiscountFactory.GetDiscount(type, 11);
                    var checkPosition = new CheckPosition(discount, new Product(10));
                    Assert.AreSame(discount, checkPosition.DiscountBase);
                    break;
                }
                case Discounts.Percent:
                {
                    var discount = DiscountFactory.GetDiscount(type, 11);
                    var checkPosition = new CheckPosition(discount, new Product(10));
                    Assert.AreSame(discount, checkPosition.DiscountBase);
                    break;
                }
            }
        }

        [Test]
        [TestCase(Discounts.Coupon, ExpectedResult = "Скидка по купону",
            TestName = "Проверка корректного Get у DiscountType")]
        [TestCase(Discounts.Percent, ExpectedResult = "Скидка по процентам",
            TestName = "Проверка корректного Get у DiscountType")]
        public string DiscountTypeTest(Discounts type)
        {
            switch (type)
            {
                case Discounts.Coupon:
                {
                    var discount = DiscountFactory.GetDiscount(type, 11);
                    var checkPosition = new CheckPosition(discount, new Product(10));
                    return checkPosition.DiscountType;
                }
                case Discounts.Percent:
                {
                    var discount = DiscountFactory.GetDiscount(type, 11);
                    var checkPosition = new CheckPosition(discount, new Product(10));
                    return checkPosition.DiscountType;
                }
            }

            return "Ошибка";
        }

        [Test]
        [TestCase(100,ExpectedResult = 100,
            TestName = "Проверка корректного Get у DiscountValue")]
        public double DiscountValueTest(double value)
        {
            var checkPosition = new CheckPosition(DiscountFactory.GetDiscount(Discounts.Coupon, value),
                new Product(100));
            return checkPosition.DiscountValue;
        }

        [Test]
        [TestCase(100, TestName = "Проверка корректного get у Product")]
        public void ProductTest(double value)
        {
            var discount = DiscountFactory.GetDiscount(Discounts.Coupon, 11);
            var product = new Product(value);
            var checkPosition = new CheckPosition(discount, product);
            Assert.AreSame(product, checkPosition.Product);
        }
    }
}