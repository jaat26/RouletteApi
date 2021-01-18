using Microsoft.EntityFrameworkCore;
using RouletteApi.Data.Entities;

namespace RouletteApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Bet> Bets { get; set; }
        public DbSet<Roulette> Roulettes { get; set; }
    }
}
