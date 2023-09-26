using System.Text;
using System.Security.Claims;
using EcommerceApi.DTO;
using EcommerceApi.Models;
using EcommerceApi.Utils;
using EcommerceApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace EcommerceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly EcommerceDbContext _DB;
        private readonly IConfiguration _Configuration;

        public AuthController(EcommerceDbContext DB, IConfiguration configuration)
        {
            _DB = DB;
            _Configuration = configuration;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm] UserDTOR objr)
        {
            var obj = Mapper.Map<User>(objr);
            await _DB.AddAsync(obj!);
            await _DB.SaveChangesAsync();

            var objs = Mapper.Map<UserDTOS>(obj);

            return objs != null ? Created("1", new Response<UserDTOS>(objs)) : NotFound(new Response<UserDTOS>(objs, 2, "User not found"));
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm] LoginUser objr)
        {
            User? obj;

            if (UserUtiles.IfEmail(objr.UserNameOrEmail))
            {
                obj = await _DB.Users.FirstOrDefaultAsync(u => u.Email == objr.UserNameOrEmail);
            }
            else
            {
                obj = await _DB.Users.FirstOrDefaultAsync(u => u.UserName == objr.UserNameOrEmail);
            }

            if (obj is null)
                return BadRequest(new Response<User>(obj));


            var passconfirm = obj.HashedPassword == Hasher.GenerateHash(objr!.Password!, obj!.Salt!);

            return passconfirm ? Ok(new Response<string>(CreateToken(obj))) : BadRequest(new Response<string>(null));

        }


        private string CreateToken(User user)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, user!.UserName!),
                new Claim(ClaimTypes.Email, user!.Email!),
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_Configuration.GetSection("AppSettings:Token").Value!
                ));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(3),
                signingCredentials: credentials
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }


    }
}