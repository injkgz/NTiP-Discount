using System;
using System.ComponentModel;
using System.Windows.Forms;
using static DiscountForms.FormTools;

namespace DiscountForms
{
    /// <summary>
    /// Контрол ModifyObject
    /// </summary>
    public partial class ModifyObject : UserControl
    {
        /// <summary>
        /// Инициализация ModifyObject
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
        /// <summary>
        ///     Вернуть и установить цену
        /// </summary>
        public string Price
        {
            get => PriceBox.Text;
            set => PriceBox.Text = value;
        }

        //TODO: Не нужно на public set
        /// <summary>
        ///     Вернуть и установить тип скидки
        /// </summary>
        public Discounts DiscountsType
        {
            get => PercentRadioButton.Checked 
                ? Discounts.Percent 
                : Discounts.Coupon;
            set
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
        /// <summary>
        ///     Вернуть и установить DiscountValue
        /// </summary>
        public string DiscountValue
        {
            get => ValueBox.Text;
            set => ValueBox.Text = value;
        }

        /// <summary>
        ///     Обработчик события валидации DiscountValueBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValueBox_Validating(object sender, CancelEventArgs e)
        {
            //TODO: Ниже дубль - можно всё привязать к одному обработчику.
            TextBoxCheck(ValueBox, e);
        }

        /// <summary>
        ///     Обработчик события валидации PriceBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PriceBox_Validating(object sender, CancelEventArgs e)
        {
            TextBoxCheck(PriceBox, e);
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