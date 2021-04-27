using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
   public  class ItemsDTL :  BaseEntity
    {
        public int ItemCode { get; set; }
        public string ItemName { get; set; }
        public int QTY { get; set; }
        public decimal Price { get; set; }

        public int InvoiceId { get; set; }

        public InvoiceHDR InvoiceHDR { get; set; }
    }
}
