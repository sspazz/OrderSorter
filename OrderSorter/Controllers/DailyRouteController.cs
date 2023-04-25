using Core.Abstractions.Controllers;
using Core.Abstractions.Repository;
using Core.Abstractions.Services;
using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class DailyRouteController : GenericController<DailyRoute, DailyRouteDTO>, IDailyRouteController
    {
        private readonly IDailyRouteService _route;

        public DailyRouteController(Serilog.ILogger logger, IDailyRouteService route, IConfiguration configuration) : base(logger, route, configuration)
        {
            _route = route;
        }

        [HttpGet("routes/{dt}")]
        public async Task<ActionResult<List<DailyRouteDTO>>> Get(DateTime dt)
        {
            return await _route.Get();
        }

    }
}
