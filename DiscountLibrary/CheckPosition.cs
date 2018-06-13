using System.Runtime.Serialization;

namespace Discount
{
    /// <summary>
    ///     Позиция в чеке
    /// </summary>
    [DataContract]
    public class CheckPosition
    {
        /// <summary>
        ///     Конструктор позиции в чеке
        /// </summary>
        /// <param name="discount"></param>
        /// <param name="product"></param>
        public CheckPosition(DiscountBase discount, Product product)
        {
            DiscountBase = discount;
            Product = product;
        }

        /// <summary>
        ///     Скидка
        /// </summary>
        [DataMember]
        public DiscountBase DiscountBase { get; set; }

        /// <summary>
        ///     Товар
        /// </summary>
        [DataMember]
        public Product Product { get; set; }

        /// <summary>
        ///     Вернуть цену товара в чеке
        /// </summary>
        public double CheckPositionPrice
        {
            get => Product.Price;
            set => Product.Price = value;
        }

        //TODO:
        //+
        /// <summary>
        ///     Вернуть через string название типа скидки
        /// </summary>
        public string DiscountType
        {
            get
            {
                if (DiscountBase != null)
                {
                    return DiscountBase.Description;
                }

                return "Нет скидки";
            }
        }

        /// <summary>
        ///     Вернуть итоговую стоимость товара
        /// </summary>
        public double CheckPositionDiscount => DiscountBase.Calculate(Product.Price);

        //TODO:
        //+
        /// <summary>
        ///     Вернуть значение скидки в зависимости от типа
        /// </summary>
        public double DiscountValue
        {
            get
            {
                if (DiscountBase != null)
                {
                    return DiscountBase.GetValue();
                }

                return 0;
            }
        }
    }
}