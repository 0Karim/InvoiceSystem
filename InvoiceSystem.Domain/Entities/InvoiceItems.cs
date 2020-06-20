using System;
using System.Collections.Generic;

namespace InvoiceSystem.Domain.Entities
{
    public partial class InvoiceItems
    {
        public int Id { get; set; }
        public int? ItemId { get; set; }
        public int? UnitId { get; set; }
        public decimal? Price { get; set; }
        public int? ItemsQty { get; set; }
        public int? Discount { get; set; }
        public decimal? Total { get; set; }
        public decimal? NetPrice { get; set; }
        public int? InvoiceId { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual Items Item { get; set; }
        public virtual Units Unit { get; set; }
    }
}
