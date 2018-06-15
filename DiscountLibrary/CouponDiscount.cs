using System;
using System.Runtime.Serialization;

namespace Discount
{
    /// <summary>
    ///     Скидка по купону
    /// </summary>
    [DataContract]
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
        [DataMember]
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

        //TODO: Зачем публичный set?
        //+
        //написал в ВК
        //Иначе контрол будет отрабатывать неверно
        /// <summary>
        ///     Метод, возвращающий string-описание скидки
        /// </summary>
        /// <returns></returns>
        [DataMember]
        public override string Description
        {
            get => "Скидка по купону";
            protected set => _description = value;
        }

        /// <summary>
        ///     Метод, возвращающий значение скидки в зависимости от её типа:
        ///     CouponDiscount - CouponValue
        /// </summary>
        /// <returns></returns>
        public override double Value()
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
                return 0;
            }

            return price - _couponValue;
        }
    }
}