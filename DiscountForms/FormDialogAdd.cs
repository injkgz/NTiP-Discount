using System;
using System.Windows.Forms;
using Discount;
using DiscountConsole;

namespace DiscountForms
{
    public partial class FormDialogAdd : Form
    {
        private readonly BindingSource _bindingSourceCheckPosition;
        private Discounts _discountType;
        private double _discountValue;
        private double _price;
        private bool isDotinTextBox1;
        private bool isDotinTextBox2;

        public FormDialogAdd(BindingSource bindingSourceCheckPosition)
        {
            InitializeComponent();
            _bindingSourceCheckPosition = bindingSourceCheckPosition;
            button1.Enabled = false;
            radioButton2.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _price = Convert.ToDouble(textBox1.Text);
            _discountValue = Convert.ToDouble(textBox3.Text);
            if (radioButton1.Checked)
            {
                _discountType = Discounts.Percent;
            }
            else if (radioButton2.Checked)
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isDotinTextBox1 == false)
            {
                if (e.KeyChar == 46)
                {
                    isDotinTextBox1 = true;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                button1.Enabled = false;
            }
            else if (radioButton1.Checked)
            {
                try
                {
                    if (Convert.ToDouble(textBox3.Text) > 100)
                    {
                        textBox3.Text = "100";
                    }
                }
                catch
                {
                }
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                MessageBox.Show("Выберите сначала тип скидки!", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (isDotinTextBox2 == false)
            {
                if (e.KeyChar == 46)
                {
                    isDotinTextBox2 = true;
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Clear();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Clear();
        }
    }
}