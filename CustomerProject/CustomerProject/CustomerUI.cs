using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicCustomer;
using Dal;

namespace CustomerProject
{
    public partial class CustomerUI : Form
    {
        public CustomerUI()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtProduct_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Customer custobj = new Customer();
                custobj.CustomerName = txtCustomerName.Text;
                custobj.PhoneNumber = txtPhoneNumber.Text;
                custobj.ProductName = txtProduct.Text;
                custobj.BillAmount = Convert.ToDecimal(txtBillAmount.Text);


                
                if (custobj.Validate())
                {
                    CustomerDal dal = new CustomerDal();
                    dal.Add(custobj);
                }
            }

               
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadGrid()
        {
            CustomerDal dal = new CustomerDal();
            DataSet customers = dal.Read();
            dataGridView1.DataSource = customers.Tables[0];
        }

        private void CustomerUI_Load(object sender, EventArgs e)
        {
            loadGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}

