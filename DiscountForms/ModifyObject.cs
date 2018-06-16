using System;
using System.ComponentModel;
using System.Windows.Forms;
using Discount;
using static DiscountForms.FormTools;

namespace DiscountForms
{
    /// <summary>
    ///     Контрол ModifyObject
    /// </summary>
    public partial class ModifyObject : UserControl
    {
        /// <summary>
        ///     Инициализация ModifyObject
        /// </summary>
        public ModifyObject()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Заблокировать запись в поля
        /// </summary>
        public bool ReadOnly
        {
            set
            {
                PriceBox.ReadOnly = value;
                ValueBox.ReadOnly = value;
                DiscountBox.Enabled = !value;
            }
        }

        //TODO: Не нужно на public
        //+
        //TODO: ВООБЩЕ не нужно на public и скорее всего не нужно классу!
        //+

        //TODO: Не нужно на public set
        //+
        //TODO: ВООБЩЕ не нужно на public и скорее всего не нужно классу!
        //+

        //TODO: Не нужно на public set
        //+
        //TODO: ВООБЩЕ не нужно на public и скорее всего не нужно классу!
        //+
        //TODO: XML
        //+
        /// <summary>
        ///     Вернуть сущность CheckPosition
        /// </summary>
        public CheckPosition GetCheckPosition()
        {
            //TODO: Почему объект кусками передаёте?
            //+
            if (PercentRadioButton.Checked)
            {
                return new CheckPosition(DiscountFactory.GetDiscount(Discounts.Percent,
                    Convert.ToDouble(ValueBox.Text)), new Product(Convert.ToDouble(PriceBox.Text)));
            }

            return new CheckPosition(DiscountFactory.GetDiscount(Discounts.Coupon,
                Convert.ToDouble(ValueBox.Text)), new Product(Convert.ToDouble(PriceBox.Text)));
        }


        /// <summary>
        ///     Установить сущность CheckPosition
        /// </summary>
        /// <param name="checkPosition"></param>
        public void SetCheckPosition(CheckPosition checkPosition)
        {
            ValueBox.Text = checkPosition.DiscountValue.ToString();
            PriceBox.Text = checkPosition.CheckPositionPrice.ToString();
            switch (checkPosition.DiscountType)
            {
                case "Скидка по процентам":
                    PercentRadioButton.Checked = true;
                    break;
                case "Скидка по купону":
                    CouponRadioButton.Checked = true;
                    break;
            }
        }

        /// <summary>
        ///     Обработчик события валидации DiscountValueBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_Validating(object sender, CancelEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                TextBoxCheck(textBox, e);
            }
        }

        ///// <summary>
        /////     Обработчик события изменения текста в DiscountValueBox
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        private void ValueBox_TextChanged(object sender, EventArgs e)
        {
            if (PercentRadioButton.Checked)
            {
                try
                {
                    if (Convert.ToDouble(ValueBox.Text) > 100)
                    {
                        ValueBox.Text = "100";
                    }
                }
                catch (FormatException exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }
    }
}