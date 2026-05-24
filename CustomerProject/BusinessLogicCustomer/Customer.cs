namespace BusinessLogicCustomer
{
    public class Customer
    {
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string ProductName { get; set; }
        public decimal BillAmount { get; set; }

        public Customer() {
            CustomerName = "";
            PhoneNumber = "";
            ProductName = "";
            BillAmount = 0;

        }

        public void Validate() {
            if (CustomerName.Length == 0)
            {
               throw new Exception("Customer Name is required");
            }

            if (PhoneNumber.Length == 0)
            {
                throw new Exception("Phone Number is required");
            }

            if (ProductName.Length == 0)
            {
                throw new Exception("Prouduct Name is required");
            }
            if(BillAmount <= 0)
            {
                throw new Exception("Bill Amount should be greater than zero");
            }
        }

    }
}
