using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceSystem.Infrastructure.ViewModel
{
    public class InvoiceViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This is Required Field")]
        public string InvoiceNo { get; set; }

        [Required(ErrorMessage = "This is Required Field")]
        public DateTime? InvoiceDate { get; set; }

        [Required(ErrorMessage = "This is Required Field")]
        public int? StoreId { get; set; }

        [Required(ErrorMessage = "This is Required Field")]
        public decimal? TotalPrice { get; set; }

        [Required(ErrorMessage = "This is Required Field")]
        public decimal? NetPriceTotal { get; set; }


        public InvoiceItemsViewModel InvoiceItem { set; get; } = new InvoiceItemsViewModel();
    }
}
