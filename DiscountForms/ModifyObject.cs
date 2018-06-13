using System;
using System.ComponentModel;
using System.Windows.Forms;
using static DiscountForms.FormTools;

namespace DiscountForms
{
    public partial class ModifyObject : UserControl
    {
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
            }
        }


        /// <summary>
        ///     Вернуть и установить цену
        /// </summary>
        public string Price
        {
            get => PriceBox.Text;
            set => PriceBox.Text = value;
        }

        /// <summary>
        ///     Вернуть и установить тип скидки
        /// </summary>
        public Discounts DiscountsType
        {
            get
            {
                if (PercentRadioButton.Checked)
                {
                    return Discounts.Percent;
                }

                return Discounts.Coupon;
            }
            set
            {
                if (value == Discounts.Percent)
                {
                    PercentRadioButton.Checked = true;
                }

                else if (value == Discounts.Coupon)
                {
                    CouponRadioButton.Checked = true;
                }
            }
        }

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