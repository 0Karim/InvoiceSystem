using System;
using System.Collections.Generic;

namespace InvoiceSystem.Domain.Entities
{
    public partial class Stores
    {
        public Stores()
        {
            Invoice = new HashSet<Invoice>();
        }

        public int Id { get; set; }
        public string StoreName { get; set; }

        public virtual ICollection<Invoice> Invoice { get; set; }
    }
}
