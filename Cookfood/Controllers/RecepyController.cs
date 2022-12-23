using Cookfood.Data.Models;
using Cookfood.Data;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Cookfood.Auth.Model;

namespace Cookfood.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecepyController : ControllerBase
    {
        private readonly CookFoodDbContext _databaseContext;
        private readonly ILogger<RecepyController> _logger;
        private readonly IAuthorizationService _authorizationService;
        public RecepyController(CookFoodDbContext context, ILogger<RecepyController> logger, IAuthorizationService authorizationService)
        {
            _databaseContext = context;
            _logger = logger;
            _authorizationService = authorizationService;
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
        [Authorize(Roles = Roles.User)]
        public async Task<ActionResult<List<Recepy>>> Create(Recepy receipt)
        {
            receipt.UploadDate = DateTime.Now;
            receipt.UpdateDate = DateTime.Now;
            receipt.UserId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);

            _databaseContext.Recepies.Add(receipt);
            await _databaseContext.SaveChangesAsync();
            return Ok(await _databaseContext.Recepies.ToListAsync());
        }
        [HttpPut("{id}")]
        [Authorize(Roles = Roles.User + "," + Roles.Admin)]
        public async Task<ActionResult<List<Recepy>>> Update(int id, Recepy request)
        {
            var Receipt = await _databaseContext.Recepies.FindAsync(id);
            if (Receipt == null)
                return BadRequest("Receipt not found");

            var authResult = await _authorizationService.AuthorizeAsync(User, Receipt, PolicyNames.ResourceOwner);
            if (!authResult.Succeeded)
            {
                return BadRequest("No permissions");
            }

            Receipt.Description = request.Description;
            Receipt.Duration = request.Duration;
            Receipt.UpdateDate = DateTime.Now;
            Receipt.Name = request.Name;

            await _databaseContext.SaveChangesAsync();
            return Ok(await _databaseContext.Recepies.ToListAsync());
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Roles.User +","+ Roles.Admin)]
        public async Task<ActionResult<List<Recepy>>> Delete(int id)
        {
            var Receipt = await _databaseContext.Recepies.FindAsync(id);
            if (Receipt == null)
                return BadRequest("Receipt not found");

            var authResult = await _authorizationService.AuthorizeAsync(User, Receipt, PolicyNames.ResourceOwner);
            if (!authResult.Succeeded)
            {
                return BadRequest("No permissions");
            }

            _databaseContext.Recepies.Remove(Receipt);
            await _databaseContext.SaveChangesAsync();
            return Ok(Receipt);
        }
    }
}
