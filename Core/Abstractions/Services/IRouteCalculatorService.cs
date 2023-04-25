using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstractions.Services
{
    public interface IRouteCalculatorService
    {
        public Task<List<Address>> FindShortestRoute(Address startAddress, Address endAddress, List<Address> nodesToVisit);
    }
}
