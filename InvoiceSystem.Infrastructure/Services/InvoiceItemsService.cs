using InvoiceSystem.Application.Interfaces;
using InvoiceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvoiceSystem.Infrastructure.Services
{
    public class InvoiceItemsService : IInvoiceItemsService
    {
        private readonly IRepository<InvoiceItems> _invoiceRepository;

        public InvoiceItemsService(IRepository<InvoiceItems> repository)
        {
            _invoiceRepository = repository;
        }

        public int AddInvoiceItem(InvoiceItems entity)
        {
            return _invoiceRepository.Add(entity);
        }

        public List<InvoiceItems> GetAllInvoiceItemsDT(int take, int skip, out int recordsCount)
        {
            var items = _invoiceRepository.GetAll().Where(x => x.Invoice == null);

            recordsCount = items.ToList().Count();

            return items.ToList().Take(take).Skip(skip).ToList();
        }
    }
}
