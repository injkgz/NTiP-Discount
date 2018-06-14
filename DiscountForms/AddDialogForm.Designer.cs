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
            this.ObjectControl = new DiscountForms.ModifyObject();
            this.SuspendLayout();
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(4, 220);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(145, 40);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // ObjectControl
            // 
            this.ObjectControl.DiscountsType = DiscountForms.Discounts.Coupon;
            this.ObjectControl.DiscountValue = "";
            this.ObjectControl.Location = new System.Drawing.Point(4, 9);
            this.ObjectControl.Name = "ObjectControl";
            this.ObjectControl.Price = "";
            this.ObjectControl.Size = new System.Drawing.Size(145, 205);
            this.ObjectControl.TabIndex = 1;
            // 
            // AddDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(156, 271);
            this.Controls.Add(this.ObjectControl);
            this.Controls.Add(this.buttonAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddDialogForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление товара";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAdd;
        private ModifyObject AddControl;
        private ModifyObject ControlObject;
        private ModifyObject ObjectControl;
    }
}