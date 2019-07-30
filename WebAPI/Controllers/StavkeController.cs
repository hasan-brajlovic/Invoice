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
    public class StavkeController : ControllerBase
    {
        private readonly InvoiceDetailContext _context;

        public StavkeController(InvoiceDetailContext context)
        {
            _context = context;
        }

        // GET: api/Stavke
        [HttpGet]
        public IEnumerable<Stavke> GetStavke()
        {
            return _context.Stavke;
        }

        //GET: api/Stavke/BrojFakture=?
        [HttpGet("{value}")]
        public async Task<IActionResult> GetStavke([FromRoute] string value)
        {
            var stavka = _context.Stavke.Where(s => s.BrojFakture == value).ToList();
            return Ok(stavka);

        }



        // GET: api/Stavke/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStavka([FromRoute] int id)
        
            {
                var stavke = _context.Stavke.FirstOrDefault(s => s.Sid == id);
                return Ok(stavke);

            }


        // PUT: api/Stavke/5
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

        // POST: api/Stavke
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

        // DELETE: api/Stavke/5
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