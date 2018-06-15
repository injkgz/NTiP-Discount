using System;
using System.Windows.Forms;
using Discount;

namespace DiscountForms
{
    public partial class AddDialogForm : Form
    {
        /// <summary>
        ///     Конструктор формы Dialog
        /// </summary>
        public AddDialogForm()
        {
            InitializeComponent();
            ObjectControl.ReadOnly = false;
        }

        /// <summary>
        ///     Вернуть сущность CheckPosition
        /// </summary>
        public CheckPosition Object => new CheckPosition(DiscountFactory.GetDiscount
            (ObjectControl.DiscountsType,
                Convert.ToDouble(ObjectControl.DiscountValue)),
            new Product(Convert.ToDouble(ObjectControl.Price)));

        /// <summary>
        ///     Обработчик события нажатия на кнопку Добавить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (ObjectControl.DiscountValue != ""
                && ObjectControl.Price != "")
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}