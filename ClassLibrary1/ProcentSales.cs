using System;

namespace Sales.Library
{
    internal class ProcentSales : Sales
    {
        private double _percent;

        public double Percent
        {
            get => _percent;
            set
            {
                if (value <= 0) throw new Exception("Проценты скидки не могут быть меньше или равны 0.");
                _percent = value;
            }
        }

        public override double Cost(Product product)
        {
            Sale = product.Price / 100 * _percent;
            Result = product.Price - Sale;

            if (Result < 0)
            {
                throw new Exception("Цена товара со скидкой не может быть меньше 0.");
            }

            return Result;
        }
    }
}