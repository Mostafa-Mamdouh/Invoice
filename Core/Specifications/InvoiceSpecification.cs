using Core.Entities;
using System.Linq;

namespace Core.Specifications
{
    public class InvoiceSpecification : BaseSpecifcation<InvoiceHDR>
    {
       

        public InvoiceSpecification(int id) : base(x => x.InvoiceId == id)
        {
            AddInclude(x => x.ItemsDTLs);
        }
    }
}
