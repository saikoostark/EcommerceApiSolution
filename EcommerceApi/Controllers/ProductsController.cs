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
    public class ProductController : ControllerBase
    {
        private readonly EcommerceDbContext _DB;

        public ProductController(EcommerceDbContext DB)
        {
            _DB = DB;
        }


        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(Response<IEnumerable<ProductDTOS>>))]
        public async Task<IActionResult> GetAll()
        {
            var data = await _DB.Products
            .Include(pro => pro.ProductCategorys)
            .Select(pro => Mapper.Map<ProductDTOS>(pro))
            .ToListAsync();

            return data != null ? Ok(new Response<IEnumerable<ProductDTOS>>(data!)) : NotFound(new Response<IEnumerable<ProductDTOS>>(data!, 2, "Product not found"));
        }


        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Response<ProductDTOS>))]
        public async Task<IActionResult> GetByID(int id)
        {
            var objs = await _DB.Products
            .Where(pro => pro.ID == id)
            .Select(pro => Mapper.Map<ProductDTOS>(pro))
            .FirstOrDefaultAsync();

            return objs != null ? Ok(new Response<ProductDTOS>(objs)) : NotFound(new Response<ProductDTOS>(objs, 2, "Product not found"));
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Response<ProductDTOS>))]
        public async Task<IActionResult> Post([FromForm] ProductDTOR objr)
        {

            var obj = Mapper.Map<Product>(objr);
            await _DB.AddAsync(obj!);

            if (obj != null && objr.Categories != null)
            {
                obj.ProductCategorys = new HashSet<ProductCategory>();
                foreach (var cat in objr.Categories)
                {
                    var testCat = await _DB.Categorys.FindAsync(cat);
                    if (testCat != null)
                        obj.ProductCategorys.Add(new() { CategoryID = cat, ProductID = obj.ID });
                }
            }

            await _DB.SaveChangesAsync();

            var objs = Mapper.Map<ProductDTOS>(obj);

            return objs != null ? Created("1", new Response<ProductDTOS>(objs)) : NotFound(new Response<ProductDTOS>(objs, 2, "Product not found"));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(Response<ProductDTOS>))]
        public async Task<IActionResult> Put(int id, [FromForm] ProductDTOR objr)
        {
            var obj1 = await _DB.Products
            .Include(pro => pro.ProductCategorys)
            .FirstOrDefaultAsync(pro => pro.ID == id);

            var obj2 = Mapper.Map<Product>(objr);

            obj1?.ProductCategorys?.Clear();
            obj2!.ID = obj1?.ID ?? 0;
            if (obj1 != null)
                _DB.RemoveRange(_DB.ProductCategorys.Where(procat => procat.ProductID == obj1.ID));

            if (obj2 != null && objr.Categories != null)
            {
                obj2.ProductCategorys = new HashSet<ProductCategory>();
                foreach (var cat in objr.Categories)
                {
                    var testCat = await _DB.Categorys.FindAsync(cat);
                    if (testCat != null)
                        obj2.ProductCategorys.Add(new() { CategoryID = cat, ProductID = obj2.ID });
                }
            }

            _DB.Products.Update(obj2!);
            await _DB.SaveChangesAsync();
            var objs = Mapper.Map<ProductDTOS>(obj2);
            return objs != null ? Ok(new Response<ProductDTOS>(objs)) : Created("1", new Response<ProductDTOS>(objs, 2, "Product not found"));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(Response<ProductDTOS>))]
        public async Task<IActionResult> Delete(int id)
        {
            var obj = await _DB.Products.FindAsync(id);
            if (obj != null)
            {
                _DB.Products.Remove(obj);
                await _DB.SaveChangesAsync();
            }
            var objs = Mapper.Map<ProductDTOS>(obj);
            return objs != null ? Ok(new Response<ProductDTOS>(objs)) : NotFound(new Response<ProductDTOS>(objs, 2, "Product not found"));
        }

    }
}