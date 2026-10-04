using FutbolcuKimApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FutbolcuKimApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PlayerController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetPlayers()
        {
            var players = await _context.Players.ToListAsync();

            return Ok(players);
        }
        [HttpGet("search")]
        public async Task<IActionResult>SearchPlayers(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("Arama metni boş olamaz.");

            var players = await _context.Players
                .Where(x => x.Name.Contains(name))
                .ToListAsync();

            return Ok(players);
        }
    }
}
