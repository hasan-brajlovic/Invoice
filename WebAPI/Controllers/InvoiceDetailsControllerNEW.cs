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
    public class InvoiceDetailsControllerNEW : ControllerBase
    {
        private readonly InvoiceDetailContext _context;

        public InvoiceDetailsControllerNEW(InvoiceDetailContext context)
        {
            _context = context;
        }

        // GET: api/InvoiceDetailsControllerNEW
        [HttpGet]
        public IEnumerable<InvoiceDetail> GetInvoiceDetails()
        {
            return _context.InvoiceDetails;
        }

        // GET: api/InvoiceDetailsControllerNEW/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoiceDetail([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var invoiceDetail = await _context.InvoiceDetails.FindAsync(id);

            if (invoiceDetail == null)
            {
                return NotFound();
            }

            return Ok(invoiceDetail);
        }

        // PUT: api/InvoiceDetailsControllerNEW/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoiceDetail([FromRoute] int id, [FromBody] InvoiceDetail invoiceDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != invoiceDetail.Fid)
            {
                return BadRequest();
            }

            _context.Entry(invoiceDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceDetailExists(id))
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

        private bool InvoiceDetailExists(int id)
        {
            throw new NotImplementedException();
        }

        // POST: api/InvoiceDetailsControllerNEW
        [HttpPost]
        public async Task<IActionResult> PostInvoiceDetail([FromBody] InvoiceDetail invoiceDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.InvoiceDetails.Add(invoiceDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoiceDetail", new { id = invoiceDetail.BrojFakture }, invoiceDetail);
        }

        //GET: api/InvoiceDetailControllerNEW/=Fid?
        [HttpGet("Fid=" + "{value}")]
        public async Task<IActionResult> GetInvoiceDetail([FromRoute] int value)
        {

            var cijena = _context.InvoiceDetails.Where(p => p.Fid == value).Select(p => p.CijenaFakture);
            return Ok(cijena);


        }

        //PUT: api/InvoiceDetailControllerNEW/Fid=?;CijenaFakture=?
        [HttpPut("[action]"+"/{value}{cijena}")]
        public IActionResult PutInvoiceDetailPrice([FromRoute] int value, double cijena)
        {
            var result = _context.InvoiceDetails.Single(b => b.Fid == value);
            if (result != null)
            {
                result.CijenaFakture = cijena;
                _context.SaveChanges();
               
            }
            return Ok(result);
        }

        // DELETE: api/InvoiceDetailsControllerNEW/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoiceDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var invoiceDetail = await _context.InvoiceDetails.FindAsync(id);
            if (invoiceDetail == null)
            {
                return NotFound();
            }

            _context.InvoiceDetails.Remove(invoiceDetail);
            await _context.SaveChangesAsync();

            return Ok(invoiceDetail);
        }

        private bool InvoiceDetailExists(string id)
        {
            return _context.InvoiceDetails.Any(e => e.BrojFakture == id);
        }
    }
}