using InvoiceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceSystem.Application.Interfaces
{
    public interface IStoreService
    {
        IEnumerable<Stores> GetAllStores();
    }
}
