using InvoiceSystem.Application.Interfaces;
using InvoiceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceSystem.Infrastructure.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IRepository<Invoice> _invoiceRepository;

        public InvoiceService(IRepository<Invoice> repository)
        {
            _invoiceRepository = repository;
        }


    }
}
