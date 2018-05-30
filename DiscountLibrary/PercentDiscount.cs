using System;

namespace discount
{
    public class PercentDiscount : Discount
    {
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
                    throw new Exception("Проценты скидки не могут быть меньше " +
                                        "или равны 0, а также больше 100.");
                _percent = value;
            }
        }

        /// <summary>
        ///     Расчёт итоговой стоимости товара со скидкой
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public double Cost(double price)
        {
            Sale = price / 100 * _percent;
            Result = price - Sale;

            if (Result < 0) throw new Exception("Цена товара со скидкой не может быть меньше 0.");

            return Result;
        }
    }
}