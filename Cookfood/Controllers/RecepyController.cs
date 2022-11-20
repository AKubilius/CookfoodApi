using Cookfood.Data.Models;
using Cookfood.Data;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace Cookfood.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecepyController : ControllerBase
    {
        private readonly CookFoodDbContext _databaseContext;
        private readonly ILogger<RecepyController> _logger;
        public RecepyController(CookFoodDbContext context, ILogger<RecepyController> logger)
        {
            _databaseContext = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _databaseContext.Recepies.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Recepy>>> Get(int id)
        {
            var Receipt = await _databaseContext.Recepies.FindAsync(id);
            if (Receipt == null)
                return BadRequest("Receipt not found");
            return Ok(Receipt);
        }

        [HttpPost]
        public async Task<ActionResult<List<Recepy>>> Create(Recepy receipt)
        {
            receipt.UpdateDate = DateTime.Now;
            string regex = @"^[0-9]*$";
            Regex re = new Regex(regex);
            if (!re.IsMatch(receipt.Duration.ToString()))
            {
                return BadRequest("Trukmė needs to a number");
            }
            else
            {
                return BadRequest("Blogas skaicius");
            }

            _databaseContext.Recepies.Add(receipt);
            await _databaseContext.SaveChangesAsync();
            return Ok(await _databaseContext.Recepies.ToListAsync());
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Recepy>>> Update(Recepy request)
        {
            var Receipt = await _databaseContext.Recepies.FindAsync(request.Id);
            if (Receipt == null)
                return BadRequest("Receipt not found");
            Receipt.Description = request.Description;
            Receipt.Duration = request.Duration;
            Receipt.UpdateDate = DateTime.Now;
            Receipt.Name = request.Name;

            await _databaseContext.SaveChangesAsync();
            return Ok(await _databaseContext.Recepies.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Recepy>>> Delete(int id)
        {
            var Receipt = await _databaseContext.Recepies.FindAsync(id);
            if (Receipt == null)
                return BadRequest("Receipt not found");

            _databaseContext.Recepies.Remove(Receipt);
            await _databaseContext.SaveChangesAsync();
            return Ok(Receipt);
        }
    }
}
