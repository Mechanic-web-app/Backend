using MechanicWebAppAPI.Common.Requests.OpinionRequests;
using MechanicWebAppAPI.Core.Dtos.Opinion;
using MechanicWebAppAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MechanicWebAppAPI.Core.Interfaces
{
    public interface IOpinions
    {
        Task<IEnumerable<OpinionDto>> Get();

        Task<Opinion> Get(Guid Opinion_id);

        Task<OpinionDto> Create(OpinionAddRequest opinion);

        Task Update(Opinion opinion);

        Task Delete(Guid Opinion_id);
    }
}
