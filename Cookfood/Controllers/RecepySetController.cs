using Cookfood.Data.Models;
using Cookfood.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cookfood.Auth.Model;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Cookfood.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecepySetController : ControllerBase
    {
        private readonly CookFoodDbContext _databaseContext;
        private readonly ILogger<RecepySetController> _logger;
        private readonly IAuthorizationService _authorizationService;

        public RecepySetController(CookFoodDbContext context, ILogger<RecepySetController> logger, IAuthorizationService authorizationService)
        {
            _databaseContext = context;
            _logger = logger;
            _authorizationService = authorizationService;
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

        [HttpGet("user")]
        [Authorize(Roles = Roles.User)]
        public async Task<ActionResult<List<RecepySet>>> GetUserRecepySet()
        {
            var ReceiptSet = await _databaseContext.RecepySets.ToListAsync();
            if (ReceiptSet.Count == 0)
                return BadRequest("ReceiptSet not found");

            var Receipts = ReceiptSet.Where(s => s.UserId == User.FindFirstValue(JwtRegisteredClaimNames.Sub)).ToList();
            if (Receipts.Count == 0)
                return BadRequest("User has no recepySets");
            return Ok(Receipts);
        }



        [HttpPost]
        [Authorize(Roles = Roles.User)]
        public async Task<ActionResult<List<RecepySet>>> Create(RecepySet receiptSet)
        {
            receiptSet.UserId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            _databaseContext.RecepySets.Add(receiptSet);
            await _databaseContext.SaveChangesAsync();
            return Ok(await _databaseContext.RecepySets.ToListAsync());
        }
        [HttpPut("{id}")]
        [Authorize(Roles = Roles.User + "," + Roles.Admin)]
        public async Task<ActionResult<List<RecepySet>>> Update(int id, RecepySet request)
        {
            var ReceiptSet = await _databaseContext.RecepySets.FindAsync(id);
            if (ReceiptSet == null)
                return BadRequest("ReceiptSet not found");
            var authResult = await _authorizationService.AuthorizeAsync(User, ReceiptSet, PolicyNames.ResourceOwner);
            if (!authResult.Succeeded)
            {
                return BadRequest("No permissions");
            }

            ReceiptSet.Name = request.Name;
            ReceiptSet.Type = request.Type;
            await _databaseContext.SaveChangesAsync();
            return Ok(await _databaseContext.RecepySets.ToListAsync());
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Roles.User + "," + Roles.Admin)]
        public async Task<ActionResult<List<RecepySet>>> Delete(int id)
        {
            var ReceiptSet = await _databaseContext.RecepySets.FindAsync(id);
            if (ReceiptSet == null)
                return BadRequest("ReceiptSet not found");

            var authResult = await _authorizationService.AuthorizeAsync(User, ReceiptSet, PolicyNames.ResourceOwner);
            if (!authResult.Succeeded)
            {
                return BadRequest("No permissions");
            }

            _databaseContext.RecepySets.Remove(ReceiptSet);
            await _databaseContext.SaveChangesAsync();
            return Ok(ReceiptSet);
        }
    }
}
