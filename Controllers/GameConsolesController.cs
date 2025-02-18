using CRUD_VideoGamesConsoles.DTOs;
using CRUD_VideoGamesConsoles.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using CRUD_VideoGamesConsoles.Services;

namespace CRUD_VideoGamesConsoles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameConsolesController : ControllerBase
    {
        private IValidator<GameConsoleInsertDto> _gameConsoleInsertValidator;
        private IValidator<GameConsoleUpdateDto> _gameConsoleUpdateValidator;
        private ICommonService<GameConsoleDto, GameConsoleInsertDto, GameConsoleUpdateDto> _gameConsoleService;

        public GameConsolesController(
            IValidator<GameConsoleInsertDto> gameConsoleInsertValidator,
            IValidator<GameConsoleUpdateDto> gameConsoleUpdateValidator,
            [FromKeyedServices("gameConsoleService")] ICommonService<GameConsoleDto, GameConsoleInsertDto, GameConsoleUpdateDto> gameConsoleService)
        {
            _gameConsoleInsertValidator = gameConsoleInsertValidator;
            _gameConsoleUpdateValidator = gameConsoleUpdateValidator;
            _gameConsoleService = gameConsoleService;
        }

        //Method HTTP Get
        [HttpGet]
        public async Task<IEnumerable<GameConsoleDto>> Get() =>
            await _gameConsoleService.Get();

        //Method HTTP Get by id
        [HttpGet("{id}")]
        public async Task<ActionResult<GameConsoleDto>> GetById(int id)
        {
            var gameConsoleDto = await _gameConsoleService.GetById(id);

            return gameConsoleDto==null? NotFound() : Ok(gameConsoleDto);
        }


        //Method HTTP Post
        [HttpPost]
        public async Task<ActionResult<GameConsoleDto>> Add(GameConsoleInsertDto gameConsoleInsertDto)
        {
            var validationResult = await _gameConsoleInsertValidator.ValidateAsync(gameConsoleInsertDto);

            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var gameConsoleDto = await _gameConsoleService.Add(gameConsoleInsertDto);

            return CreatedAtAction(nameof(GetById), new { id = gameConsoleDto.Id }, gameConsoleDto);
        }


        //Method HTTP Put
        [HttpPut("{id}")]
        public async Task<ActionResult<GameConsoleDto>> Update(int id, GameConsoleUpdateDto gameConsoleUpdateDto)
        {
            var validationResult = await _gameConsoleUpdateValidator.ValidateAsync(gameConsoleUpdateDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var gameConsoleDto = await _gameConsoleService.Update(id, gameConsoleUpdateDto);

            return gameConsoleDto == null ? NotFound() : Ok(gameConsoleDto);
        }


        //Method HTTP Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult<GameConsoleDto>> Delete(int id)
        {
            var gameConsoleDto = await _gameConsoleService.Delete(id);

            return gameConsoleDto == null ? NotFound() : Ok(gameConsoleDto);
        }

    }
}

