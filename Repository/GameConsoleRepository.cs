using CRUD_VideoGamesConsoles.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_VideoGamesConsoles.Repository
{
    public class GameConsoleRepository : IRepository<GameConsole>
    {
        private StoreContext _context;

        public GameConsoleRepository(StoreContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<GameConsole>> Get()
            => await _context.GameConsoles.ToListAsync();

        public async Task<GameConsole> GetById(int id)
            => await _context.GameConsoles.FindAsync(id);

        public async Task Add(GameConsole gameConsole)
            => await _context.GameConsoles.AddAsync(gameConsole);
       
        public void Update(GameConsole gameConsole)
        {
            _context.GameConsoles.Attach(gameConsole);
            _context.GameConsoles.Entry(gameConsole).State = EntityState.Modified;
        }

        public void Delete(GameConsole gameConsole)
            => _context.GameConsoles.Remove(gameConsole);

        public async Task Save()
            => await _context.SaveChangesAsync();
    }
}