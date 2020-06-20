using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceSystem.Infrastructure.ViewModel
{
    public class InvoiceItemsViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="This is Required Field")]
        public int? ItemId { get; set; }

        [Required(ErrorMessage = "This is Required Field")]
        public int? UnitId { get; set; }

        [Required(ErrorMessage = "This is Required Field")]
        [RegularExpression(@"^[0-9]*\.?[0-9]+$", ErrorMessage ="This Field Accept Number Only")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "This is Required Field")]
        [RegularExpression(@"^[0-9]*\.?[0-9]+$", ErrorMessage = "This Field Accept Number Only")]
        public int? ItemsQty { get; set; }

        [Required(ErrorMessage = "This is Required Field")]
        [RegularExpression(@"^[0-9]*\.?[0-9]+$", ErrorMessage = "This Field Accept Number Only")]
        public int? Discount { get; set; }

        [Required(ErrorMessage = "This is Required Field")]
        [RegularExpression(@"^[0-9]*\.?[0-9]+$", ErrorMessage = "This Field Accept Number Only")]
        public decimal? Total { get; set; }

        [Required(ErrorMessage = "This is Required Field")]
        [RegularExpression(@"^[0-9]*\.?[0-9]+$", ErrorMessage = "This Field Accept Number Only")]
        public decimal? NetPrice { get; set; }

    }
}
