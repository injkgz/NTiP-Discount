using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Discount;

namespace DiscountForms
{
    public partial class MainForm : Form
    {
        private readonly List<CheckPosition> _checkList = new List<CheckPosition>();

        /// <summary>
        ///     Сериализует/Десериализует объекты.
        /// </summary>
        private readonly BinaryFormatter _formatter;

        private bool _isDotinTextBox;

        public MainForm()
        {
            InitializeComponent();
            bindingSourceCheckPosition.DataSource = _checkList;
            productTable.DataSource = bindingSourceCheckPosition;
            _formatter = new BinaryFormatter();
#if !DEBUG
            buttonAddRandom.Visible = false;
#endif
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            var form = new AddDialogForm(bindingSourceCheckPosition);
            form.ShowDialog();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (productTable.CurrentRow != null)
            {
                var index = productTable.CurrentRow.Index;
                productTable.Rows.Remove(productTable.Rows[index]);
            }
        }

        private void buttonAddRandom_Click(object sender, EventArgs e)
        {
            var random = new Random();
            double price = random.Next(100, 10000);
            double discountValue = random.Next(50, 9800);
            bindingSourceCheckPosition.Add(new CheckPosition(new CouponDiscount(discountValue),
                new Product(price)));

            price = random.Next(100, 10000);
            discountValue = random.Next(1, 90);
            bindingSourceCheckPosition.Add(new CheckPosition(new PercentDiscount(discountValue),
                new Product(price)));
        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var fileStream = new FileStream("checkList.injkgz",
                    FileMode.OpenOrCreate);

                _formatter.Serialize(fileStream, _checkList);
                fileStream.Dispose();

                MessageBox.Show("Файл сохранен.");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void LoadMenuItem_Click(object sender, EventArgs e)
        {
            var fileStream = new FileStream("checkList.injkgz",
                FileMode.OpenOrCreate);

            var deserializeCheckPositions = (List<CheckPosition>) _formatter.Deserialize(fileStream);

            bindingSourceCheckPosition.Clear();

            foreach (var salary in deserializeCheckPositions)
            {
                bindingSourceCheckPosition.Add(salary);
            }

            fileStream.Dispose();

            MessageBox.Show("Данные считаны!");
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (searchBox.Text != "")
            {
                var founded = new List<CheckPosition>();
                foreach (var checkPosition in _checkList)
                {
                    if (checkPosition.CheckPositionPrice == Convert.ToDouble(searchBox.Text))
                    {
                        founded.Add(checkPosition);
                    }
                }

                bindingSourceCheckPosition.DataSource = founded;
            }
            else
            {
                bindingSourceCheckPosition.DataSource = _checkList;
            }
        }

        private void searchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_isDotinTextBox == false)
            {
                if (e.KeyChar == 46)
                {
                    _isDotinTextBox = true;
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

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            if (searchBox.Text.Length == 0)
            {
                searchButton.Enabled = false;
            }
            else
            {
                searchButton.Enabled = true;
            }
        }
    }
}