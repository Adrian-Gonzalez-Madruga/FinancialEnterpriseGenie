using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialEnterpriseGenie.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinancialEnterpriseGenie.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private GenieDatabase _context;

        public OrderController(GenieDatabase context)
        {
            _context = context;
        }
        [HttpGet]
        public async IAsyncEnumerable<List<Receipt>> Get()
        {
            var receipt = await _context
                .Receipts
                .Include(u => u.User)
                .Include(i => i.Item)
                .Include(d => d.Distributor)
                .ToListAsync();

            yield return (receipt);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var course = _context.Receipts.Find(id);

            if (course == null)
            {
                return NotFound(new { error = "Id is not found" });
            }

            return Ok(course);
        }

        [HttpPost]
        public IActionResult Post(Models.Receipt receipt)
        {
            var sameName = _context.Receipts.FirstOrDefault(c => c.Id == receipt.Id);
            if (sameName == null)
            {
                _context.Receipts.Add(receipt);
                _context.SaveChanges();
                return Ok(receipt);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}