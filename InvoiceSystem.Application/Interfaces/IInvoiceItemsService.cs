using InvoiceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceSystem.Application.Interfaces
{
    public interface IInvoiceItemsService
    {
        List<InvoiceItems> GetAllInvoiceItemsDT(int take, int skip, out int recordsCount);
        int AddInvoiceItem(InvoiceItems entity);
    }
}
