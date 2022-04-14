using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppResturantDemo.Models;
using WebAppResturantDemo.ViewModel;

namespace WebAppResturantDemo.Repositories
{
    public class OrderRepository
    {
        private MyCrmDB_2Entities db;

        public OrderRepository()
        {
            db = new MyCrmDB_2Entities();
        }

        public bool AddOrder(OrderViewModel objOrderViewModel)
        {
            Order objOrder = new Order();
            objOrder.CustomerId = objOrderViewModel.CustomerId;
            objOrder.FinalTotal = objOrderViewModel.FinalTotal;
            objOrder.OrderDate = DateTime.Now;
            objOrder.OrderNumber = String.Format("{0:ddmmyyyyhhmmss}", DateTime.Now);
            objOrder.PaymentTypeId = objOrderViewModel.PaymentTypeId;
            db.Orders.Add(objOrder);
            db.SaveChanges();

            int orderId = objOrder.OrderId;
            foreach (var item in objOrderViewModel.ListOrderDetailViewModels)
            {
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.OrderId = orderId;
                orderDetail.Discount = item.Discount;
                orderDetail.Total = item.Total; 
                orderDetail.ItemId = item.ItemId;
                orderDetail.UnitPrice = item.UnitPrice;
                orderDetail.Quantity = item.Quantity;

                db.OrderDetails.Add(orderDetail);
                db.SaveChanges();

                Transaction transaction =  new Transaction();
                transaction.ItemId = item.ItemId;   
                transaction.Quantity = (-1) * item.Quantity;
                transaction.TransactionDate = DateTime.Now;
                transaction.TypeId = 2;
                db.Transactions.Add(transaction);
                db.SaveChanges();
            }



            return true;
        }
    }
}