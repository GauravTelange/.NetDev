using BusinessLogicCustomer;

namespace CustomerUIForSuperUsers {
    public class Program {

        static void Main() {

            try
            {
                Customer obj = new Customer();
                obj.CustomerName = Console.ReadLine();
                
                obj.Validate();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



        }
    }
}