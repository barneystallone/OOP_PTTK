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
    public class CustomerSPsController : ControllerBase
    {
        private readonly DemoDbContext _context;

        public CustomerSPsController(DemoDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerSPs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerSP>>> GetCustomerSupport()
        {
            return await _context.CustomerSP.ToListAsync();
        }

        // GET: api/CustomerSPs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerSP>> GetCustomerSP(int id)
        {
            var customerSP = await _context.CustomerSP.FindAsync(id);

            if (customerSP == null)
            {
                return NotFound();
            }

            return customerSP;
        }

        // PUT: api/CustomerSPs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerSP(int id, CustomerSP customerSP)
        {
            if (id != customerSP.customerSPid)
            {
                return BadRequest();
            }

            _context.Entry(customerSP).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerSPExists(id))
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

        // POST: api/CustomerSPs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPost]
        public async Task<ActionResult<CustomerSP>> Addfood([FromBody] CustomerSpModel Model)
        {
            if (ModelState.IsValid)
            {
                var CustomerSP = new CustomerSP()
                {
                    customerSPname = Model.customerSPname,
                    customerSPemail = Model.customerSPemail,
                    customerSPDescriptions = Model.customerSPDescriptions,


                };

                _context.CustomerSP.Add(CustomerSP);
                await _context.SaveChangesAsync();
                return Ok(CustomerSP);
            }

            return BadRequest(ModelState.Values);
        }



        // DELETE: api/CustomerSPs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerSP(int id)
        {
            var customerSP = await _context.CustomerSP.FindAsync(id);
            if (customerSP == null)
            {
                return NotFound();
            }

            _context.CustomerSP.Remove(customerSP);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerSPExists(int id)
        {
            return _context.CustomerSP.Any(e => e.customerSPid == id);
        }
    }
}
