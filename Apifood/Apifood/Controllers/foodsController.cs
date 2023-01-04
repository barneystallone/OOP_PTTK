using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Apifood.Database;
using Apifood.Models;

namespace Apifood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class foodsController : ControllerBase
    {
        private readonly DemoDbContext _context;

        public foodsController(DemoDbContext context)
        {
            _context = context;
        }

        // GET: api/foods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<food>>> Getfood()
        {
            return await _context.food.ToListAsync();
        }

        // GET: api/foods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<food>> Getfood(int id)
        {
            var food = await _context.food.FindAsync(id);

            if (food == null)
            {
                return NotFound();
            }

            return food;
        }

        // PUT: api/foods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       
        // Edit món ăn
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Putfood(int id, food food)
        {
            if (id != food.foodid)
            {
                return BadRequest();
            }

            _context.Entry(food).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!foodExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        // Tìm món ăn theo tên
        [Route("search/{nameData}")]
        [HttpGet]
        public async Task<IActionResult> GetProductsByName(string nameData)
        {
            var items = await _context.food
                .Where(x => x.foodname.Contains(nameData))
                .ToListAsync();
            return Ok(items);
        }

        // lấy món ăn theo danh mục
        [HttpGet("viaCateId")]
        public async Task<ActionResult<IEnumerable<food>>> GetviaCateId([FromQuery] string MenuyId)
        {

            var tmp = int.Parse(MenuyId);
            var data = from p in _context.food
                       where (p.menuid == tmp)
                       select (p);
            return await data.ToListAsync();
        }

        // lấy món ăn nổi bật
        [HttpGet("OutstandingFood")]
        public async Task<ActionResult<IEnumerable<food>>> GetOutstandingFood([FromQuery] string typefood)
        {

            var tmp = int.Parse(typefood);
            var data = from p in _context.food
                       where (p.typefood == tmp)
                       select (p);
            return await data.ToListAsync();
        }



        [HttpGet("Seachfood")]
        public async Task<ActionResult<IEnumerable<food>>> GetSeachfood([FromQuery] string foodsname)
        {

            var tmp = string.Concat(foodsname);
            var data = from p in _context.food
                     
                       select (p);
            return await data.ToListAsync();
        }

        // POST: api/foods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<food>> Addfood([FromBody] FoodAddModels Model)
        {
            if (ModelState.IsValid)
            {
                var food = new food()
                {
                    foodname = Model.foodname,
                    menuid = Model.menuid,
                    foodprice = Model.foodprice,
                    foodimghp = Model.foodimghp,
                    foodimg1 = Model.foodimg1,
                    foodimg2 = Model.foodimg2,
                    foodimg3 = Model.foodimg3,
                    foodimg4 = Model.foodimg4,
                    foodDescriptions = Model.foodDescriptions,
                    foodInStock = Model.foodInStock,
                    typefood = Model.typefood,


                };

                _context.food.Add(food);
                await _context.SaveChangesAsync();
                return Ok(food);
            }

            return BadRequest(ModelState.Values);
        }




        // Xóa
        // DELETE: api/foods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletefood(int id)
        {
            var food = await _context.food.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }

            _context.food.Remove(food);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool foodExists(int id)
        {
            return _context.food.Any(e => e.foodid == id);
        }
    }
}
