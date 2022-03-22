using AutoMapper;
using Dutchtreat.ViewModels;
using Dutchtreat.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dutchtreat.Data
{
    public class DutchMappingProfile : Profile
    {
        public DutchMappingProfile()
        {
            CreateMap<Order, OrderViewModel>()
               .ForMember(o => o.OrderId, ex => ex.MapFrom(o => o.Id))
               .ReverseMap();

            CreateMap<OrderItem, OrderItemViewModel>()
                .ReverseMap();
        }
     }
}
