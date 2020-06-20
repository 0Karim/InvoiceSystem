using System;
using System.Collections.Generic;

namespace InvoiceSystem.Domain.Entities
{
    public partial class Invoice
    {
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public int? StoreId { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? NetPrice { get; set; }

        public virtual Stores Store { get; set; }
    }
}
