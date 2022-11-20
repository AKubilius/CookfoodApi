using Cookfood.Data.Models;
using Cookfood.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cookfood.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecepySetController : ControllerBase
    {
        private readonly CookFoodDbContext _databaseContext;
        private readonly ILogger<RecepySetController> _logger;
        public RecepySetController(CookFoodDbContext context, ILogger<RecepySetController> logger)
        {
            _databaseContext = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _databaseContext.RecepySets.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<RecepySet>>> Get(int id)
        {
            var ReceiptSet = await _databaseContext.RecepySets.FindAsync(id);
            if (ReceiptSet == null)
                return BadRequest("ReceiptSet not found");
            return Ok(ReceiptSet);
        }

        [HttpGet("{type}")]
        public async Task<ActionResult<List<RecepySet>>> GetFiltered(string type)
        {
            var ReceiptSet = await _databaseContext.RecepySets.ToListAsync();
            if (ReceiptSet.Count == 0)
                return BadRequest("ReceiptSet not found");

            var Receipts = ReceiptSet.Where(s => s.Type.ToLower() == type.ToLower()).ToList();
            if (Receipts.Count == 0)
                return BadRequest("ReceiptSet not found");
            return Ok(Receipts);
        }

        [HttpGet("recepy/{id}")]
        public async Task<ActionResult<List<RecepySet>>> GetReceipts(int id)
        {
            var ReceiptSet = await _databaseContext.Recepies.ToListAsync();
            if (ReceiptSet.Count == 0)
                return BadRequest("ReceiptSet not found");
            var Receipts = ReceiptSet.Where(s => s.RecepySetId == id).ToList();
            if (Receipts.Count == 0)
                return BadRequest("Receipt not found");
            return Ok(Receipts);
        }

        [HttpPost]
        public async Task<ActionResult<List<RecepySet>>> Create(RecepySet receiptSet)
        {
            _databaseContext.RecepySets.Add(receiptSet);
            await _databaseContext.SaveChangesAsync();
            return Ok(await _databaseContext.RecepySets.ToListAsync());
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<RecepySet>>> Update(RecepySet request)
        {
            var ReceiptSet = await _databaseContext.RecepySets.FindAsync(request.Id);
            if (ReceiptSet == null)
                return BadRequest("ReceiptSet not found");
            ReceiptSet.Name = request.Name;
            ReceiptSet.Type = request.Type;
            await _databaseContext.SaveChangesAsync();
            return Ok(await _databaseContext.RecepySets.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<RecepySet>>> Delete(int id)
        {
            var ReceiptSet = await _databaseContext.RecepySets.FindAsync(id);
            if (ReceiptSet == null)
                return BadRequest("ReceiptSet not found");

            _databaseContext.RecepySets.Remove(ReceiptSet);
            await _databaseContext.SaveChangesAsync();
            return Ok(ReceiptSet);
        }
    }
}
