using CRUD_VideoGamesConsoles.DTOs;
using CRUD_VideoGamesConsoles.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_VideoGamesConsoles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameConsolesController :ControllerBase
    {
        private StoreContext _context;

        public GameConsolesController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<GameConsoleDto>> Get() =>
            await _context.GameConsoles.Select(gameConsole => new GameConsoleDto
            {
                Id = gameConsole.GameConsoleID,
                Name = gameConsole.Name,
                BrandID = gameConsole.BrandID,
                Teraflops = gameConsole.Teraflops
            }).ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<GameConsoleDto>> GetById(int id)
        {
            var gameConsole = await _context.GameConsoles.FindAsync(id);

            if (gameConsole == null) return NotFound();

            var gameConsoleDto = new GameConsoleDto
            {
                Id = gameConsole.GameConsoleID,
                Name = gameConsole.Name,
                BrandID = gameConsole.BrandID,
                Teraflops = gameConsole.Teraflops
            };

            return Ok(gameConsoleDto);
        }

        [HttpPost]
        public async Task<ActionResult<GameConsoleDto>> Add(GameConsoleInsertDto gameConsoleInsertDto)
        {
            var gameConsole = new GameConsole()
            {
                Name = gameConsoleInsertDto.Name,
                BrandID = gameConsoleInsertDto.BrandID,
                Teraflops = gameConsoleInsertDto.Teraflops
            };

            await _context.GameConsoles.AddAsync(gameConsole); //This just indicate to EF that an Insert intoi the DB is comming, not that there is a change into the DB.
            await _context.SaveChangesAsync(); //Here is where you can see the updates into the DB.

            var gameConsoleDto = new GameConsoleDto
            {
                Id = gameConsole.GameConsoleID,
                Name = gameConsole.Name,
                BrandID = gameConsole.BrandID,
                Teraflops = gameConsole.Teraflops
            };

            return CreatedAtAction(nameof(GetById), new { id = gameConsole.GameConsoleID }, gameConsoleDto);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GameConsoleDto>> Update(int id, GameConsoleUpdateDto gameConsoleUpdateDto)
        {
            var gameConsole = await _context.GameConsoles.FindAsync(id);

            if (gameConsole == null) return NotFound();

            gameConsole.Name = gameConsoleUpdateDto.Name;
            gameConsole.BrandID = gameConsoleUpdateDto.BrandID;
            gameConsole.Teraflops = gameConsoleUpdateDto.Teraflops;
            await _context.SaveChangesAsync();

            var gameConsoleDto = new GameConsoleDto
            {
                Id = gameConsole.GameConsoleID,
                Name = gameConsole.Name,
                BrandID = gameConsole.BrandID,
                Teraflops = gameConsole.Teraflops
            };

            return Ok(gameConsoleDto);
        }

    }
}
