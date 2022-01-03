using MechanicWebAppAPI.Common.Requests.RepairRequests;
using MechanicWebAppAPI.Core.Dtos.Repair;
using MechanicWebAppAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MechanicWebAppAPI.Core.Interfaces
{
    public interface IRepairs
    {
        Task<IEnumerable<RepairDto>> Get();

        Task<Repair> Get(Guid Repair_id);
        Task<IEnumerable<RepairDto>> GetByCar(Guid Repaired_car_id);

        Task<RepairDto> Create(RepairAddRequest car);

        Task Update(Repair repair);

        Task Delete(Guid Repair_id);
    }
}
