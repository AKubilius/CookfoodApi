using Cookfood.Data.Models;
using Cookfood.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cookfood.Auth.Model;
using Microsoft.AspNetCore.Authorization;

namespace Cookfood.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly CookFoodDbContext _databaseContext;
        private readonly ILogger<IngredientController> _logger;
        private readonly IAuthorizationService _authorizationService;
        public IngredientController(CookFoodDbContext context, ILogger<IngredientController> logger, IAuthorizationService authorizationService)
        {
            _databaseContext = context;
            _logger = logger;
            _authorizationService = authorizationService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _databaseContext.Ingredients.ToListAsync());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<List<Ingredient>>> Get(int id)
        {
            var Ingredient = await _databaseContext.Ingredients.FindAsync(id);
            if (Ingredient == null)
                return BadRequest("Ingredient not found");
            return Ok(Ingredient);
        }

        [HttpPost]
        [Authorize(Roles = Roles.User)]
        public async Task<ActionResult<List<Ingredient>>> Create(Ingredient ingredient)
        {
            _databaseContext.Ingredients.Add(ingredient);
            await _databaseContext.SaveChangesAsync();
            return Ok(await _databaseContext.Ingredients.ToListAsync());
        }

        [HttpPut("{id}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<ActionResult<List<Ingredient>>> Update(int id, Ingredient request)
        {
            var Ingredient = await _databaseContext.Ingredients.FindAsync(request.Id);
            if (Ingredient == null)
                return BadRequest("Ingredient not found");
            var authResult = await _authorizationService.AuthorizeAsync(User, Ingredient, PolicyNames.ResourceOwner);
            if (!authResult.Succeeded)
            {
                return BadRequest("No permissions");
            }
            Ingredient.Name = request.Name;
            Ingredient.Quanity = request.Quanity;
            Ingredient.Measurement = request.Measurement;
            await _databaseContext.SaveChangesAsync();
            return Ok(await _databaseContext.Ingredients.ToListAsync());
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<ActionResult<List<Ingredient>>> Delete(int id)
        {
            var Ingredient = await _databaseContext.Ingredients.FindAsync(id);
            if (Ingredient == null)
                return BadRequest("Ingredient not found");
            var authResult = await _authorizationService.AuthorizeAsync(User, Ingredient, PolicyNames.ResourceOwner);
            if (!authResult.Succeeded)
            {
                return BadRequest("No permissions");
            }

            _databaseContext.Ingredients.Remove(Ingredient);
            await _databaseContext.SaveChangesAsync();
            return Ok(Ingredient);
        }
    }
}
