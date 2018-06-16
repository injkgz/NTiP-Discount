using System;

namespace Discount
{
    /// <summary>
    ///     Фабрика класса DiscountBase и наследников
    /// </summary>
    public abstract class DiscountFactory
    {
        /// <summary>
        ///     Вернуть скидку определённого типа
        /// </summary>
        /// <param name="key">Тип скидки</param>
        /// <param name="value">Значение скидки</param>
        /// <returns></returns>
        public static DiscountBase GetDiscount(Discounts key,
            double value)
        {
            DiscountBase discountBase = null;

            switch (key)
            {
                case Discounts.Percent:
                    discountBase = new PercentDiscount(value);
                    break;

                case Discounts.Coupon:
                    discountBase = new CouponDiscount(value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(key), key, null);
            }

            return discountBase;
        }
    }
}