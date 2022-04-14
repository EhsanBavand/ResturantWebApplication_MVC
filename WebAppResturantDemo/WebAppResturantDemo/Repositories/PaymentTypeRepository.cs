using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages.Html;
using WebAppResturantDemo.Models;

namespace WebAppResturantDemo
{
    public class PaymentTypeRepository
    {
        private MyCrmDB_2Entities db;
        public PaymentTypeRepository()
        {
            db = new MyCrmDB_2Entities();
        }

        public IEnumerable<System.Web.Mvc.SelectListItem> GetAllPaymentType()
        {
            var objSelectedListItem = new List<System.Web.Mvc.SelectListItem>();
            objSelectedListItem = (from item in db.PaymentTypes
                                   select new System.Web.Mvc.SelectListItem()
                                   {
                                       Text = item.PaymentTypeName,
                                       Value = item.PaymentTypeId.ToString(),
                                       Selected = true
                                   }).ToList();
            return objSelectedListItem;

        }
    }
}