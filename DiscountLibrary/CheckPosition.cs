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
            if (_discountBase != null && _product != null)
            {
                _discountBase = discount;
                _product = product;
            }
            else
            {
                throw new ArgumentException("Аргументы = null!");
            }
        }

        /// <summary>
        ///     Вернуть цену товара в чеке
        /// </summary>
        public double CheckPositionPrice => _product.Price;

        //TODO:
        //+
        /// <summary>
        ///     Вернуть через string название типа скидки
        /// </summary>
        public string DiscountType
        {
            get
            {
                if (_discountBase != null)
                {
                    return _discountBase.GetDescription();
                }

                return "Нет скидки";
            }
        }

        /// <summary>
        ///     Вернуть итоговую стоимость товара
        /// </summary>
        public double CheckPositionDiscount => _discountBase.Calculate(_product.Price);

        //TODO:
        //+
        /// <summary>
        ///     Вернуть значение скидки в зависимости от типа
        /// </summary>
        public double DiscountValue
        {
            get
            {
                if (_discountBase != null)
                {
                    return _discountBase.GetValue();
                }

                return 0;
            }
        }
    }
}