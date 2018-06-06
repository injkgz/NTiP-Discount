namespace DiscountForms
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.productTable = new System.Windows.Forms.DataGridView();
            this.CheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ProductPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResultPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAddProduct = new System.Windows.Forms.Button();
            this.buttonAddDiscount = new System.Windows.Forms.Button();
            this.buttonResult = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.productTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // productTable
            // 
            this.productTable.AllowUserToOrderColumns = true;
            this.productTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckBox,
            this.ProductPrice,
            this.DiscountType,
            this.DiscountSize,
            this.ResultPrice});
            this.productTable.Location = new System.Drawing.Point(12, 12);
            this.productTable.Name = "productTable";
            this.productTable.Size = new System.Drawing.Size(623, 426);
            this.productTable.TabIndex = 0;
            // 
            // CheckBox
            // 
            this.CheckBox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.CheckBox.HeaderText = "Выбрано";
            this.CheckBox.Name = "CheckBox";
            this.CheckBox.Width = 58;
            // 
            // ProductPrice
            // 
            this.ProductPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProductPrice.HeaderText = "Цена товара";
            this.ProductPrice.Name = "ProductPrice";
            // 
            // DiscountType
            // 
            this.DiscountType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.DiscountType.HeaderText = "Тип скидки";
            this.DiscountType.Name = "DiscountType";
            this.DiscountType.Width = 90;
            // 
            // DiscountSize
            // 
            this.DiscountSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DiscountSize.HeaderText = "Размер скидки";
            this.DiscountSize.Name = "DiscountSize";
            // 
            // ResultPrice
            // 
            this.ResultPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ResultPrice.HeaderText = "Итоговая стоимость";
            this.ResultPrice.Name = "ResultPrice";
            // 
            // buttonAddProduct
            // 
            this.buttonAddProduct.Location = new System.Drawing.Point(641, 289);
            this.buttonAddProduct.Name = "buttonAddProduct";
            this.buttonAddProduct.Size = new System.Drawing.Size(159, 43);
            this.buttonAddProduct.TabIndex = 1;
            this.buttonAddProduct.Text = "Добавить товар";
            this.buttonAddProduct.UseVisualStyleBackColor = true;
            this.buttonAddProduct.Click += new System.EventHandler(this.buttonAddProduct_Click);
            // 
            // buttonAddDiscount
            // 
            this.buttonAddDiscount.Location = new System.Drawing.Point(641, 338);
            this.buttonAddDiscount.Name = "buttonAddDiscount";
            this.buttonAddDiscount.Size = new System.Drawing.Size(159, 43);
            this.buttonAddDiscount.TabIndex = 2;
            this.buttonAddDiscount.Text = "Применить скидку";
            this.buttonAddDiscount.UseVisualStyleBackColor = true;
            // 
            // buttonResult
            // 
            this.buttonResult.Location = new System.Drawing.Point(641, 387);
            this.buttonResult.Name = "buttonResult";
            this.buttonResult.Size = new System.Drawing.Size(159, 43);
            this.buttonResult.TabIndex = 3;
            this.buttonResult.Text = "Итоговая стоимость";
            this.buttonResult.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonResult);
            this.Controls.Add(this.buttonAddDiscount);
            this.Controls.Add(this.buttonAddProduct);
            this.Controls.Add(this.productTable);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Расчёт скидок";
            ((System.ComponentModel.ISupportInitialize)(this.productTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView productTable;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountType;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResultPrice;
        private System.Windows.Forms.Button buttonAddProduct;
        private System.Windows.Forms.Button buttonAddDiscount;
        private System.Windows.Forms.Button buttonResult;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}

