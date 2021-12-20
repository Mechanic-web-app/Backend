using AutoMapper;
using MechanicWebAppAPI.Data.Database;

namespace MechanicWebAppAPI.Core.Repositories
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context;
        protected readonly IMapper _mapper;
        public BaseRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
