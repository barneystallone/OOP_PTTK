using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Apifood.Database;
using backendtexxt.Database;
using Apifood.Models;

namespace Apifood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class menusController : ControllerBase
    {
        private readonly DemoDbContext _context;

        public menusController(DemoDbContext context)
        {
            _context = context;
        }

        // GET: api/menus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<menu>>> Getmenu()
        {
            return await _context.menu.ToListAsync();
        }

        // GET: api/menus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<menu>> Getmenu(int id)
        {
            var menu = await _context.menu.FindAsync(id);

            if (menu == null)
            {
                return NotFound();
            }

            return menu;
        }

        // PUT: api/menus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putmenu(int id, menu menu)
        {
            if (id != menu.menuid)
            {
                return BadRequest();
            }

            _context.Entry(menu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!menuExists(id))
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

        // POST: api/menus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754


        [HttpPost]
        public async Task<ActionResult<menu>> Addmenu([FromBody] addMenuModel Model)
        {
            if (ModelState.IsValid)
            {
                var menu = new menu()
                {
                    menuname = Model.menuname,
                    menuavata = Model.menuavata,
                };

                _context.menu.Add(menu);
                await _context.SaveChangesAsync();
                return Ok(menu);
            }

            return BadRequest(ModelState.Values);
        }



        // DELETE: api/menus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletemenu(int id)
        {
            var menu = await _context.menu.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }

            _context.menu.Remove(menu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool menuExists(int id)
        {
            return _context.menu.Any(e => e.menuid == id);
        }
    }
}
