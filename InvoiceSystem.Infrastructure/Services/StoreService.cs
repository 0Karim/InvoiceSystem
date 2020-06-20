using InvoiceSystem.Application.Interfaces;
using InvoiceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceSystem.Infrastructure.Services
{
    public class StoreService : IStoreService
    {
        private readonly IRepository<Stores> _storeRepository;

        public StoreService(IRepository<Stores> repository)
        {
            _storeRepository = repository;
        }

        public IEnumerable<Stores> GetAllStores()
        {
            return _storeRepository.GetAll();
        }
    }
}
