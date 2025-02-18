using AutoMapper;
using CRUD_VideoGamesConsoles.DTOs;
using CRUD_VideoGamesConsoles.Models;

namespace CRUD_VideoGamesConsoles.Automappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<GameConsoleInsertDto, GameConsole>();
            CreateMap<GameConsole, GameConsoleDto>().ForMember(dto => dto.Id, map => map.MapFrom(gameConsole => gameConsole.GameConsoleID));
            CreateMap<GameConsoleUpdateDto, GameConsole>();
        }
    }
}
