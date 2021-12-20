using MechanicWebAppAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MechanicWebAppAPI.Core.Interfaces
{
    public interface IRepairs
    {
        Task<IEnumerable<Repair>> Get();

        Task<Repair> Get(Guid Repair_id);

        Task<Repair> Create(Repair repair);

        Task Update(Repair repair);

        Task Delete(Guid Repair_id);
    }
}
