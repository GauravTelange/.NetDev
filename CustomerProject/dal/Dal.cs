using BusinessLogicCustomer;
using System;
using System.Collections.Generic;
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
               

                string sql = "INSERT INTO tblCustomer (CustomerName, PhoneNumber, Productfk, BillAmount) " +
                             "VALUES (@name, @phone, @product, @amount)";

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@name", obj.CustomerName);
                    command.Parameters.AddWithValue("@phone", obj.PhoneNumber);
                    command.Parameters.AddWithValue("@product", obj.ProductID);
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

        public List<Customer> Read()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection conn = CreateConnection())
            using (SqlCommand command = conn.CreateCommand())
            {
                command.CommandText = @"
                    SELECT tblCustomer.CustomerId AS CustomerId,
                           tblCustomer.CustomerName,
                           tblCustomer.PhoneNumber,
                           tblCustomer.BillAmount,
                           tblCustomer.Productfk AS ProductId,
                           tblProdmst.Productname AS ProductName
                    FROM tblCustomer
                    INNER JOIN tblProdmst ON tblCustomer.Productfk = tblProdmst.ProductId";

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int id = Convert.ToInt32(dr["CustomerId"]);
                        Customer obj = new Customer(id);
                        obj.CustomerName = dr["CustomerName"].ToString();
                        obj.PhoneNumber = dr["PhoneNumber"].ToString();
                        obj.BillAmount = Convert.ToDecimal(dr["BillAmount"]);
                        obj.ProductID = Convert.ToInt32(dr["ProductId"]);
                        obj.ProductName = dr["ProductName"].ToString();
                        customers.Add(obj);
                    }
                }
            }

            return customers;
                 
            
            
        }


        public bool Update(Customer obj,int  Customerid)
        {
            try
            {
                SqlConnection conn = CreateConnection();

                string sql = "UPDATE tblCustomer SET CustomerName = @name, PhoneNumber = @phone, Productfk = @product, BillAmount = @amount " +
                             "WHERE CustomerId = @id";

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@name", obj.CustomerName);
                    command.Parameters.AddWithValue("@phone", obj.PhoneNumber);
                    command.Parameters.AddWithValue("@product", obj.ProductID);
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

        public DataSet ReadProduct()
        {

            string constr = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Customerdb;Integrated Security=True;TrustServerCertificate=True";


            SqlConnection conn = new SqlConnection(constr);
            conn.Open();


            SqlCommand command = new SqlCommand();
            command.Connection = conn;

            command.CommandText = "SELECT ProductId, Productname FROM tblProdmst";

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet products = new DataSet();
            adapter.Fill(products);

            conn.Close();
            return products;



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

    public class Customer
    {
        public int CustomerID { get; private set; }   
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public int ProductID { get; set; }
        public decimal BillAmount { get; set; }
        public string ProductName { get; set; }   // <-- added

        public Customer(int id)
        {
            CustomerID = id;
        }

        public bool Validate()
        {
            return true;
        }
    }
}
