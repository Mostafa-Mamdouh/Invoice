using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ItemDto
    {
        public int ItemCode { get; set; }
        [Required(ErrorMessage = "Item Name Is Required")]
        public string ItemName { get; set; }
        [Required(ErrorMessage = "QTY Is Required")]
        public int QTY { get; set; }

        [Required(ErrorMessage = "Price Is Required")]
        public decimal Price { get; set; }
        public int InvoiceId { get; set; }
    }
}
