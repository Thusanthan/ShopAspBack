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
    public class StockDetailController : ControllerBase
    {
        private readonly StockDetailContext _context;

        public StockDetailController(StockDetailContext context)
        {
            _context = context;
        }

        // GET: api/StockDetail
        [HttpGet]
        public IEnumerable<StockDetail> GetStockdetails()
        {
            return _context.Stockdetails;
        }

        // GET: api/StockDetail/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStockDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stockDetail = await _context.Stockdetails.FindAsync(id);

            if (stockDetail == null)
            {
                return NotFound();
            }

            return Ok(stockDetail);
        }

        // PUT: api/StockDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStockDetail([FromRoute] int id, [FromBody] StockDetail stockDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stockDetail.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(stockDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockDetailExists(id))
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

        // POST: api/StockDetail
        [HttpPost]
        public async Task<IActionResult> PostStockDetail([FromBody] StockDetail stockDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Stockdetails.Add(stockDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStockDetail", new { id = stockDetail.ItemId }, stockDetail);
        }

        // DELETE: api/StockDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStockDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stockDetail = await _context.Stockdetails.FindAsync(id);
            if (stockDetail == null)
            {
                return NotFound();
            }

            _context.Stockdetails.Remove(stockDetail);
            await _context.SaveChangesAsync();

            return Ok(stockDetail);
        }

        private bool StockDetailExists(int id)
        {
            return _context.Stockdetails.Any(e => e.ItemId == id);
        }
    }
}