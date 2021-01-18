using RouletteApi.Data.Entities;
using RouletteApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RouletteApi.Repositories
{
    public interface IRouletteRepository
    {
        Task<Roulette> CreateAsync(Roulette roulette);
        Task<Roulette> GetById(string id);
        Task<Roulette> UpdateAsync(Roulette roulette);
        Task<Bet> BetAsync(Bet bet);
        Task<Roulette> CloseAsync(string id);
        List<Roulette> GetAllRulette();
    }
}
