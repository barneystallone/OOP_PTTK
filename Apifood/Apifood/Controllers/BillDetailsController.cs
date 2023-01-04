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
    public class BillDetailsController : ControllerBase
    {
        private readonly DemoDbContext _context;

        public BillDetailsController(DemoDbContext context)
        {
            _context = context;
        }

        // GET: api/BillDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BillDetail>>> GetBillDetail()
        {
            return await _context.BillDetail.ToListAsync();
        }

        // GET: api/BillDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BillDetail>> GetBillDetail(int id)
        {
            var billDetail = await _context.BillDetail.FindAsync(id);

            if (billDetail == null)
            {
                return NotFound();
            }

            return billDetail;
        }



    
    [HttpGet("BillDetail")]
    public async Task<ActionResult<IEnumerable<BillDetail>>> BillDetail([FromQuery] string BillId)
    {

        var tmp = int.Parse(BillId);
        var data = from p in _context.BillDetail
                   where (p.BillId == tmp)
                   select (p);
        return await data.ToListAsync();
    }



    // PUT: api/BillDetails/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
        public async Task<IActionResult> PutBillDetail(int id, BillDetail billDetail)
        {
            if (id != billDetail.BiDid)
            {
                return BadRequest();
            }

            _context.Entry(billDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillDetailExists(id))
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

        // POST: api/BillDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BillDetail>> Addfood([FromBody] BillDetailModel Model)
        {
            if (ModelState.IsValid)
            {
                var BillDetail = new BillDetail()
                {

                    foodname = Model.foodname,
                    foodprice = Model.foodprice,
                    Quantity = Model.Quantity,
                    BillId = Model.BillId,
                    Allprice = Model.Allprice,


                };

                _context.BillDetail.Add(BillDetail);
                await _context.SaveChangesAsync();
                return Ok(BillDetail);
            }

            return BadRequest(ModelState.Values);
        }

        // DELETE: api/BillDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBillDetail(int id)
        {
            var billDetail = await _context.BillDetail.FindAsync(id);
            if (billDetail == null)
            {
                return NotFound();
            }

            _context.BillDetail.Remove(billDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BillDetailExists(int id)
        {
            return _context.BillDetail.Any(e => e.BiDid == id);
        }
    }
}
