using System;
using System.Runtime.Serialization;

namespace Discount
{
    /// <summary>
    ///     Базовая скидка
    /// </summary>
    [DataContract]
    public abstract class DiscountBase
    {
        /// <summary>
        ///     Описание Discount
        /// </summary>
        protected string _description;

        /// <summary>
        ///     Метод, возвращающий string-описание скидки
        /// </summary>
        /// <returns></returns>
        public abstract string Description { get;
            //TODO: Не нужен.
            protected set; }

        /// <summary>
        ///     Расчёт итоговой цены товара
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public abstract double Calculate(double price);

        /// <summary>
        ///     Метод, возвращающий значение скидки в зависимости от её типа:
        ///     CouponDiscount - CouponValue
        ///     PercentDiscount - Percent
        /// </summary>
        /// <returns></returns>
        public abstract double Value();

        /// <summary>
        ///     Проверка корректного Price
        /// </summary>
        /// <param name="price"></param>
        protected void CheckPrice(double price)
        {
            if (price < 0 && price < double.MaxValue)
            {
                throw new ArgumentException("Некорректная цена для расчёта скидки");
            }
        }
    }
}