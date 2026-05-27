using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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

        private void CustomerUI_Load_1(object sender, EventArgs e)
        {
            this.Text = ConfigurationManager.AppSettings["NameoftheApplication"].ToString();
            button1.Text = ConfigurationManager.AppSettings["AddButton"].ToString();
            btnUpdate.Text = ConfigurationManager.AppSettings["UpdateButton"].ToString();
            btnDelete.Text = ConfigurationManager.AppSettings["DeleteButton"].ToString();

            loadGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowselected = e.RowIndex;
            txtCustomerid.Text = dataGridView1.Rows[rowselected].Cells[0].Value.ToString();
            txtCustomerName.Text = dataGridView1.Rows[rowselected].Cells[1].Value.ToString();
            txtPhoneNumber.Text = dataGridView1.Rows[rowselected].Cells[2].Value.ToString();
            txtProduct.Text = dataGridView1.Rows[rowselected].Cells[3].Value.ToString();
            txtBillAmount.Text = dataGridView1.Rows[rowselected].Cells[4].Value.ToString();

        }

        private void lblPhoneNumber_Click(object sender, EventArgs e)
        {

        }

        private void lblCustomerName_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Customer updatedCust = new Customer();
            updatedCust.CustomerName = txtCustomerName.Text;
            updatedCust.PhoneNumber = txtPhoneNumber.Text;
            updatedCust.ProductName = txtProduct.Text;
            updatedCust.BillAmount = Convert.ToDecimal(txtBillAmount.Text);

            CustomerDal dal = new CustomerDal();
            dal.Update(updatedCust, Convert.ToInt32(txtCustomerid.Text));
            MessageBox.Show("Customer updated successfully.");
            loadGrid();

            ClearUI();

        }

        private void ClearUI()
        {
            txtCustomerName.Text = "";
            txtPhoneNumber.Text = "";
            txtProduct.Text = "";
            txtBillAmount.Text = ""; ;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int Customerid = Convert.ToInt32(txtCustomerid.Text);
            CustomerDal dal = new CustomerDal();
            dal.Delete(Customerid);
            MessageBox.Show("Customer deleted successfully.");
            loadGrid();

        }
    }
}

