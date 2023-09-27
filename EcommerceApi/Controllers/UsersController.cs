using EcommerceApi.DTO;
using EcommerceApi.Models;
using EcommerceApi.Utils;
using EcommerceApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Controllers
{
    [ApiController]
    [Authorize(Roles = UserUtiles.AdminRole)]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly EcommerceDbContext _DB;

        public UsersController(EcommerceDbContext DB)
        {
            _DB = DB;
        }


        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(Response<IEnumerable<UserDTOS>>))]
        public async Task<IActionResult> GetAll()
        {
            var data = await _DB.Users
            .Select(cat => Mapper.Map<UserDTOS>(cat))
            .ToListAsync();

            return data != null ? Ok(new Response<IEnumerable<UserDTOS>>(data!)) : NotFound(new Response<IEnumerable<UserDTOS>>(data!, 2, "User not found"));
        }


        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Response<UserDTOS>))]
        public async Task<IActionResult> GetByID(int id)
        {
            var objs = await _DB.Users
            .Where(cat => cat.ID == id)
            .Select(cat => Mapper.Map<UserDTOS>(cat))
            .FirstOrDefaultAsync();

            return objs != null ? Ok(new Response<UserDTOS>(objs)) : NotFound(new Response<UserDTOS>(objs, 2, "User not found"));
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Response<UserDTOS>))]
        public async Task<IActionResult> Post([FromForm] UserDTOR objr)
        {
            var obj = Mapper.Map<User>(objr);
            await _DB.AddAsync(obj!);
            await _DB.SaveChangesAsync();

            var objs = Mapper.Map<UserDTOS>(obj);

            return objs != null ? Created("1", new Response<UserDTOS>(objs)) : NotFound(new Response<UserDTOS>(objs, 2, "User not found"));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(Response<UserDTOS>))]
        public async Task<IActionResult> Put(int id, [FromForm] UserDTOR objr)
        {
            var obj1 = await _DB.Users.FindAsync(id);
            var obj2 = Mapper.Map<User>(objr);

            obj2!.ID = obj1?.ID ?? 0;

            _DB.Users.Update(obj2);
            await _DB.SaveChangesAsync();
            var objs = Mapper.Map<UserDTOS>(obj2);
            return objs != null ? Ok(new Response<UserDTOS>(objs)) : Created("1", new Response<UserDTOS>(objs, 2, "User not found"));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(Response<UserDTOS>))]
        public async Task<IActionResult> Delete(int id)
        {
            var obj = await _DB.Users.FindAsync(id);
            if (obj != null)
            {
                _DB.Users.Remove(obj);
                await _DB.SaveChangesAsync();
            }
            var objs = Mapper.Map<UserDTOS>(obj);
            return objs != null ? Ok(new Response<UserDTOS>(objs)) : NotFound(new Response<UserDTOS>(objs, 2, "User not found"));
        }

    }
}