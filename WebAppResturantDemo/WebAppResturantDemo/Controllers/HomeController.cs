using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppResturantDemo.Models;
using WebAppResturantDemo.Repositories;
using WebAppResturantDemo.ViewModel;

namespace WebAppResturantDemo.Controllers
{
    public class HomeController : Controller
    {
        private MyCrmDB_2Entities db;

        public HomeController()
        {
            db = new MyCrmDB_2Entities();
        }


        // GET: Home
        public ActionResult Index()
        {
            CustomerRepository _customerRepository = new CustomerRepository();
            PaymentTypeRepository _paymentTypeRepository = new PaymentTypeRepository();
            ItemRepository _itemRepository = new ItemRepository();

            var objAllModels = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>
                                    (_customerRepository.GetAllCustomers(), _paymentTypeRepository.GetAllPaymentType(), _itemRepository.GetAllItems());


            return View(objAllModels);
        }

        [HttpGet]
        //public ActionResult getItemUnitPrice(int itemId)
        public JsonResult getItemUnitPrice(int itemId) 
        {
            decimal unitPrice = db.Items.Single(x => x.ItemId == itemId).ItemPrice;
            return Json(unitPrice, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Index(OrderViewModel orderViewModel)
        {
            OrderRepository orderRepository = new OrderRepository();
            orderRepository.AddOrder(orderViewModel);

            return Json("Your Order Has Been Successfully Created", JsonRequestBehavior.AllowGet); 
        }
    }
}