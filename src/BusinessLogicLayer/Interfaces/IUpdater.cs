using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Interfaces
{
    public interface IUpdater
    {
        Task Update(List<Website> data);
    }
}