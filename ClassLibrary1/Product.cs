using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Library
{
    /// <summary>
    ///     Продукт
    /// </summary>
    public class Product
    {
        /// <summary>
        ///     Цена продукта
        /// </summary>
        private double _price { get; set; }

        public double Price
        {
            get => _price;
            set
            {
                if (value <= 0) throw new Exception("Цена не может быть отрицательной!");
                _price = value;
            }
        }
    }
}