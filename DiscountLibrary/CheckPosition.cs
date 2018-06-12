using System;

namespace Discount
{
    /// <summary>
    ///     Позиция в чеке
    /// </summary>
    [Serializable]
    public class CheckPosition
    {
        /// <summary>
        ///     Скидка
        /// </summary>
        private readonly DiscountBase _discountBase;

        /// <summary>
        ///     Товар
        /// </summary>
        private readonly Product _product;

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
        public double CheckPositionPrice => _product.Price;

        /// <summary>
        ///     Вернуть через string название типа скидки
        /// </summary>
        public string DiscountType
        {
            get
            {
                switch (_discountBase)
                {
                    case CouponDiscount _:
                        return "Скидка по купону";
                    case PercentDiscount _:
                        return "Скидка по процентам";
                }

                return "Нет скидки";
            }
        }

        /// <summary>
        ///     Вернуть итоговую стоимость товара
        /// </summary>
        public double CheckPositionDiscount => _discountBase.Calculate(_product.Price);

        /// <summary>
        ///     Вернуть значение скидки в зависимости от типа
        /// </summary>
        public double DiscountValue
        {
            get
            {
                switch (_discountBase)
                {
                    case CouponDiscount temp:
                        return temp.CouponValue;
                    case PercentDiscount temp:
                        return temp.Percent;
                }

                return 0;
            }
        }
    }
}