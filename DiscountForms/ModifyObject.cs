using System;
using System.ComponentModel;
using System.Windows.Forms;
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
        /// <summary>
        ///     Вернуть и установить цену
        /// </summary>
        public string Price
        {
            get => PriceBox.Text;
            private set => PriceBox.Text = value;
        }

        //TODO: Не нужно на public set
        //+
        //TODO: ВООБЩЕ не нужно на public и скорее всего не нужно классу!
        /// <summary>
        ///     Вернуть и установить тип скидки
        /// </summary>
        public Discounts DiscountsType
        {
            get => PercentRadioButton.Checked
                ? Discounts.Percent
                : Discounts.Coupon;
            private set
            {
                switch (value)
                {
                    case Discounts.Percent:
                        PercentRadioButton.Checked = true;
                        break;
                    case Discounts.Coupon:
                        CouponRadioButton.Checked = true;
                        break;
                }
            }
        }

        //TODO: Не нужно на public set
        //+
        //TODO: ВООБЩЕ не нужно на public и скорее всего не нужно классу!
        /// <summary>
        ///     Вернуть и установить DiscountValue
        /// </summary>
        public string DiscountValue
        {
            get => ValueBox.Text;
            private set => ValueBox.Text = value;
        }
        //TODO: XML
        public void SetCheckPosition(Discounts type, double value, double price)
        {
            //TODO: Почему объект кусками передаёте?
            DiscountValue = value.ToString();
            Price = price.ToString();
            DiscountsType = type;
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