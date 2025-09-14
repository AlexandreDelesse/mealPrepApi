using Microsoft.EntityFrameworkCore;

namespace MealPrep.core.models;


public class IngredientContext : DbContext
{
    public IngredientContext(DbContextOptions<IngredientContext> options) : base(options)
    {

    }

    public DbSet<Ingredient> Ingredient { get; set; }
}