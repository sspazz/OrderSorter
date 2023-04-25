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
    public class DailyRouteService : GenericService<DailyRoute, DailyRouteDTO> , IDailyRouteService
    {
        private readonly IDailyRouteRepository _dailyRouteRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IDeliveryPersonRepository _deliveryPersonRepository;
        private readonly IRouteCalculatorService _routeCalculator;

        public DailyRouteService(ILogger logger, IDailyRouteRepository dailyRoutesRepository, IOrderRepository orderRepository, IDeliveryPersonRepository deliveryPersonRepository, IRouteCalculatorService routeCalculator, IMapper mapper) : base(logger, dailyRoutesRepository, mapper)
        {
            _dailyRouteRepository = dailyRoutesRepository;
            _orderRepository = orderRepository;
            _deliveryPersonRepository = deliveryPersonRepository;
            _routeCalculator = routeCalculator;
        }

        public async Task<List<DailyRouteDTO>> Get(DateTime dt)
        {
            try
            {
                var orders = await _orderRepository.GetBy(q => q.Where(x => x.OrderDate == dt));
                var deliveryPersons = await _deliveryPersonRepository.Get();

                int batchSize = 7;
                orders.GetRange(0, 21);
                deliveryPersons.GetRange(0, 3);
                var splittedOrders = orders.Select((o, i) => new { Order = o, Index = i })
                                           .GroupBy(x => x.Index / batchSize)
                                           .Select(g => g.Select(x => x.Order).ToList())
                                           .ToList();

                List<Order> list1 = splittedOrders.ElementAtOrDefault(0) ?? new List<Order>();
                List<Order> list2 = splittedOrders.ElementAtOrDefault(1) ?? new List<Order>();
                List<Order> list3 = splittedOrders.ElementAtOrDefault(2) ?? new List<Order>();

                List<Address> addresses1 = list1.Select(o => o.Address).ToList();
                List<Address> addresses2 = list2.Select(o => o.Address).ToList();
                List<Address> addresses3 = list3.Select(o => o.Address).ToList();

                addresses1 = await _routeCalculator.FindShortestRoute(deliveryPersons[0].DefaultAddress, deliveryPersons[0].DefaultAddress, addresses1);
                addresses2 = await _routeCalculator.FindShortestRoute(deliveryPersons[1].DefaultAddress, deliveryPersons[0].DefaultAddress, addresses1);
                addresses3 = await _routeCalculator.FindShortestRoute(deliveryPersons[2].DefaultAddress, deliveryPersons[0].DefaultAddress, addresses1);


                List<DailyRoute> dailyRoutes = new List<DailyRoute>();
                dailyRoutes.Add(new DailyRoute() { Addresses = addresses1, DeliveryPerson = deliveryPersons[0], DeliveryDate =  dt });
                dailyRoutes.Add(new DailyRoute() { Addresses = addresses2, DeliveryPerson = deliveryPersons[1], DeliveryDate = dt });
                dailyRoutes.Add(new DailyRoute() { Addresses = addresses3, DeliveryPerson = deliveryPersons[2], DeliveryDate = dt });

                return dailyRoutes.Select(x=> _mapper.Map<DailyRouteDTO>(x)).ToList();
            }catch(Exception ex)
            {
                return null;
            }
        }
    }
}
