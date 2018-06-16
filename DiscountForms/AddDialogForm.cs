﻿using System;
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
        public CheckPosition Object => ObjectControl.CheckPosition;

        /// <summary>
        ///     Обработчик события нажатия на кнопку Добавить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}