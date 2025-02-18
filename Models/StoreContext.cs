﻿using Microsoft.EntityFrameworkCore;

namespace CRUD_VideoGamesConsoles.Models
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) 
        {

        }

        public DbSet<GameConsole> GameConsoles { get; set; }
        public DbSet<Brand> Brands { get; set; }

    }
}
