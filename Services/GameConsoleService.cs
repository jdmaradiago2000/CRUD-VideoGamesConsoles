using AutoMapper;
using CRUD_VideoGamesConsoles.DTOs;
using CRUD_VideoGamesConsoles.Models;
using CRUD_VideoGamesConsoles.Repository;
using Microsoft.EntityFrameworkCore;

namespace CRUD_VideoGamesConsoles.Services
{
    public class GameConsoleService :ICommonService<GameConsoleDto, GameConsoleInsertDto, GameConsoleUpdateDto>
    {
        private IRepository<GameConsole> _gameConsoleRepository;
        private IMapper _mapper;

        public GameConsoleService(IRepository<GameConsole> gameConsoleRepository, IMapper mapper)
        {
            _gameConsoleRepository = gameConsoleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GameConsoleDto>> Get()
        {
            var gameConsoles = await _gameConsoleRepository.Get();

            //return gameConsoles.Select(x => new GameConsoleDto
            //{
            //    Id = x.GameConsoleID,
            //    Name = x.Name,
            //    BrandID = x.BrandID,
            //    Teraflops = x.Teraflops
            //});

            return gameConsoles.Select(x => _mapper.Map<GameConsoleDto>(x));

        }

        public async Task<GameConsoleDto> GetById(int id)
        {
            var gameConsole = await _gameConsoleRepository.GetById(id);

            if (gameConsole != null)
            {
                //var gameConsoleDto = new GameConsoleDto
                //{
                //    Id = gameConsole.GameConsoleID,
                //    Name = gameConsole.Name,
                //    BrandID = gameConsole.BrandID,
                //    Teraflops = gameConsole.Teraflops
                //};

                var gameConsoleDto = _mapper.Map<GameConsoleDto>(gameConsole);

                return gameConsoleDto;
            }

            return null;
        }

        public async Task<GameConsoleDto> Add(GameConsoleInsertDto gameConsoleInsertDto)
        {

            var gameConsole = _mapper.Map<GameConsole>(gameConsoleInsertDto);  //Automapper creates a GameConsole with the information of gameConsoleInsertDto.

            //var gameConsole = new GameConsole()
            //{
            //    Name = gameConsoleInsertDto.Name,
            //    BrandID = gameConsoleInsertDto.BrandID,
            //    Teraflops = gameConsoleInsertDto.Teraflops
            //};

            await _gameConsoleRepository.Add(gameConsole); //This just indicate to EF that an Insert into the DB is comming, not that there is a change into the DB.
            await _gameConsoleRepository.Save(); //Here is where you can see the updates into the DB.

            //var gameConsoleDto = new GameConsoleDto
            //{
            //    Id = gameConsole.GameConsoleID,
            //    Name = gameConsole.Name,
            //    BrandID = gameConsole.BrandID,
            //    Teraflops = gameConsole.Teraflops
            //};

            var gameConsoleDto = _mapper.Map<GameConsoleDto>(gameConsole); //Automapper creates a GameConsoleDto with the information of gameConsole.

            return gameConsoleDto;
        }

        public async Task<GameConsoleDto> Update(int id, GameConsoleUpdateDto gameConsoleUpdateDto)
        {
            var gameConsole = await _gameConsoleRepository.GetById(id);

            if (gameConsole != null)
            {
                gameConsole = _mapper.Map<GameConsoleUpdateDto, GameConsole>(gameConsoleUpdateDto, gameConsole);

                //gameConsole.Name = gameConsoleUpdateDto.Name;
                //gameConsole.BrandID = gameConsoleUpdateDto.BrandID;
                //gameConsole.Teraflops = gameConsoleUpdateDto.Teraflops;

                _gameConsoleRepository.Update(gameConsole);
                await _gameConsoleRepository.Save();

                //var gameConsoleDto = new GameConsoleDto
                //{
                //    Id = gameConsole.GameConsoleID,
                //    Name = gameConsole.Name,
                //    BrandID = gameConsole.BrandID,
                //    Teraflops = gameConsole.Teraflops
                //};

                var gameConsoleDto = _mapper.Map<GameConsoleDto>(gameConsole);

                return gameConsoleDto;
            }

            return null;
        }

        public async Task<GameConsoleDto> Delete(int id)
        {
            var gameConsole = await _gameConsoleRepository.GetById(id);

            if (gameConsole != null)
            {
                //var gameConsoleDto = new GameConsoleDto
                //{
                //    Id = gameConsole.GameConsoleID,
                //    Name = gameConsole.Name,
                //    BrandID = gameConsole.BrandID,
                //    Teraflops = gameConsole.Teraflops
                //};

                var gameConsoleDto = _mapper.Map<GameConsoleDto>(gameConsole);

                _gameConsoleRepository.Delete(gameConsole);
                await _gameConsoleRepository.Save();

                return gameConsoleDto;
            }

            return null;
        }
    }
}
