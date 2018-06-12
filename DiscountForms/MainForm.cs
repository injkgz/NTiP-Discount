using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Discount;

namespace DiscountForms
{
    public partial class MainForm : Form
    {
        private List<CheckPosition> checkList = new List<CheckPosition>();
        public MainForm()
        {
            InitializeComponent();
            bindingSourceCheckPosition.DataSource = checkList;
            productTable.DataSource = bindingSourceCheckPosition;
            

        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            var form = new FormDialogAdd(bindingSourceCheckPosition);
            form.ShowDialog();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            int index = productTable.CurrentRow.Index;
            productTable.Rows.Remove(productTable.Rows[index]);
        }
    }
}
