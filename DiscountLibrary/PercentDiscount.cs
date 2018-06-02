using System;

namespace Discount
{
    /// <summary>
    ///     Процентная скидка
    /// </summary>
    public class PercentDiscount : DiscountBase
    {
        /// <summary>
        /// Конструктор скидки по процентам
        /// </summary>
        /// <param name="percent"></param>
        public PercentDiscount(double percent)
        {
            Percent = percent;
        }

        /// <summary>
        ///     Процент скидки
        /// </summary>
        private double _percent;

        /// <summary>
        ///     Вернуть и установить проценты
        /// </summary>
        public double Percent
        {
            get => _percent;
            set
            {
                if (value <= 0 && value > 100)
                {
                    throw new ArgumentException("Проценты скидки не могут быть меньше " +
                                                "или равны 0, а также больше 100.");
                }

                _percent = value;
            }
        }

        /// <summary>
        ///     Расчёт итоговой стоимости товара со скидкой
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public override double Calculation(double price)
        {
            Sale = price / 100 * _percent;
            return price - Sale;
        }
    }
}