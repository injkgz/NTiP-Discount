using System;

namespace Discount
{
    /// <summary>
    ///     Базовая скидка
    /// </summary>
    public abstract class DiscountBase
    {
        //TODO: Название! Calculation - существительное, а должен быть глагол из которого будет понятно - что рассчитываем.
        /// <summary>
        /// Расчёт итоговой цены товара
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public abstract double Calculation(double price);
    }
}