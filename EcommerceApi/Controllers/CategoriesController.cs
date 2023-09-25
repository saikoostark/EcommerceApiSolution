using EcommerceApi.DTO;
using EcommerceApi.Models;
using EcommerceApi.Utils;
using EcommerceApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly EcommerceDbContext _DB;

        public CategoriesController(EcommerceDbContext DB)
        {
            _DB = DB;
        }


        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(Response<IEnumerable<CategoryDTOS>>))]
        public async Task<IActionResult> GetAll()
        {
            var data = await _DB.Categorys
            .Select(cat => Mapper.Map<CategoryDTOS>(cat))
            .ToListAsync();

            return data != null ? Ok(new Response<IEnumerable<CategoryDTOS>>(data!)) : NotFound(new Response<IEnumerable<CategoryDTOS>>(data!, 2, "Category not found"));
        }


        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Response<CategoryDTOS>))]
        public async Task<IActionResult> GetByID(int id)
        {
            var objs = await _DB.Categorys
            .Where(cat => cat.ID == id)
            .Select(cat => Mapper.Map<CategoryDTOS>(cat))
            .FirstOrDefaultAsync();

            return objs != null ? Ok(new Response<CategoryDTOS>(objs)) : NotFound(new Response<CategoryDTOS>(objs, 2, "Category not found"));
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Response<CategoryDTOS>))]
        public async Task<IActionResult> Post([FromForm] CategoryDTOR objr)
        {
            var obj = Mapper.Map<Category>(objr);
            await _DB.AddAsync(obj!);
            await _DB.SaveChangesAsync();

            var objs = Mapper.Map<CategoryDTOS>(obj);

            return objs != null ? Created("1", new Response<CategoryDTOS>(objs)) : NotFound(new Response<CategoryDTOS>(objs, 2, "Category not found"));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(Response<CategoryDTOS>))]
        public async Task<IActionResult> Put(int id, [FromForm] CategoryDTOR objr)
        {
            var obj1 = await _DB.Categorys.FindAsync(id);
            var obj2 = Mapper.Map<Category>(objr);

            obj2!.ID = obj1?.ID ?? 0;

            _DB.Categorys.Update(obj2);
            await _DB.SaveChangesAsync();
            var objs = Mapper.Map<CategoryDTOS>(obj2);
            return objs != null ? Ok(new Response<CategoryDTOS>(objs)) : Created("1", new Response<CategoryDTOS>(objs, 2, "Category not found"));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(Response<CategoryDTOS>))]
        public async Task<IActionResult> Delete(int id)
        {
            var obj = await _DB.Categorys.FindAsync(id);
            if (obj != null)
            {
                _DB.Categorys.Remove(obj);
                await _DB.SaveChangesAsync();
            }
            var objs = Mapper.Map<CategoryDTOS>(obj);
            return objs != null ? Ok(new Response<CategoryDTOS>(objs)) : NotFound(new Response<CategoryDTOS>(objs, 2, "Category not found"));
        }

    }
}