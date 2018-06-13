using System;
using System.Windows.Forms;
using Discount;

namespace DiscountForms
{
    public partial class AddDialogForm : Form
    {
        /// <summary>
        ///     Конструктор формы Dialog
        /// </summary>
        public AddDialogForm()
        {
            InitializeComponent();
            ControlObject.ReadOnly = false;
        }

        /// <summary>
        ///     Вернуть сущность CheckPosition
        /// </summary>
        public CheckPosition Object
        {
            get
            {
                switch (ControlObject.DiscountsType)
                {
                    case Discounts.Coupon:
                    {
                        return new CheckPosition(new CouponDiscount
                                (Convert.ToDouble(ControlObject.DiscountValue)),
                            new Product(Convert.ToDouble(ControlObject.Price)));
                    }
                    case Discounts.Percent:
                    {
                        return new CheckPosition(new PercentDiscount
                                (Convert.ToDouble(ControlObject.DiscountValue)),
                            new Product(Convert.ToDouble(ControlObject.Price)));
                    }
                }

                return null;
            }
        }

        /// <summary>
        ///     Обработчик события нажатия на кнопку Добавить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (ControlObject.DiscountValue != "" && ControlObject.Price != ""
                                                  && ControlObject.DiscountsType != null)
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}