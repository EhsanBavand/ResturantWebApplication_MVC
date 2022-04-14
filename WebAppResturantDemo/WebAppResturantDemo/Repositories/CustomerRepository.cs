using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppResturantDemo.Models;

namespace WebAppResturantDemo
{
    public class CustomerRepository
    {
        private MyCrmDB_2Entities db;

        public CustomerRepository()
        {
            db = new MyCrmDB_2Entities();
        }

        public IEnumerable<SelectListItem> GetAllCustomers()
        {
            var objSelecteListItems = new List<SelectListItem>();
            objSelecteListItems = (from obj in db.Customers
                                   select new SelectListItem()
                                   {
                                       Text = obj.CustomerName,
                                       Value = obj.CustomerId.ToString(),
                                       Selected = true

                                   }).ToList();

            return objSelecteListItems;
        }
    }
}