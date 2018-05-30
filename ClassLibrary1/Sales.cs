using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Library
{
    public abstract class Sales
    {
        /// <summary>
        /// Скидка
        /// </summary>
        private double _sale;

        /// <summary>
        /// Цена товара с учётом скидки
        /// </summary>
        private double _result;

        public double Result { get; set; }

        public double Sale
        {
            get { return _sale; }

            set
            {
                if (value < 0)
                {
                    throw new Exception("Скидка не может быть меньше 0!");
                }
                _sale = value;
            }
        }

        /// <summary>
        /// Расчёт итоговой стоимости товара
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public virtual double Cost(Product product)
        {
            _result = product.Price - _sale;

            if (_result < 0)
            {
                throw new Exception("Цена товара со скидкой не может быть меньше 0.");
            }

            return _result;
        }

    }
}
