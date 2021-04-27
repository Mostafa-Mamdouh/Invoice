using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
   public  class InvoiceHDR : BaseEntity
    {
        public InvoiceHDR()
        {
            ItemsDTLs = new HashSet<ItemsDTL>();
        }
        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public bool PaymentMethod { get; set; }
        public string Customer { get; set; }
        public string Description { get; set; }

        public ICollection<ItemsDTL> ItemsDTLs { get; set; }
    }
}
