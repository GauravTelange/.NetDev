using Microsoft.AspNetCore.Mvc;
using CustomerApplication.Models;
using CustomerApplication.Dal;
namespace CustomerApplication.Controllers
{
    
    public class CustomerController : Controller
    {
        IDal dal = null;
        public CustomerController(IDal _dal)
        {
           dal = _dal;
        }


        public IActionResult LoadCustomer()
        {
            return View("CustomerScreen");
        }
        public IActionResult Add(Customer obj)
        {
        
            return View("DisplayCustomer", obj);
        }

        public IActionResult New()
        {
            return View("CustomerScreen");
        }
    }
}
 