using AutoMapper;
using MinimalApi.Dtos;
using MinimalApi.Models;

namespace MinimalApi.MapperProfiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            //src -> target
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<CommandUpdateDto, Command>();
        }
    }
}