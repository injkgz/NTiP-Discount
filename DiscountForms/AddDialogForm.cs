using System;
using System.Windows.Forms;
using Discount;

namespace DiscountForms
{
    public partial class AddDialogForm : Form
    {
        private readonly BindingSource _bindingSourceCheckPosition;
        private Discounts _discountType;
        private double _discountValue;
        private double _price;
        private bool _isDotinTextBox1;
        private bool _isDotinTextBox2;

        public AddDialogForm(BindingSource bindingSourceCheckPosition)
        {
            InitializeComponent();
            _bindingSourceCheckPosition = bindingSourceCheckPosition;
            buttonAdd.Enabled = false;
            couponRadioButton.Checked = true;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _price = Convert.ToDouble(priceBox.Text);
            _discountValue = Convert.ToDouble(discountValueBox.Text);
            if (percentRadioButton.Checked)
            {
                _discountType = Discounts.Percent;
            }
            else if (couponRadioButton.Checked)
            {
                _discountType = Discounts.Coupon;
            }

            AddElementsInList();
            Close();
        }

        private void AddElementsInList()
        {
            switch (_discountType)
            {
                case Discounts.Coupon:
                {
                    _bindingSourceCheckPosition.Add(new CheckPosition(new CouponDiscount(_discountValue),
                        new Product(_price)));
                    break;
                }
                case Discounts.Percent:
                {
                    _bindingSourceCheckPosition.Add(new CheckPosition(new PercentDiscount(_discountValue),
                        new Product(_price)));
                    break;
                }
            }
        }

        private void priceBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_isDotinTextBox1 == false)
            {
                if (e.KeyChar == 46)
                {
                    _isDotinTextBox1 = true;
                }

                if (!char.IsDigit(e.KeyChar) && e.KeyChar != 46)
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void priceBox_TextChanged(object sender, EventArgs e)
        {
            if (priceBox.Text.Length == 0)
            {
                buttonAdd.Enabled = false;
            }
            else
            {
                buttonAdd.Enabled = true;
            }
        }


        private void discountValueBox_TextChanged(object sender, EventArgs e)
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
                catch
                {
                    // ignored
                }
            }
            else
            {
                buttonAdd.Enabled = true;
            }
        }

        private void discountValueBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (percentRadioButton.Checked == false && couponRadioButton.Checked == false)
            {
                MessageBox.Show("Выберите сначала тип скидки!", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (_isDotinTextBox2 == false)
            {
                if (e.KeyChar == 46)
                {
                    _isDotinTextBox2 = true;
                }

                if (!char.IsDigit(e.KeyChar) && e.KeyChar != 46)
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void percentRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            discountValueBox.Clear();
        }

        private void couponRadionButton_CheckedChanged(object sender, EventArgs e)
        {
            discountValueBox.Clear();
        }
    }
}