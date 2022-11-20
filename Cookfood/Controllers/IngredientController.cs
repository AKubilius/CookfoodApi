using Cookfood.Data.Models;
using Cookfood.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cookfood.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly CookFoodDbContext _databaseContext;
        private readonly ILogger<IngredientController> _logger;
        public IngredientController(CookFoodDbContext context, ILogger<IngredientController> logger)
        {
            _databaseContext = context;
            _logger = logger;
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
        public async Task<ActionResult<List<Ingredient>>> Create(Ingredient ingredient)
        {
            _databaseContext.Ingredients.Add(ingredient);
            await _databaseContext.SaveChangesAsync();
            return Ok(await _databaseContext.Ingredients.ToListAsync());
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Ingredient>>> Update(Ingredient request)
        {
            var Ingredient = await _databaseContext.Ingredients.FindAsync(request.Id);
            if (Ingredient == null)
                return BadRequest("Ingredient not found");
            Ingredient.Name = request.Name;
            Ingredient.Quanity = request.Quanity;
            Ingredient.Measurement = request.Measurement;
            await _databaseContext.SaveChangesAsync();
            return Ok(await _databaseContext.Ingredients.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Ingredient>>> Delete(int id)
        {
            var Ingredient = await _databaseContext.Ingredients.FindAsync(id);
            if (Ingredient == null)
                return BadRequest("Ingredient not found");

            _databaseContext.Ingredients.Remove(Ingredient);
            await _databaseContext.SaveChangesAsync();
            return Ok(Ingredient);
        }
    }
}
