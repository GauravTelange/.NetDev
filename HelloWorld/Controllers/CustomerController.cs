using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloWorld.Models;

namespace HelloWorld.Controllers
{
    public class CustomerBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpContextBase obj = controllerContext.HttpContext;
            string custCode = obj.Request.Form["CustomerCode"];
            string custName = obj.Request.Form["CustomerName"];

            Customer customer = new Customer
            {
                CustomerCode = custCode, 
                CustomerName = custName,
            };

            return customer;

        }
    }
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Load()
        {
            Customer obj = new Customer
            {
                CustomerCode = "100",
                CustomerName = "John Doe"
            };
            return View("Customer", obj);
        }
        public ActionResult Enter()
        {
            return View("EnterCustomer");
        }
        public ActionResult Submit( [ModelBinder( typeof(CustomerBinder))] Customer obj)
        {

            return View("Customer",obj);
        }
    }
}