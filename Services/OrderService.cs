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
    public class OrderService : GenericService<Order, OrderDTO>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(ILogger logger, IOrderRepository orderRepository, IMapper mapper) : base(logger, orderRepository, mapper)
        {
            orderRepository = _orderRepository;
        }
    }
}
