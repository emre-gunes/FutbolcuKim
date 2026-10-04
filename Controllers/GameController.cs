using Microsoft.AspNetCore.Authorization;
using FutbolcuKimApi.Models;
using FutbolcuKimApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FutbolcuKim.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class GameController : ControllerBase
    {
        private readonly GameService _gameService;

        public GameController(GameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet("today")]
        public async Task<IActionResult> GetTodayGame()
        {
            var player = await _gameService.GetTodayPlayer();

            if (player == null)
                return NotFound("Bugünün oyunu bulunamadı.");

            return Ok(player);
        }

        [HttpPost("guess")]
        public async Task<IActionResult> MakeGuess(GuessRequest request)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                return Unauthorized("Kullanıcı bulunamadı.");

            var result = await _gameService.MakeGuess(
                request.PlayerId,
                userId
            );

            if (result == null)
                return NotFound("Futbolcu bulunamadı.");

            return Ok(result);
        }
        [HttpGet("hint")]
        public async Task<IActionResult> GetHint(int hintNumber)
        {
            var player = await _gameService.GetTodayPlayer();

            if (player == null)
                return NotFound("Bugünün futbolcusu bulunamadı.");

            string hint;

            switch (hintNumber)
            {
                case 1:
                    hint = $"Oyuncunun ülkesi: {_gameService.TranslateNationalityForHint(player.Nationality)}";
                    break;

                case 2:
                    hint = $"Oyuncunun kulübü: {player.CurrentClub}";
                    break;

                case 3:
                    hint = $"Oyuncunun boyu: {player.Height} cm";
                    break;

                default:
                    return BadRequest("Geçersiz ipucu numarası.");
            }

            return Ok(new
            {
                hintNumber = hintNumber,
                hint = hint
            });
        }
    }
}