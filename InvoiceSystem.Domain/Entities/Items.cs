using System;
using System.Collections.Generic;

namespace InvoiceSystem.Domain.Entities
{
    public partial class Items
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string ItemQty { get; set; }
    }
}
