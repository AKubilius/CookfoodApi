using Cookfood.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Cookfood.Data
{
    public class CookFoodDbContext:DbContext
    {
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recepy> Recepies { get; set; }
        public DbSet<RecepySet> RecepySets { get; set; }
        public DbSet<RecepyIngredient> recepyIngredients { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=augustosaitynai.database.windows.net,1433;Initial Catalog=saitynaisql;User=AugustasAdmin;Password=Saitynai123;");
        }
    }
}
