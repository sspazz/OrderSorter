using AutoMapper;
using Core.Abstractions.Repository;
using Core.Abstractions.Services;
using Core.DTOs;
using Core.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class HistoricalDataService : GenericService<HistoricalData, HistoricalDataDTO>, IHistoricalDataService
    {
        private readonly IHistoricalDataRepository _historicalDataRepository;

        public HistoricalDataService(ILogger logger, IHistoricalDataRepository historicalDataRepository, IMapper mapper) : base(logger, historicalDataRepository, mapper)
        {
            historicalDataRepository = _historicalDataRepository;
        }
    }
}
