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
using System.Security.Claims;

namespace Apifood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly DemoDbContext _context;

        public BillsController(DemoDbContext context)
        {
            _context = context;
        }

        // GET: api/Bills

        [HttpGet]
        [Route("Admin")]

        public async Task<IEnumerable<Bill>> GetBillAdmin()
        {         
            return await _context.Bill.ToListAsync();

        }





        [HttpGet]
        [Authorize]

        public async Task<IEnumerable<Bill>> GetBill()
        {
           var customerId = HttpContext?.User?.FindFirst("CustomerID")?.Value;

          return await _context.Bill.Where(x => x.customerid.ToString() == customerId).ToListAsync();


    //       var customer = HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;


   //       return await _context.Bill.Where(x => x.Customer == customer).ToListAsync();
           // return await _context.Bill.ToListAsync();
        }





        // GET: api/Bills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bill>> GetBill(int id)
        {
            var bill = await _context.Bill.FindAsync(id);

            if (bill == null)
            {
                return NotFound();
            }

            return bill;
        }


   




        // PUT: api/Bills/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBill(int id, Bill bill)
        {
            if (id != bill.BillId)
            {
                return BadRequest();
            }

            _context.Entry(bill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillExists(id))
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

        // POST: api/Bills
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPost]
        public async Task<ActionResult<Bill>> AddBill([FromBody] BillModel Model)
        {
            if (ModelState.IsValid)
            {
                var Bill = new Bill()
                {
                    Customer = Model.Customer,
                    Phonenumber = Model.Phonenumber,
                    Address = Model.Address,
                    customerid = Model.customerid,
                     Status = Model.Status,
                };
            

            _context.Bill.Add(Bill);
            await _context.SaveChangesAsync();
            return Ok(Bill);
        };

            return BadRequest(ModelState.Values);
    } 



    // DELETE: api/Bills/5
    [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBill(int id)
        {
            var bill = await _context.Bill.FindAsync(id);
            if (bill == null)
            {
                return NotFound();
            }

            _context.Bill.Remove(bill);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BillExists(int id)
        {
            return _context.Bill.Any(e => e.BillId == id);
        }
    }
}
