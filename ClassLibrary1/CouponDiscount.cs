using System;

namespace discount
{
    public class CouponDiscount : Discount
    {
        /// <summary>
        ///     Сумма скидки по купону
        /// </summary>
        private double _couponvalue;

        /// <summary>
        ///     Вернуть и установить размер скидки по купону
        /// </summary>
        public double CouponValue
        {
            get => _couponvalue;

            set
            {
                if (value < 0) throw new Exception("Скидка по купону не может быть отрицательной!");

                _couponvalue = value;
            }
        }

        /// <summary>
        ///     Расчёт итоговой стоимости товара со скидкой
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public double Cost(double price)
        {
            Result = price - _couponvalue;

            if (Result < 0) throw new Exception("Цена товара со скидкой не может быть меньше 0.");

            return Result;
        }
    }
}