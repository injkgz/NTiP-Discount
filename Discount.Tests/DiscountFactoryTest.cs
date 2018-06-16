using System;
using NUnit.Framework;

namespace Discount.Tests
{
    [TestFixture]
    public class DiscountFactoryTest
    {
    [Test]
    [TestCase(Discounts.Coupon, 11, TestName = "Проверка корректного возвращения скидки типа Coupon")]
    [TestCase(Discounts.Percent, 11, TestName = "Проверка корректного возвращения скидки типа Percent")]
    public void GetDiscount(Discounts key,
        double value)
    {
        switch (key)
        {
            case Discounts.Coupon:
            {
                var discount = DiscountFactory.GetDiscount(key, 11);
                var discountResult = discount as CouponDiscount;
                Assert.AreSame(discount, discountResult);
                break;
            }
            case Discounts.Percent:
            {
                var discount = DiscountFactory.GetDiscount(key, 11);
                var discountResult = discount as PercentDiscount;
                Assert.AreSame(discount, discountResult);
                break;
            }
        }
    }
    }
}