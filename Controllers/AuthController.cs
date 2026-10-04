using FutbolcuKimApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FutbolcuKimApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthController(
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        // REGISTER
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var existingUser =
                await _userManager.FindByEmailAsync(request.Email);

            if (existingUser != null)
                return BadRequest("Bu email zaten kayıtlı.");

            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email,
                DisplayName = request.DisplayName
            };

            var result =
                await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(new
            {
                message = "Kullanıcı başarıyla oluşturuldu.",
                userId = user.Id,
                displayName = user.DisplayName,
                email = user.Email
            });
        }

        // LOGIN
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var user =
                await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
                return Unauthorized("Email veya şifre hatalı.");

            var passwordCorrect =
                await _userManager.CheckPasswordAsync(
                    user,
                    request.Password
                );

            if (!passwordCorrect)
                return Unauthorized("Email veya şifre hatalı.");

            var token = GenerateJwtToken(user);

            return Ok(new
            {
                message = "Giriş başarılı.",
                token = token,
                user = new
                {
                    id = user.Id,
                    displayName = user.DisplayName,
                    email = user.Email
                }
            });
        }

        private string GenerateJwtToken(ApplicationUser user)
        {
            var claims = new[]
            {
                new Claim(
                    ClaimTypes.NameIdentifier,
                    user.Id
                ),

                new Claim(
                    ClaimTypes.Name,
                    user.UserName ?? ""
                ),

                new Claim(
                    "DisplayName",
                    user.DisplayName
                )
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    _configuration["Jwt:Key"]!
                )
            );

            var credentials =
                new SigningCredentials(
                    key,
                    SecurityAlgorithms.HmacSha256
                );

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
    }

    public class RegisterRequest
    {
        public string DisplayName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }

    public class LoginRequest
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }
}