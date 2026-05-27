using BusinessLogicCustomer;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Dal
{
    public class CustomerDal
    {
        public SqlConnection CreateConnection()
        {
             string constr = System.Configuration.ConfigurationManager.ConnectionStrings["DbConn"].ConnectionString;
              
             SqlConnection conn = new SqlConnection(constr);
          
             conn.Open();
             
             return conn;
        }
        public bool Add(Customer obj)
        {
            try
            {
                SqlConnection conn =  CreateConnection();
               

                string sql = "INSERT INTO tblCustomer (CustomerName, PhoneNumber, ProductName, BillAmount) " +
                             "VALUES (@name, @phone, @product, @amount)";

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@name", obj.CustomerName);
                    command.Parameters.AddWithValue("@phone", obj.PhoneNumber);
                    command.Parameters.AddWithValue("@product", obj.ProductName);
                    command.Parameters.AddWithValue("@amount", obj.BillAmount);
                   
                    command.ExecuteNonQuery();
                    MessageBox.Show("Customer Added successfully.");
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

                command.CommandText = "Select CustomerId,CustomerName,PhoneNumber,ProductName,BillAmount from tblCustomer";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet customers = new DataSet();
                adapter.Fill(customers);

                conn.Close();
                return customers;
                
            
            
        }


        public bool Update(Customer obj,int  Customerid)
        {
            try
            {
                SqlConnection conn = CreateConnection();

                string sql = "UPDATE tblCustomer SET CustomerName = @name, PhoneNumber = @phone, ProductName = @product, BillAmount = @amount " +
                             "WHERE CustomerId = @id";

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@name", obj.CustomerName);
                    command.Parameters.AddWithValue("@phone", obj.PhoneNumber);
                    command.Parameters.AddWithValue("@product", obj.ProductName);
                    command.Parameters.AddWithValue("@amount", obj.BillAmount);
                    command.Parameters.AddWithValue("@id", Customerid);

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

        public bool Delete(int CustomerId)
        {
            try
            {
                SqlConnection conn = CreateConnection();

                string sql = "Delete from tblCustomer "+
                             "WHERE CustomerId = @id";

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                   
                    command.Parameters.AddWithValue("@id", CustomerId);
                    MessageBox.Show("Customer deleted successfully.");
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
    }
}
