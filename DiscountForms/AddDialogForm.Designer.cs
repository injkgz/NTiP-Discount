namespace DiscountForms
{
    partial class AddDialogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonAdd = new System.Windows.Forms.Button();
            this.priceBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.discountValueBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.percentRadioButton = new System.Windows.Forms.RadioButton();
            this.couponRadioButton = new System.Windows.Forms.RadioButton();
            this.DiscountBox = new System.Windows.Forms.GroupBox();
            this.DiscountBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(100, 252);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(129, 40);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // priceBox
            // 
            this.priceBox.Location = new System.Drawing.Point(100, 62);
            this.priceBox.MinimumSize = new System.Drawing.Size(50, 4);
            this.priceBox.Name = "priceBox";
            this.priceBox.Size = new System.Drawing.Size(129, 20);
            this.priceBox.TabIndex = 2;
            this.priceBox.TextChanged += new System.EventHandler(this.priceBox_TextChanged);
            this.priceBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.priceBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Введите цену товара!";
            // 
            // discountValueBox
            // 
            this.discountValueBox.Location = new System.Drawing.Point(100, 216);
            this.discountValueBox.MinimumSize = new System.Drawing.Size(50, 4);
            this.discountValueBox.Name = "discountValueBox";
            this.discountValueBox.Size = new System.Drawing.Size(129, 20);
            this.discountValueBox.TabIndex = 7;
            this.discountValueBox.TextChanged += new System.EventHandler(this.discountValueBox_TextChanged);
            this.discountValueBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.discountValueBox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(97, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Введите значение скидки";
            // 
            // percentRadioButton
            // 
            this.percentRadioButton.AutoSize = true;
            this.percentRadioButton.Location = new System.Drawing.Point(6, 19);
            this.percentRadioButton.Name = "percentRadioButton";
            this.percentRadioButton.Size = new System.Drawing.Size(97, 17);
            this.percentRadioButton.TabIndex = 8;
            this.percentRadioButton.TabStop = true;
            this.percentRadioButton.Text = "По процентам";
            this.percentRadioButton.UseVisualStyleBackColor = true;
            this.percentRadioButton.CheckedChanged += new System.EventHandler(this.percentRadioButton_CheckedChanged);
            // 
            // couponRadioButton
            // 
            this.couponRadioButton.AutoSize = true;
            this.couponRadioButton.Location = new System.Drawing.Point(6, 42);
            this.couponRadioButton.Name = "couponRadioButton";
            this.couponRadioButton.Size = new System.Drawing.Size(76, 17);
            this.couponRadioButton.TabIndex = 9;
            this.couponRadioButton.TabStop = true;
            this.couponRadioButton.Text = "По купону";
            this.couponRadioButton.UseVisualStyleBackColor = true;
            this.couponRadioButton.CheckedChanged += new System.EventHandler(this.couponRadionButton_CheckedChanged);
            // 
            // DiscountBox
            // 
            this.DiscountBox.Controls.Add(this.percentRadioButton);
            this.DiscountBox.Controls.Add(this.couponRadioButton);
            this.DiscountBox.Location = new System.Drawing.Point(100, 99);
            this.DiscountBox.Name = "DiscountBox";
            this.DiscountBox.Size = new System.Drawing.Size(129, 82);
            this.DiscountBox.TabIndex = 10;
            this.DiscountBox.TabStop = false;
            this.DiscountBox.Text = "Тип скидки";
            // 
            // FormDialogAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 338);
            this.ControlBox = false;
            this.Controls.Add(this.DiscountBox);
            this.Controls.Add(this.discountValueBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.priceBox);
            this.Controls.Add(this.buttonAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormDialogAdd";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление товара";
            this.TopMost = true;
            this.DiscountBox.ResumeLayout(false);
            this.DiscountBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox priceBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox discountValueBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton percentRadioButton;
        private System.Windows.Forms.RadioButton couponRadioButton;
        private System.Windows.Forms.GroupBox DiscountBox;
    }
}