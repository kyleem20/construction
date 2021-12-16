using System;
using System.Collections.Generic;
using construction.Models;
using construction.Repositories;

namespace construction.Services
{
    public class ContractorsService
    {
        private readonly ContractorsRepository _repo;
        public ContractorsService(ContractorsRepository repo)
        {
            _repo = repo;
        }
        internal List<Contractor> Get()
        {
            return _repo.Get();
        }
        internal Contractor Get(int id)
        {
            Contractor found = _repo.Get(id);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }
        internal Contractor Create(Contractor newContractor)
        {
            return _repo.Create(newContractor);
        }
        internal void Remove(int id, string userId)
        {
            Contractor contractor = Get(id);
            if (contractor.CreatorId != userId)
            {
                throw new Exception("You are not allowed to remove this contractor");
            }
            _repo.Remove(id);
        }

    }
}