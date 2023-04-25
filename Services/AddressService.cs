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
    public class AddressService : GenericService<Address, AddressDTO> , IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(ILogger logger, IAddressRepository addressRepository, IMapper mapper) : base(logger, addressRepository, mapper)
        {
            addressRepository = addressRepository;
        }
    }
}
