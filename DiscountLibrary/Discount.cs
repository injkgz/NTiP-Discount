using System;

namespace discount
{
    public abstract class Discount
    {
        /// <summary>
        ///     Цена товара с учётом скидки
        /// </summary>
        private double _result;

        /// <summary>
        ///     Скидка
        /// </summary>
        private double _sale;

        /// <summary>
        ///     Вернуть и установить цену товара с учётом скидки
        /// </summary>
        public double Result { get; set; }

        /// <summary>
        ///     Вернуть и установить размер скидки
        /// </summary>
        public double Sale
        {
            get => _sale;

            set
            {
                if (value < 0) throw new Exception("Скидка не может быть меньше 0!");
                _sale = value;
            }
        }
    }
}