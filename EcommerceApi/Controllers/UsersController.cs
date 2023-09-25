using EcommerceApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcommerceApi.ViewModels;

namespace EcommerceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly EcommerceDbContext _DB;

        public UsersController(EcommerceDbContext DB)
        {
            _DB = DB;
        }




        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(Response<List<User>>))]

        public async Task<IActionResult> GetAll()
        {
            var data = await _DB.Users.ToListAsync();
            var res = new Response<List<User>>(data);
            return Ok(res);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Response<User>))]

        public async Task<IActionResult> GetByID(int id)
        {
            var data = await _DB.Users.FindAsync(id);

            return data != null ? Ok(new Response<User>(data)) : NotFound(new Response<User>(data, 2, "user not found"));
        }

    }
}