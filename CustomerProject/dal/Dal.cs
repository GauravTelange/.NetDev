using BusinessLogicCustomer;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Dal
{
    public class CustomerDal
    {
        public bool Add(Customer obj)
        {
            try
            {
                string constr = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Customerdb;Integrated Security=True;TrustServerCertificate=True";

                
                SqlConnection conn = new SqlConnection(constr); 
                conn.Open();

                string sql = "INSERT INTO tblCustomer (CustomerName, PhoneNumber, ProductName, BillAmount) " +
                             "VALUES (@name, @phone, @product, @amount)";

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@name", obj.CustomerName);
                    command.Parameters.AddWithValue("@phone", obj.PhoneNumber);
                    command.Parameters.AddWithValue("@product", obj.ProductName);
                    command.Parameters.AddWithValue("@amount", obj.BillAmount);

                    command.ExecuteNonQuery();
                }

                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

        public DataSet Read()
        {
            
                string constr = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Customerdb;Integrated Security=True;TrustServerCertificate=True";


                SqlConnection conn = new SqlConnection(constr);
                conn.Open();


                SqlCommand command = new SqlCommand();
                command.Connection = conn;

                command.CommandText = "Select CustomerId,CustomerName,BillAmount from tblCustomer";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet customers = new DataSet();
                adapter.Fill(customers);

                conn.Close();
                return customers;
                
            
            
        }
    }
}
