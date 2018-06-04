using System;

namespace Discount
{
    /// <summary>
    ///     Базовая скидка
    /// </summary>
    public abstract class DiscountBase
    {
        //TODO: Не правильно это хранить тут! 
        //+
        /// <summary>
        /// Расчёт итоговой цены товара
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public abstract double Calculation(double price);
    }
}