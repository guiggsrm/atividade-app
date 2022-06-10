using AutoMapper;
using ProTask.Application.DTOs;

namespace ProTask.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<NewTaskDTO, Domain.Models.Task>();
            CreateMap<Domain.Models.Task, TaskDTO>().ReverseMap();
            
            CreateMap<NewClientDTO, Domain.Models.Client>();
            CreateMap<Domain.Models.Client, ClientDTO>().ReverseMap();
        }
    }
}