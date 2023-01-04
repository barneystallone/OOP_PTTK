using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Apifood.Database;
using Apifood.Models;
using Microsoft.AspNetCore.Authorization;

namespace Apifood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly DemoDbContext _context;

        public CartsController(DemoDbContext context)
        {
            _context = context;
        }

        // GET: api/Carts
        [HttpGet]
        [Route("Admin")]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCart()
        {
            return await _context.Cart.ToListAsync();
        }





        [HttpGet]
        [Authorize]

        public async Task<IEnumerable<Cart>> GetCartIdUser()
        {
            var customerId = HttpContext?.User?.FindFirst("CustomerID")?.Value;

            return await _context.Cart.Where(x => x.customerid.ToString() == customerId).ToListAsync();

        }

        // GET: api/Carts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cart>> GetCart(int id)
        {
            var cart = await _context.Cart.FindAsync(id);

            if (cart == null)
            {
                return NotFound();
            }

            return cart;
        }

        // PUT: api/Carts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCart(int id, Cart cart)
        {
            if (id != cart.Cartid)
            {
                return BadRequest();
            }

            _context.Entry(cart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(id))
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

        // POST: api/Carts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPost]
        public async Task<ActionResult<Cart>> Addfood([FromBody] CartModel Model)
        {
            if (ModelState.IsValid)
            {
                var Cart = new Cart()
                {
                    foodid = Model.foodid,
                    foodname = Model.foodname,
                    foodprice = Model.foodprice,
                    foodimghp = Model.foodimghp,
                    cartquantity = Model.cartquantity,
                    Allprice = Model.Allprice,
                    customerid = Model.customerid
                };

                _context.Cart.Add(Cart);
                await _context.SaveChangesAsync();
                return Ok(Cart);
            }

            return BadRequest(ModelState.Values);
        }
        // DELETE: api/Carts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(int id)
        {
            var cart = await _context.Cart.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            _context.Cart.Remove(cart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CartExists(int id)
        {
            return _context.Cart.Any(e => e.Cartid == id);
        }
    }
}
