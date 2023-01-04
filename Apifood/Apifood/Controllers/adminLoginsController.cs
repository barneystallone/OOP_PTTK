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
    public class adminLoginsController : ControllerBase
    {
        private readonly DemoDbContext _context;

        public adminLoginsController(DemoDbContext context)
        {
            _context = context;
        }

        // GET: api/adminLogins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<adminLogin>>> Getadmin()
        {
            var adminID = HttpContext?.User?.FindFirst("AdminID")?.Value;
            return await _context.admin.Where(x => x.adminid.ToString() == adminID).ToListAsync();
        }






        // GET: api/adminLogins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<adminLogin>> GetadminLogin(int id)
        {
            var adminLogin = await _context.admin.FindAsync(id);

            if (adminLogin == null)
            {
                return NotFound();
            }

            return adminLogin;
        }

        // PUT: api/adminLogins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutadminLogin(int id, adminLogin adminLogin)
        {
            if (id != adminLogin.adminid)
            {
                return BadRequest();
            }

            _context.Entry(adminLogin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!adminLoginExists(id))
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

        // POST: api/adminLogins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754




        [HttpPost]
        public async Task<ActionResult<adminLogin>> AddAdmin([FromBody] LoginModel Model)
        {
            if (ModelState.IsValid)
            {
                var adminLogin = new adminLogin()
                {
                    UserName = Model.UserName,
                    Password = BCrypt.Net.BCrypt.HashPassword(Model.Password),

                };

                _context.admin.Add(adminLogin);
                await _context.SaveChangesAsync();
                return Ok(adminLogin);
            }

            return BadRequest(ModelState.Values);

        }



        // DELETE: api/adminLogins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteadminLogin(int id)
        {
            var adminLogin = await _context.admin.FindAsync(id);
            if (adminLogin == null)
            {
                return NotFound();
            }

            _context.admin.Remove(adminLogin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool adminLoginExists(int id)
        {
            return _context.admin.Any(e => e.adminid == id);
        }
    }
}
