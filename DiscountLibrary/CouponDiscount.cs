using System;

namespace Discount
{
    /// <summary>
    ///     Скидка по купону
    /// </summary>
    [Serializable]
    public class CouponDiscount : DiscountBase
    {
        /// <summary>
        ///     Сумма скидки по купону
        /// </summary>
        private double _couponValue;

        /// <summary>
        ///     Конструктор скидки по купону
        /// </summary>
        /// <param name="couponValue"></param>
        public CouponDiscount(double couponValue)
        {
            CouponValue = couponValue;
        }

        /// <summary>
        ///     Вернуть и установить размер скидки по купону
        /// </summary>
        public double CouponValue
        {
            get => _couponValue;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Скидка по купону не может быть отрицательной!");
                }

                _couponValue = value;
            }
        }

        /// <summary>
        ///     Метод, возвращающий string-описание скидки
        /// </summary>
        /// <returns></returns>
        public override string GetDescription()
        {
            return "Скидка по купону";
        }

        /// <summary>
        ///     Метод, возвращающий значение скидки в зависимости от её типа:
        ///     CouponDiscount - CouponValue
        /// </summary>
        /// <returns></returns>
        public override double GetValue()
        {
            return CouponValue;
        }

        /// <summary>
        ///     Расчёт итоговой стоимости товара со скидкой
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public override double Calculate(double price)
        {
            CheckPrice(price);
            if (CouponValue > price)
            {
                CouponValue = CouponValue - price;
                return 0;
            }

            return price - _couponValue;
        }
    }
}