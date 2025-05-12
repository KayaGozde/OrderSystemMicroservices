using AuthService.Data;
using AuthService.Dtos;
using AuthService.Models;
using AuthService.RequestModels;
using AuthService.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using AuthService.Interfaces;

namespace AuthService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        public AuthController(AuthDbContext context, IConfiguration configuration,IMapper mapper, IAuthService authService)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
            _authService = authService; 
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var dto = _mapper.Map<LoginDto>(request);
            var result = await _authService.LoginAsync(dto);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var dto = _mapper.Map<RegisterDto>(request);
            var result = await _authService.RegisterAsync(dto);
            return Ok(result);
        }

    }
}
