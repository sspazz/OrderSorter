using AutoMapper;
using Core.Models;
using Newtonsoft.Json.Linq;

namespace Core.DTOs
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddressDTO, Address>();
            CreateMap<Address, AddressDTO>();
            CreateMap<DeliveryPersonDTO, DeliveryPerson>();
            CreateMap<DeliveryPerson, DeliveryPersonDTO>();
            CreateMap<HistoricalDataDTO, HistoricalData>();
            CreateMap<HistoricalData, HistoricalDataDTO>();
            CreateMap<OrderDTO, Order>();
            CreateMap<Order, OrderDTO>();
            CreateMap<DailyRouteDTO, DailyRoute>();
            CreateMap<DailyRoute, DailyRouteDTO>();
        }     
    }
}
