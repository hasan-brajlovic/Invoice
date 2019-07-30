using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StavkeControllerNEW : ControllerBase
    {
        private readonly InvoiceDetailContext _context;

        public StavkeControllerNEW(InvoiceDetailContext context)
        {
            _context = context;
        }

        // GET: api/StavkeControllerNEW
        [HttpGet]
        public IEnumerable<Stavke> GetStavke()
        {
            return _context.Stavke;
        }

        // GET: api/StavkeControllerNEW/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStavke([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stavke = await _context.Stavke.FindAsync(id);

            if (stavke == null)
            {
                return NotFound();
            }

            return Ok(stavke);
        }
        //GET: api/StavkeControlerNEW/BrojFakture=?
        [HttpGet("BrojFakture="+"{value}")]
        public async Task<IActionResult> GetStavke([FromRoute] string value)
        {
            var stavke = _context.Stavke.Where(s => s.BrojFakture == value).ToList();
            return Ok(stavke);

        }


        // PUT: api/StavkeControllerNEW/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStavke([FromRoute] int id, [FromBody] Stavke stavke)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stavke.Sid)
            {
                return BadRequest();
            }

            _context.Entry(stavke).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StavkeExists(id))
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

        // POST: api/StavkeControllerNEW
        [HttpPost]
        public async Task<IActionResult> PostStavke([FromBody] Stavke stavke)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Stavke.Add(stavke);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStavke", new { id = stavke.Sid }, stavke);
        }

        // DELETE: api/StavkeControllerNEW/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStavke([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stavke = await _context.Stavke.FindAsync(id);
            if (stavke == null)
            {
                return NotFound();
            }

            _context.Stavke.Remove(stavke);
            await _context.SaveChangesAsync();

            return Ok(stavke);
        }

        private bool StavkeExists(int id)
        {
            return _context.Stavke.Any(e => e.Sid == id);
        }
    }
}