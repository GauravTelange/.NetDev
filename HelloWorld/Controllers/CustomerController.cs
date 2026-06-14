using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloWorld.Models;
using HelloWorld.Dal;
using HelloWorld.ViewModel;
using System.Threading;

namespace HelloWorld.Controllers
{
    public class CustomerBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpContextBase obj = controllerContext.HttpContext;
            string custCode = obj.Request.Form["CustomerCode"];
            string custName = obj.Request.Form["CustomerName"];
            string custAmount =         obj.Request.Form["CustomerAmount"];

            Customer customer = new Customer
            {
                CustomerCode = custCode,
                CustomerName = custName,
                CustomerAmount = Convert.ToDecimal(custAmount)
            };

            return customer;

        }
    }
    public class CustomerUIController : Controller
    {
        // GET: Customer

        public ActionResult EnterCustomer()
        {
            return View();

        }
        //public ActionResult Load()
        //{
        //    Customer obj = new Customer
        //    {
        //        CustomerCode = "100",
        //        CustomerName = "John Doe"
        //    };
        //    return View("Customer", obj);
        //}
        //public ActionResult Enter()
        //{
        //    CustomerViewModel obj = new CustomerViewModel();
        //    obj.customer = new Customer();

        //    //CustomerDal dal = new CustomerDal();
        //    //List<Customer> customerscoll  = dal.Customers.ToList<Customer>();
        //    //obj.customers = customerscoll;
        //    //Thread.Sleep(10000);
        //    return View("EnterCustomer", obj);
        //}

        //public ActionResult EnterSearch()
        //{
        //    CustomerViewModel obj = new CustomerViewModel();
        //    obj.customers = new List<Customer>();
        //    return View("SearchCustomer", obj);
        //}

        public ActionResult SearchCustomer()
        {
            CustomerViewModel obj = new CustomerViewModel();

            string customerName = Request.Form["txtCustomerName"];

            CustomerDal dal = new CustomerDal();

            obj.customers = dal.Customers
                               .Where(x => x.CustomerName == customerName)
                               .ToList();

            return View("SearchCustomer", obj);
        }

        //public ActionResult GetCustomers()
        //{
        //    CustomerDal dal = new CustomerDal();
        //    List<Customer> customerscoll = dal.Customers.ToList<Customer>();
        //    //Thread.Sleep(10000);
        //    return Json(customerscoll, JsonRequestBehavior.AllowGet);
        //}
        //[ActionName("GetCustomersByName")]
        //public ActionResult GetCustomers(Customer obj)
        //{
        //    CustomerDal dal = new CustomerDal();
        //    List<Customer> customerscoll = (from c in dal.Customers
        //                                    where c.CustomerName == obj.CustomerName
        //                                    select c).ToList<Customer>();
        //    //Thread.Sleep(10000);
        //    return Json(customerscoll, JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //public ActionResult Submit(Customer obj)
        //{


        //    if (ModelState.IsValid)
        //    {
        //        CustomerDal Dal = new CustomerDal();
        //        Dal.Customers.Add(obj);
        //        Dal.SaveChanges();
        //        //vm.customer = new Customer();
        //    }

        //    CustomerDal dal = new CustomerDal();
        //    List<Customer> customerscoll = dal.Customers.ToList<Customer>();


        //    return Json(customerscoll, JsonRequestBehavior.AllowGet);

        //}
    }
}