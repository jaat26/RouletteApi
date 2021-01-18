using Microsoft.AspNetCore.Mvc;
using RouletteApi.Data.Entities;
using RouletteApi.Data.Enums;
using RouletteApi.Models;
using RouletteApi.Models.Response;
using RouletteApi.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RouletteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        private readonly IRouletteService _rouletteService;
        public RouletteController(IRouletteService rouletteService)
        {
            _rouletteService = rouletteService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateRulette()
        {
            try
            {
                Roulette roulette = await _rouletteService.Create();
                return Ok(new CreateResponse { RouletteId = roulette.Id });
            }
            catch (Exception ex)
            {
                return BadRequest(new RouletteResponse
                {
                    IsSuccess = false,
                    Message = ex.Message
                });
            }
        }


        [HttpGet]
        [Route("{id}/open")]
        public async Task<IActionResult> OpenRulette(string id)
        {
            if (id == null)
            {
                return BadRequest(new RouletteResponse
                {
                    IsSuccess = false,
                    Message = "Id de ruleta no puede ser nulo."
                });
            }
            try
            {
                Roulette roulette = await _rouletteService.GetById(id);
                if (roulette == null)
                {
                    return BadRequest(new RouletteResponse
                    {
                        IsSuccess = false,
                        Message = $"Ruleta con Id: {id} no existe."
                    });
                }
                if (roulette.Status == RouletteStatus.Created)
                {
                    Roulette openRoulette = await _rouletteService.Open(roulette);
                    return Ok(new RouletteResponse { IsSuccess = true, Message = "La operación fue exitosa" });
                }

                return BadRequest(new RouletteResponse
                {
                    IsSuccess = false,
                    Message = $"Ruleta con Id: {id}, no se puede abrir."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new RouletteResponse { IsSuccess = false, Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("bet")]
        public async Task<IActionResult> BetRulette([FromBody] Bet bet)
        {
            try
            {
                Roulette roulette = await _rouletteService.GetById(bet.RouletteId);
                if (roulette == null)
                {
                    return NotFound(new RouletteResponse
                    {
                        IsSuccess = false,
                        Message = $"Ruleta con Id: {bet.RouletteId} no existe, no se pueden crear apuestas."
                    });
                }
                if (roulette.Status == RouletteStatus.Open)
                {
                    Bet newBet = await _rouletteService.BetRulette(bet);
                    return Ok(new BetResponse
                    {
                        IsSuccess = true,
                        Message = "La apuesta se realizó exitosamente.",
                        UserId = newBet.UserId,
                        Number = newBet.Number,
                        Coulor = newBet.Colour,
                        Money = newBet.Money
                    });
                }

                return BadRequest(new RouletteResponse
                {
                    IsSuccess = false,
                    Message = $"Ruleta con Id: {bet.RouletteId} no está abierta, no se pueden realizar apuestas."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new RouletteResponse
                {
                    IsSuccess = false,
                    Message = ex.Message
                });
            }
        }

        [HttpGet]
        [Route("{id}/close")]
        public async Task<IActionResult> CloseAsync(string id)
        {
            try
            {
                Roulette roulette = await _rouletteService.GetById(id);
                if (roulette == null)
                {
                    return NotFound(new RouletteResponse
                    {
                        IsSuccess = false,
                        Message = $"Ruleta con Id: {id} no existe, no se puede cerrar."
                    });

                }
                if (roulette.Status == RouletteStatus.Open)
                {
                    Roulette newRoulette = await _rouletteService.CloseAsync(roulette);
                    return Ok(new CloseResponse 
                    { 
                        IsSuccess = true,
                        Message = "Ruleta cerrada exitosamente",
                        Number = newRoulette.WinningNumber,
                        Coulor = newRoulette.WinningColour
                    });
                }
                return BadRequest(new RouletteResponse
                {
                    IsSuccess = false,
                    Message = $"Ruleta con Id: {id} no se puede cerrar porque no está abierta."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new RouletteResponse
                {
                    IsSuccess = false,
                    Message = ex.Message
                });
            }
        }

        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAllRulette()
        {
            try
            {
                List<Roulette> roulettes = _rouletteService.GetAllRulette();
                return Ok(roulettes);
            }
            catch (Exception ex)
            {
                return (BadRequest(new RouletteResponse
                {
                    IsSuccess = false,
                    Message = ex.Message
                }));
            }
        }

        [HttpGet]
        [Route("{id}/get")]
        public async Task<IActionResult> GetByIdRulette(string id)
        {
            if (id == null)
            {
                return BadRequest(new RouletteResponse
                {
                    IsSuccess = false,
                    Message = "Id de ruleta no puede ser nulo."
                });
            }
            try
            {
                Roulette roulette = await _rouletteService.GetById(id);
                if (roulette == null)
                {
                    return BadRequest(new RouletteResponse
                    {
                        IsSuccess = false,
                        Message = $"Ruleta con Id: {id} no existe."
                    });
                }

                return Ok(roulette);
            }
            catch (Exception ex)
            {
                return BadRequest(new RouletteResponse
                {
                    IsSuccess = false,
                    Message = ex.Message
                });
            }
        }
    }
}
