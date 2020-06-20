using System;
using System.Collections.Generic;

namespace InvoiceSystem.Domain.Entities
{
    public partial class Units
    {
        public Units()
        {
            InvoiceItems = new HashSet<InvoiceItems>();
        }

        public int Id { get; set; }
        public string UnitName { get; set; }

        public virtual ICollection<InvoiceItems> InvoiceItems { get; set; }
    }
}
