using System;

namespace Discount
{
    /// <summary>
    ///     Позиция в чеке
    /// </summary>
    [Serializable()]
    public class CheckPosition
    { 
        /// <summary>
        ///     Товар
        /// </summary>
        private Product _product;

        /// <summary>
        /// Скидка
        /// </summary>
        private DiscountBase _discountBase;

        /// <summary>
        ///     Конструктор позиции в чеке
        /// </summary>
        /// <param name="discount"></param>
        /// <param name="product"></param>
        public CheckPosition(DiscountBase discount, Product product)
        {
            _discountBase = discount;
            _product = product;
        }

        /// <summary>
        ///     Вернуть цену товара в чеке
        /// </summary>
        public double CheckPositionPrice
        {
            get => _product.Price;
        }

        public string DiscountType
        {
            get
            {
                if (_discountBase is CouponDiscount)
                {
                    return "Скидка по купону";
                }

                if (_discountBase is PercentDiscount)
                {
                    return "Скидка по процентам";
                }

                return "Нет скидки";
            }
        }

        public double CheckPositionDiscount
        {
            get => _discountBase.Calculate(_product.Price);
        }

        public double DiscountValue
        {
            get
            {
                if (_discountBase is CouponDiscount)
                {
                    CouponDiscount temp = (CouponDiscount)_discountBase;
                    return temp.CouponValue;
                }

                if (_discountBase is PercentDiscount)
                {
                    PercentDiscount temp = (PercentDiscount)_discountBase;
                    return temp.Percent;
                }

                return 0;
            }
        }

    }
}