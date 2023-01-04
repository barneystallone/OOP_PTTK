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
    public class SlidersController : ControllerBase
    {
        private readonly DemoDbContext _context;

        public SlidersController(DemoDbContext context)
        {
            _context = context;
        }

        // GET: api/Sliders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Slider>>> Getslide()
        {
            return await _context.slide.ToListAsync();
        }

        // GET: api/Sliders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Slider>> GetSlider(int id)
        {
            var slider = await _context.slide.FindAsync(id);

            if (slider == null)
            {
                return NotFound();
            }

            return slider;
        }
        [HttpGet("SliderHot")]
        public async Task<ActionResult<IEnumerable<Slider>>> GetOutstandingFood([FromQuery] string slidetype)
        {

            var tmp = int.Parse(slidetype);
            var data = from p in _context.slide
                       where (p.slidetype == tmp)
                       select (p);
            return await data.ToListAsync();
        }


        // PUT: api/Sliders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSlider(int id, Slider slider)
        {
            if (id != slider.slideid)
            {
                return BadRequest();
            }

            _context.Entry(slider).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SliderExists(id))
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

        // POST: api/Sliders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
     




        [HttpPost]
        public async Task<ActionResult<Slider>> Addmenu([FromBody] SliderModel Model)
        {
            if (ModelState.IsValid)
            {
                var Slider = new Slider()
                {
                    slidetitle = Model.slidetitle,
                    slidedescription = Model.slidedescription,
                    slideimg = Model.slideimg,
                    slidetype = Model.slidetype,
                };

                _context.slide.Add(Slider);
                await _context.SaveChangesAsync();
                return Ok(Slider);
            }

            return BadRequest(ModelState.Values);
        }


        // DELETE: api/Sliders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSlider(int id)
        {
            var slider = await _context.slide.FindAsync(id);
            if (slider == null)
            {
                return NotFound();
            }

            _context.slide.Remove(slider);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SliderExists(int id)
        {
            return _context.slide.Any(e => e.slideid == id);
        }
    }
}
