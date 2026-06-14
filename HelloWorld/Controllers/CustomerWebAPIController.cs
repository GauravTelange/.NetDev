using HelloWorld.Dal;
using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace HelloWorld.Controllers
{
    public class Error
    {
        public List<string> Errors { get; set; } = new List<string>();
    }
    public class ClientData
    {
        public bool IsValid { get; set; }
        public object Data { get; set; }
    }
    public class CustomerController : ApiController
    {
        //Insert
        public Object Post(Customer obj)
        {
            ClientData Data = new ClientData();
            if (ModelState.IsValid)
            {
                CustomerDal Dal = new CustomerDal();
                Dal.Customers.Add(obj);
                Dal.SaveChanges();
            }
            else
            {
                var Err = new Error();
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Err.Errors.Add(error.ErrorMessage);
                    }
                }
                Data.IsValid = false;
                Data.Data = Err;
                return Data;
            }
            CustomerDal dal = new CustomerDal();
            List<Customer> customerscoll = dal.Customers.ToList<Customer>();
            Data.IsValid = true;
            Data.Data = customerscoll;
            return customerscoll;
        }

        //Select
        public List<Customer> Get()
        {
            var allUrlKeyValues = ControllerContext.Request.GetQueryNameValuePairs();

            string CustomerCode = allUrlKeyValues.SingleOrDefault(x => x.Key == "CustomerCode").Value;

            string CustomerName = allUrlKeyValues.SingleOrDefault(x => x.Key == "CustomerName").Value;

            CustomerDal dal = new CustomerDal();
            List<Customer> customerscoll = new List<Customer>();

            customerscoll = dal.Customers.ToList<Customer>();
            if (CustomerName != null)
            {
                customerscoll = (from t in customerscoll
                                 where t.CustomerName == CustomerName
                                 select t).ToList<Customer>();
            }
             if (CustomerCode != null)
            {
                customerscoll = (from t in customerscoll
                                 where t.CustomerCode == CustomerCode
                                 select t).ToList<Customer>();
            }
            //else
            //{
            //    customerscoll = dal.Customers.ToList<Customer>();
            //}
                return customerscoll;
        }

        
        //Update
        public List<Customer> Put(Customer obj)
        {
            CustomerDal dal = new CustomerDal();
            Customer custupdate = (from temp in dal.Customers
                            where temp.CustomerCode == obj.CustomerCode
                            select temp).ToList<Customer>()[0];

            custupdate.CustomerName = obj.CustomerName;
            custupdate.CustomerAmount = obj.CustomerAmount;

            List<Customer> customerscoll = dal.Customers.ToList<Customer>();
            return customerscoll;
        }
        //Delete
        public List<Customer> Delete(Customer obj)
        {
            CustomerDal dal = new CustomerDal();
            Customer custdelete = (from temp in dal.Customers
                                   where temp.CustomerCode == obj.CustomerCode
                                   select temp).ToList<Customer>()[0];
            dal.Customers.Remove(custdelete);
            dal.SaveChanges();
            List<Customer> customerscoll = dal.Customers.ToList<Customer>();
            return customerscoll;
        }
    }
}
