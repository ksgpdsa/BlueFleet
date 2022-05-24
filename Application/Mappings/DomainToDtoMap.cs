using Application.Dto;
using AutoMapper;
using Domain.Models;

namespace Application.Mappings
{
    public class DomainToDtoMap : Profile
    {
        public DomainToDtoMap()
        {
            CreateMap<Veiculo, VeiculosDto>();
        }
    }
}
