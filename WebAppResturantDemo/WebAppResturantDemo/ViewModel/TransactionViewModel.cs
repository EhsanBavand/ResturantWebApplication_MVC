﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppResturantDemo.ViewModel
{
    public class TransactionViewModel
    {
        public int TransactionId { get; set; }
        public int ItemId { get; set; }
        public decimal Quantity { get; set; }
        public DateTime TransactionDate { get; set; }
        public int TypeId { get; set; }
    }
}