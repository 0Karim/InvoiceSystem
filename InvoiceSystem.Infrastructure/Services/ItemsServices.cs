using InvoiceSystem.Application.Interfaces;
using InvoiceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceSystem.Infrastructure.Services
{
    public class ItemsServices : IItemsService
    {
        private readonly IRepository<Items> _itemsRepository;


        public ItemsServices(IRepository<Items> repository)
        {
            _itemsRepository = repository;
        }

        public IEnumerable<Items> GetAllItems()
        {
            return _itemsRepository.GetAll();
        }

        public string GetItemName(int Id)
        {
            return _itemsRepository.GetById(Id).ItemName;
        }
    }
}
