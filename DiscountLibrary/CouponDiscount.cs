using System;

namespace Discount
{
    /// <summary>
    ///     Скидка по купону
    /// </summary>
    public class CouponDiscount : DiscountBase
    {
        /// <summary>
        /// Конструктор скидки по купону
        /// </summary>
        /// <param name="couponValue"></param>
        public CouponDiscount(double couponValue)
        {
            CouponValue = couponValue;
        }

        /// <summary>
        ///     Сумма скидки по купону
        /// </summary>
        private double _couponValue;

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
        ///     Расчёт итоговой стоимости товара со скидкой
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public override double Calculation(double price)
        {
            if (_couponValue > price)
            {
                throw new ArgumentException("Цена товара со скидкой не может быть меньше 0.");
            }

            return price - _couponValue;
        }
    }
}