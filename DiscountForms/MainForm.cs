using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Discount;
using static DiscountForms.FormTools;

namespace DiscountForms
{
    public partial class MainForm : Form
    {
        /// <summary>
        ///     Лист, хранящий сущности CheckPosition
        /// </summary>
        private readonly List<CheckPosition> _checkList = new List<CheckPosition>();

        /// <summary>
        ///     Сериализует/Десериализует объекты.
        /// </summary>
        private readonly BinaryFormatter _formatter;

        /// <summary>
        ///     Конструктор MainForm
        /// </summary>
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

        /// <summary>
        ///     Добавление элемента с выбранными атрибутами, вызов AddDialogForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddProduct_Click(object sender, EventArgs e)
        {
            var form = new AddDialogForm(bindingSourceCheckPosition);
            form.ShowDialog();
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
            bindingSourceCheckPosition.Add(new CheckPosition(new CouponDiscount(discountValue),
                new Product(price)));

            price = random.Next(100, 10000);
            discountValue = random.Next(1, 90);
            bindingSourceCheckPosition.Add(new CheckPosition(new PercentDiscount(discountValue),
                new Product(price)));
        }

        /// <summary>
        ///     Обработчик события нажатия на кнопку Сохранить
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Аргументы события</param>
        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var fileStream = new FileStream("checkList.inj",
                    FileMode.OpenOrCreate);

                _formatter.Serialize(fileStream, _checkList);
                fileStream.Dispose();

                MessageBox.Show("Файл сохранен.");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        ///     Обработчик события нажатия на кнопку Загрузить
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Аргументы события</param>
        private void LoadMenuItem_Click(object sender, EventArgs e)
        {
            var fileStream = new FileStream("checkList.inj",
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
            if (searchBox.Text != "")
            {
                e.Cancel = !CheckStringForDouble(searchBox.Text);
            }
        }
    }
}