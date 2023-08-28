using System.Security.Cryptography;
using System.Text;
using API.Data;
<<<<<<< Updated upstream
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
=======
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
>>>>>>> Stashed changes

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
<<<<<<< Updated upstream
       private readonly DataContext _context;
       
        public AccountController(DataContext context)
        {
            _context = context;
        }

    [HttpPost("register")] // POST: api/account/register
    public async Task<ActionResult<AppUser>> Register(string username, string password)
        {
=======
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
       
        public AccountController(DataContext context, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost("register")] // POST: api/account/register?username=dave&password=pwd
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Username)) return BadRequest("Username is taken");

>>>>>>> Stashed changes
            using var hmac = new HMACSHA512();

            var user = new AppUser
            {
<<<<<<< Updated upstream
                UserName = username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
=======
                UserName = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
>>>>>>> Stashed changes
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

<<<<<<< Updated upstream
            return user;
=======
            return new UserDto
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.Username);

            if (user == null) return Unauthorized("invalid username");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("invalid password");
            }

            return new UserDto
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }

        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
>>>>>>> Stashed changes
        }
    }
}