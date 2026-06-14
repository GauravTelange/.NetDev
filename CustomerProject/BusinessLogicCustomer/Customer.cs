using System;
namespace BusinessLogicCustomer
{
    public class Customer
    {
        public int CustomerID { get; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public int ProductID  { get; set; }
        public decimal BillAmount { get; set; }
        public string ProductName { get; set; }


        public Customer() {
            
            CustomerName = "";
            PhoneNumber = "";
            ProductID = 0;
            BillAmount = 0;

        }

        public bool Validate() {
            if (CustomerName.Length == 0)
            {
               throw new Exception("Customer Name is required");
            }

            if (PhoneNumber.Length == 0)
            {
                throw new Exception("Phone Number is required");
            }

            if (ProductID == 0)
            {
                throw new Exception("Product ID is required");
            }
            if(BillAmount <= 0)
            {
                throw new Exception("Bill Amount should be greater than zero");
            }
            return true;
        }

    }
}
