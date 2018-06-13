namespace DiscountForms
{
    partial class ModifyObject
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.AddGroupBox = new System.Windows.Forms.GroupBox();
            this.DiscountBox = new System.Windows.Forms.GroupBox();
            this.PercentRadioButton = new System.Windows.Forms.RadioButton();
            this.CouponRadioButton = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PriceBox = new System.Windows.Forms.TextBox();
            this.ValueBox = new System.Windows.Forms.TextBox();
            this.AddGroupBox.SuspendLayout();
            this.DiscountBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddGroupBox
            // 
            this.AddGroupBox.Controls.Add(this.ValueBox);
            this.AddGroupBox.Controls.Add(this.PriceBox);
            this.AddGroupBox.Controls.Add(this.DiscountBox);
            this.AddGroupBox.Controls.Add(this.label3);
            this.AddGroupBox.Controls.Add(this.label1);
            this.AddGroupBox.Location = new System.Drawing.Point(3, 3);
            this.AddGroupBox.Name = "AddGroupBox";
            this.AddGroupBox.Size = new System.Drawing.Size(142, 202);
            this.AddGroupBox.TabIndex = 0;
            this.AddGroupBox.TabStop = false;
            this.AddGroupBox.Text = "Объект CheckPosition";
            // 
            // DiscountBox
            // 
            this.DiscountBox.Controls.Add(this.PercentRadioButton);
            this.DiscountBox.Controls.Add(this.CouponRadioButton);
            this.DiscountBox.Location = new System.Drawing.Point(6, 68);
            this.DiscountBox.Name = "DiscountBox";
            this.DiscountBox.Size = new System.Drawing.Size(114, 78);
            this.DiscountBox.TabIndex = 15;
            this.DiscountBox.TabStop = false;
            this.DiscountBox.Text = "Тип скидки";
            // 
            // percentRadioButton
            // 
            this.PercentRadioButton.AutoSize = true;
            this.PercentRadioButton.Location = new System.Drawing.Point(6, 19);
            this.PercentRadioButton.Name = "PercentRadioButton";
            this.PercentRadioButton.Size = new System.Drawing.Size(97, 17);
            this.PercentRadioButton.TabIndex = 8;
            this.PercentRadioButton.TabStop = true;
            this.PercentRadioButton.Text = "По процентам";
            this.PercentRadioButton.UseVisualStyleBackColor = true;
            // 
            // couponRadioButton
            // 
            this.CouponRadioButton.AutoSize = true;
            this.CouponRadioButton.Location = new System.Drawing.Point(6, 42);
            this.CouponRadioButton.Name = "CouponRadioButton";
            this.CouponRadioButton.Size = new System.Drawing.Size(76, 17);
            this.CouponRadioButton.TabIndex = 9;
            this.CouponRadioButton.TabStop = true;
            this.CouponRadioButton.Text = "По купону";
            this.CouponRadioButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Значение скидки:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Цена товара:";
            // 
            // PriceBox
            // 
            this.PriceBox.Location = new System.Drawing.Point(7, 43);
            this.PriceBox.Name = "PriceBox";
            this.PriceBox.Size = new System.Drawing.Size(100, 20);
            this.PriceBox.TabIndex = 16;
            this.PriceBox.Validating += new System.ComponentModel.CancelEventHandler(this.PriceBox_Validating);
            // 
            // ValueBox
            // 
            this.ValueBox.Location = new System.Drawing.Point(7, 166);
            this.ValueBox.Name = "ValueBox";
            this.ValueBox.Size = new System.Drawing.Size(100, 20);
            this.ValueBox.TabIndex = 17;
            this.ValueBox.TextChanged += new System.EventHandler(this.ValueBox_TextChanged);
            this.ValueBox.Validating += new System.ComponentModel.CancelEventHandler(this.ValueBox_Validating);
            // 
            // ModifyObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AddGroupBox);
            this.Name = "ModifyObject";
            this.Size = new System.Drawing.Size(145, 205);
            this.AddGroupBox.ResumeLayout(false);
            this.AddGroupBox.PerformLayout();
            this.DiscountBox.ResumeLayout(false);
            this.DiscountBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox AddGroupBox;
        private System.Windows.Forms.GroupBox DiscountBox;
        private System.Windows.Forms.RadioButton PercentRadioButton;
        private System.Windows.Forms.RadioButton CouponRadioButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ValueBox;
        private System.Windows.Forms.TextBox PriceBox;
    }
}
