using RouletteApi.Data.Entities;
using RouletteApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RouletteApi.Services
{
    public interface IRouletteService
    {
        public Task<Roulette> Create();
        public Task<Roulette> GetById(string id);
        public Task<Roulette> Open(Roulette roulette);
        public Task<Bet> BetRulette(Bet bet);
        public Task<Roulette> CloseAsync(Roulette roulette);
        public List<Roulette> GetAllRulette();
    }
}
