using RouletteApi.Data;
using RouletteApi.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteApi.Repositories
{
    public class RouletteRepository : IRouletteRepository
    {
        private readonly DataContext _context;
        public RouletteRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Bet> BetAsync(Bet bet)
        {
            await _context.Bets.AddAsync(bet);
            await _context.SaveChangesAsync();

            return bet;
        }

        public Task<Roulette> CloseAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Roulette> CreateAsync(Roulette roulette)
        {
            await _context.Roulettes.AddAsync(roulette);
            await _context.SaveChangesAsync();

            return roulette;
        }

        public List<Roulette> GetAllRulette()
        {
            return _context.Roulettes.ToList();
        }

        public async Task<Roulette> GetById(string id)
        {
            return await _context.Roulettes.FindAsync(id);
        }

        public async Task<Roulette> UpdateAsync(Roulette roulette)
        {
            _context.Roulettes.Update(roulette);
            await _context.SaveChangesAsync();

            return roulette;
        }
    }
}
