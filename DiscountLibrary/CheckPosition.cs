using System;
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
            if (discount == null && product == null)
            {
                throw new ArgumentException("Discount и Product " +
                                            "не инициализированы! Равны NULL!");
            }

            DiscountBase = discount;
            Product = product;
        }

        //TODO: Зачем публичный set?
        //+
        /// <summary>
        ///     Скидка
        /// </summary>
        [DataMember]
        public DiscountBase DiscountBase { get; private set; }

        //TODO: Зачем публичный set?
        //+
        /// <summary>
        ///     Товар
        /// </summary>
        [DataMember]
        public Product Product { get; private set; }

        /// <summary>
        ///     Вернуть цену товара в чеке
        /// </summary>
        public double CheckPositionPrice
        {
            get => Product.Price;
            set => Product.Price = value;
        }

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
                //TODO: Копипаста, сообщение должно говорить только о Discount, т.к. проверяет только Discount
                //+
                throw new ArgumentException("Discount " +
                                            "не инициализированы! Равны NULL!");
            }
        }

        /// <summary>
        ///     Вернуть итоговую стоимость товара
        /// </summary>
        public double CheckPositionDiscount => DiscountBase.Calculate(Product.Price);

        /// <summary>
        ///     Вернуть значение скидки в зависимости от типа
        /// </summary>
        public double DiscountValue
        {
            get
            {
                if (DiscountBase != null)
                {
                    return DiscountBase.Value();
                }
                //TODO: Копипаста, сообщение должно говорить только о Discount, т.к. проверяет только Discount
                //+
                throw new ArgumentException("Discount " +
                                            "не инициализированы! Равны NULL!");
            }
        }
    }
}