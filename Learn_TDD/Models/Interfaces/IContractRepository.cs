using Learn_TDD.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Learn_TDD.Models.Interfaces
{
    public interface IContractRepository
    {
        IList<Contract> GetAll();
        Contract GetById(int id);
        IList<Contract> GetBySnils(string snils);
    }
}