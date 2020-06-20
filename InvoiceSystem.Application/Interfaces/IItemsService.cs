using InvoiceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceSystem.Application.Interfaces
{
    public interface IItemsService
    {
        IEnumerable<Items> GetAllItems();
        string GetItemName(int Id);
    }
}
