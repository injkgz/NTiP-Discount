using System;

namespace Discount
{
    /// <summary>
    ///     Продукт
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Конструктор сущности Product
        /// </summary>
        /// <param name="price"></param>
        public Product(double price)
        {
            Price = price;
        }
        /// <summary>
        ///     Цена продукта
        /// </summary>
        private double _price;

        /// <summary>
        ///     Вернуть и установить цену товара
        /// </summary>
        public double Price
        {
            get => _price;
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Цена не может быть отрицательной!");
                }

                _price = value;
            }
        }
    }
}