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
        private List<Product> productList = new List<Product>();
        public MainForm()
        {
            InitializeComponent();
           // bindingSource1.
            //productTable.DataSource = bindingSource1;
            
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            var form = new FormDialogAdd();
            form.ShowDialog();
        }
    }
}
