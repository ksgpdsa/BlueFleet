using Application.Dto;
using AutoMapper;
using Domain.Models;

namespace Application.Mappings
{
    public class DtoToDomainMap : Profile
    {
        public DtoToDomainMap()
        {
            CreateMap<VeiculosDto, Veiculo>();
        }
    }
}
