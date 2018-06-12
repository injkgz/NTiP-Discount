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
            this.buttonAdd = new System.Windows.Forms.Button();
            this.bindingSourceCheckPosition = new System.Windows.Forms.BindingSource(this.components);
            this.deleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.productTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCheckPosition)).BeginInit();
            this.SuspendLayout();
            // 
            // productTable
            // 
            this.productTable.AllowUserToOrderColumns = true;
            this.productTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productTable.Location = new System.Drawing.Point(12, 12);
            this.productTable.Name = "productTable";
            this.productTable.Size = new System.Drawing.Size(623, 426);
            this.productTable.TabIndex = 0;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(641, 342);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(159, 43);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Добавить позицию в чеке";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAddProduct_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(642, 391);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(158, 47);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Удалить позицию в чеке";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.productTable);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Расчёт скидок";
            ((System.ComponentModel.ISupportInitialize)(this.productTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCheckPosition)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView productTable;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.BindingSource bindingSourceCheckPosition;
        private System.Windows.Forms.Button deleteButton;
    }
}

