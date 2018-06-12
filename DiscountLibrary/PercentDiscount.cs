using System;

namespace Discount
{
    /// <summary>
    ///     Процентная скидка
    /// </summary>
    [Serializable]
    public class PercentDiscount : DiscountBase
    {
        /// <summary>
        ///     Процент скидки
        /// </summary>
        private double _percent;

        /// <summary>
        ///     Конструктор скидки по процентам
        /// </summary>
        /// <param name="percent"></param>
        public PercentDiscount(double percent)
        {
            Percent = percent;
        }

        /// <summary>
        ///     Вернуть и установить проценты
        /// </summary>
        public double Percent
        {
            get => _percent;

            private set
            {
                if (value <= 0 || value > 100)
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
        public override double Calculate(double price)
        {
            return price - price / 100 * _percent;
        }
    }
}