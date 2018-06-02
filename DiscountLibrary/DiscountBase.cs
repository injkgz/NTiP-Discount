using System;

namespace Discount
{
    /// <summary>
    ///     Базовая скидка
    /// </summary>
    public abstract class DiscountBase
    {
        /// <summary>
        ///     Скидка
        /// </summary>
        private double _sale;

        /// <summary>
        ///     Вернуть и установить размер скидки
        /// </summary>
        public double Sale
        {
            get => _sale;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Скидка не может быть меньше 0!");
                }

                _sale = value;
            }
        }

        /// <summary>
        /// Расчёт итоговой цены товара
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public abstract double Calculation(double price);
    }
}