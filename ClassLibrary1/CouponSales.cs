using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Library
{
    class CouponSales : Sales
    {
        /// <summary>
        /// Сумма скидки по купону
        /// </summary>
        private double _couponvalue;

        public double CouponValue { get; set; }

        public override double Cost(Product product)
        {
            Result = product.Price - _couponvalue;

            if (Result < 0)
            {
                throw new Exception("Цена товара со скидкой не может быть меньше 0.");
            }

            return Result;
        }
    }
}
