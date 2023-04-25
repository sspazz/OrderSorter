using Core.DTOs;
using Core.Models;

namespace Core.Abstractions.Services
{
    public interface IDailyRouteService : IGenericService<DailyRoute, DailyRouteDTO>
    {
        public Task<List<DailyRouteDTO>> Get(DateTime dt);
    }
}
