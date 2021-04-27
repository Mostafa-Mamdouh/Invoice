using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class InvoiceDto
    {
        public int InvoiceId { get; set; }
        [Required (ErrorMessage ="Invoice Date Is Required")]
        public DateTime InvoiceDate { get; set; }
        [Required(ErrorMessage = "Payment Method Is Required")]
        public bool PaymentMethod { get; set; }

        [Required(ErrorMessage = "Customer Is Required")]
        public string Customer { get; set; }
        public string Description { get; set; }
        public ICollection<ItemDto> itemDtos { get; set; }
    }
}
