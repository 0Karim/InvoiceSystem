using InvoiceSystem.Application.Interfaces;
using InvoiceSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceSystem.Infrastructure.Services
{
    public class UnitService : IUnitService
    {
        private readonly IRepository<Units> _unitsRepository;

        public UnitService(IRepository<Units> repository)
        {
            _unitsRepository = repository;
        }

        public IEnumerable<Units> GetAllUnits()
        {
            return _unitsRepository.GetAll();
        }

        public string GetUnitName(int Id)
        {
            return _unitsRepository.GetById(Id).UnitName;
        }
    }
}
