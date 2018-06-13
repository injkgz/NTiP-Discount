using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Discount;
using static DiscountForms.FormTools;

namespace DiscountForms
{
    public partial class AddDialogForm : Form
    {
        /// <summary>
        ///     Источник данных
        /// </summary>
        private readonly BindingSource _bindingSourceCheckPosition;

        /// <summary>
        ///     Конструктор формы Dialog
        /// </summary>
        /// <param name="bindingSourceCheckPosition"></param>
        public AddDialogForm(BindingSource bindingSourceCheckPosition)
        {
            InitializeComponent();
            _bindingSourceCheckPosition = bindingSourceCheckPosition;
            buttonAdd.Enabled = false;
            couponRadioButton.Checked = true;
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var discountType = Discounts.Percent;
            if (percentRadioButton.Checked)
            {
                discountType = Discounts.Percent;
            }
            else if (couponRadioButton.Checked)
            {
                discountType = Discounts.Coupon;
            }

            AddElementsInList(Convert.ToDouble(discountValueBox.Text),
                Convert.ToDouble(priceBox.Text), discountType);
            Close();
        }

        /// <summary>
        /// Метод добавления элементов в таблицу
        /// </summary>
        /// <param name="discountValue"></param>
        /// <param name="price"></param>
        /// <param name="discountType"></param>
        private void AddElementsInList(double discountValue, double price, Discounts discountType)
        {
            switch (discountType)
            {
                case Discounts.Coupon:
                {
                    _bindingSourceCheckPosition.Add(new CheckPosition(
                        new CouponDiscount(discountValue),
                        new Product(price)));
                    break;
                }
                case Discounts.Percent:
                {
                    _bindingSourceCheckPosition.Add(new CheckPosition(
                        new PercentDiscount(discountValue),
                        new Product(price)));
                    break;
                }
            }
        }

        private void PriceBox_TextChanged(object sender, EventArgs e)
        {
            buttonAdd.Enabled = priceBox.Text.Length != 0;
        }


        private void DiscountValueBox_TextChanged(object sender, EventArgs e)
        {
            if (priceBox.Text.Length == 0)
            {
                buttonAdd.Enabled = false;
            }
            else if (percentRadioButton.Checked)
            {
                try
                {
                    if (Convert.ToDouble(discountValueBox.Text) > 100)
                    {
                        discountValueBox.Text = "100";
                    }
                }
                catch (FormatException exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
            else
            {
                buttonAdd.Enabled = true;
            }
        }

        private void DiscountValueBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (percentRadioButton.Checked == false && couponRadioButton.Checked == false)
            {
                MessageBox.Show("Выберите сначала тип скидки!", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PercentRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            discountValueBox.Clear();
        }

        private void PriceBox_Validating(object sender, CancelEventArgs e)
        {
            if (priceBox.Text != "")
            {
                e.Cancel = !CheckStringForDouble(priceBox.Text);
            }
            
        }

        private void discountValueBox_Validating(object sender, CancelEventArgs e)
        {
            if (discountValueBox.Text != "")
            {
                e.Cancel = !CheckStringForDouble(discountValueBox.Text);
            }
           
        }
    }
}