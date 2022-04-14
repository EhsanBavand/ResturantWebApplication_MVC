using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppResturantDemo.Models;

namespace WebAppResturantDemo
{
    public class ItemRepository
    {
        private MyCrmDB_2Entities db;
        public ItemRepository()
        {
            db = new MyCrmDB_2Entities();
        }

        public IEnumerable<System.Web.Mvc.SelectListItem> GetAllItems()
        {
            var objSelectedListItem = new List<System.Web.Mvc.SelectListItem>();
            objSelectedListItem = (from item in db.Items
                                   select new System.Web.Mvc.SelectListItem()
                                   {
                                       Text = item.ItemName,
                                       Value = item.ItemId.ToString(),
                                       Selected = true
                                   }).ToList();
            return objSelectedListItem;

        }
    }
}