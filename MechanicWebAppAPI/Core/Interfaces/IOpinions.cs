using MechanicWebAppAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MechanicWebAppAPI.Core.Interfaces
{
    public interface IOpinions
    {
        Task<IEnumerable<Opinion>> Get();

        Task<Opinion> Get(Guid Opinion_id);

        Task<Opinion> Create(Opinion opinion);

        Task Update(Opinion opinion);

        Task Delete(Guid Opinion_id);
    }
}
