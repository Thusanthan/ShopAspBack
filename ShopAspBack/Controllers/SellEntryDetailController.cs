using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopAspBack.Models;

namespace ShopAspBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellEntryDetailController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public SellEntryDetailController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/SellEntryDetail
        [HttpGet]
        public IEnumerable<SellEntryDetail> GetsellEntryDetails()
        {
            return _context.sellEntryDetails;
        }

        // GET: api/SellEntryDetail/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSellEntryDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sellEntryDetail = await _context.sellEntryDetails.FindAsync(id);

            if (sellEntryDetail == null)
            {
                return NotFound();
            }

            return Ok(sellEntryDetail);
        }

        // PUT: api/SellEntryDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSellEntryDetail([FromRoute] int id, [FromBody] SellEntryDetail sellEntryDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sellEntryDetail.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(sellEntryDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellEntryDetailExists(id))
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

        // POST: api/SellEntryDetail
        [HttpPost]
        public async Task<IActionResult> PostSellEntryDetail([FromBody] SellEntryDetail sellEntryDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.sellEntryDetails.Add(sellEntryDetail);
            await _context.SaveChangesAsync();

            
            

            return CreatedAtAction("GetSellEntryDetail", new { id = sellEntryDetail.ItemId }, sellEntryDetail);
        }

        // DELETE: api/SellEntryDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSellEntryDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sellEntryDetail = await _context.sellEntryDetails.FindAsync(id);
            if (sellEntryDetail == null)
            {
                return NotFound();
            }

            _context.sellEntryDetails.Remove(sellEntryDetail);
            await _context.SaveChangesAsync();

            return Ok(sellEntryDetail);
        }

        private bool SellEntryDetailExists(int id)
        {
            return _context.sellEntryDetails.Any(e => e.ItemId == id);
        }
    }
}