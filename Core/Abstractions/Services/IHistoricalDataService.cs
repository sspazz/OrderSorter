﻿using Core.DTOs;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstractions.Services
{
    public interface IHistoricalDataService : IGenericService<HistoricalData, HistoricalDataDTO>
    {
    }
}
