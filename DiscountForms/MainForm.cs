using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Discount;
using static DiscountForms.FormTools;
using static DiscountForms.Serialization;

namespace DiscountForms
{
    public partial class MainForm : Form
    {
        /// <summary>
        ///     Лист, хранящий сущности CheckPosition
        /// </summary>
        private BindingList<CheckPosition> _checkList = new BindingList<CheckPosition>();

        /// <summary>
        ///     Конструктор MainForm
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            ShowObject.Visible = false;
            ShowObject.ReadOnly = true;
            bindingSourceCheckPosition.DataSource = _checkList;
            productTable.DataSource = bindingSourceCheckPosition;
#if !DEBUG
            buttonAddRandom.Visible = false;
#endif
        }

        /// <summary>
        ///     Добавление элемента с выбранными атрибутами, вызов AddDialogForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddProduct_Click(object sender, EventArgs e)
        {
            var form = new AddDialogForm();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                _checkList.Add(form.Object);
            }
        }

        /// <summary>
        ///     Удаление выбранного элемента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (productTable.CurrentRow != null)
            {
                var index = productTable.CurrentRow.Index;
                productTable.Rows.Remove(productTable.Rows[index]);
            }
        }

        /// <summary>
        ///     Заполнение случайными данными
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Аргументы события</param>
        private void buttonAddRandom_Click(object sender, EventArgs e)
        {
            var random = new Random();
            double price = random.Next(100, 10000);
            double discountValue = random.Next(50, 9800);
            _checkList.Add(new CheckPosition(new CouponDiscount(discountValue),
                new Product(price)));

            price = random.Next(100, 10000);
            discountValue = random.Next(1, 90);
            _checkList.Add(new CheckPosition(new PercentDiscount(discountValue),
                new Product(price)));
        }

        /// <summary>
        ///     Обработчик события нажатия на кнопку Сохранить
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Аргументы события</param>
        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "CheckPositionList|*.inj";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Save(saveFileDialog.FileName, _checkList);
            }
        }

        /// <summary>
        ///     Обработчик события нажатия на кнопку Загрузить
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Аргументы события</param>
        private void LoadMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "CheckPositionList|*.inj";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _checkList = Open(openFileDialog.FileName);
                productTable.DataSource = _checkList;
            }
        }

        /// <summary>
        ///     Обработчик события нажатия на кнопку Поиск
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Аргументы события</param>
        private void SearchButton_Click(object sender, EventArgs e)
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

        /// <summary>
        ///     Блокирование кнопки при пустом TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            searchButton.Enabled = searchBox.Text.Length != 0;
        }

        /// <summary>
        ///     Ограничение на ввод символов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchBox_Validating(object sender, CancelEventArgs e)
        {
            TextBoxCheck(searchBox, e);
        }

        /// <summary>
        ///     Отображение в контроле выбранной ячейки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void productTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var currentCheck = _checkList[productTable.CurrentRow.Index];
            switch (currentCheck.DiscountType)
            {
                case "Скидка по процентам":
                    ShowObject.DiscountsType = Discounts.Percent;
                    break;
                case "Скидка по купону":
                    ShowObject.DiscountsType = Discounts.Coupon;
                    break;
            }

            ShowObject.DiscountValue = currentCheck.DiscountValue.ToString();
            ShowObject.Price = currentCheck.CheckPositionPrice.ToString();
            ShowObject.Visible = true;
        }
    }
}