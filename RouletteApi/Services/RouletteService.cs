using RouletteApi.Data.Entities;
using RouletteApi.Data.Enums;
using RouletteApi.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RouletteApi.Services
{
    public class RouletteService : IRouletteService
    {
        private readonly IRouletteRepository _rouletteRepository;
        public RouletteService(IRouletteRepository rouletteRepository)
        {
            _rouletteRepository = rouletteRepository;
        }

        public async Task<Bet> BetRulette(Bet bet)
        {

            return await _rouletteRepository.BetAsync(bet);
        }

        public async Task<Roulette> CloseAsync(Roulette roulette)
        {
            var random = new Random();
            int number = random.Next(0, 36);
            int color = random.Next(1, 2);
            roulette.Status = RouletteStatus.Closed;
            roulette.CloseDate = DateTime.Now;
            roulette.WinningNumber = number;
            roulette.WinningColour = color == 1 ? "Black" : "Red";
            return await _rouletteRepository.UpdateAsync(roulette);
        }

        public async Task<Roulette> Create()
        {
            Roulette roulette = new Roulette()
            {
                Id = Guid.NewGuid().ToString(),
                Status = RouletteStatus.Created,
                CreateDate = DateTime.Now
            };

            return await _rouletteRepository.CreateAsync(roulette);
        }

        public List<Roulette> GetAllRulette()
        {
            return _rouletteRepository.GetAllRulette();
        }

        public async Task<Roulette> GetById(string id) => await _rouletteRepository.GetById(id);

        public async Task<Roulette> Open(Roulette roulette)
        {
            roulette.Status = RouletteStatus.Open;
            roulette.OpenDate = DateTime.Now;

            return await _rouletteRepository.UpdateAsync(roulette);
        }
    }
}
