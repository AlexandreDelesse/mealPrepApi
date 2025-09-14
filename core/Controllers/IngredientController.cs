using MealPrep.core.models;
using Microsoft.AspNetCore.Mvc;

namespace MealPrep.core.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IngredientController : ControllerBase
{
    private readonly IngredientContext _context;

    public IngredientController(IngredientContext ingredientContext)
    {
        _context = ingredientContext;
    }

    [HttpGet]
    public ActionResult GetIngredients()
    {
        return Ok(_context.Ingredient.ToList());
    }

    [HttpPost]
    public ActionResult PostIngredient([FromBody] IngredientCreateCmd ingredient)
    {
        Ingredient cmd = new() { Id = new Guid(), Carbs = ingredient.Carbs, Fats = ingredient.Fats, Proteins = ingredient.Proteins, Name = ingredient.Name };
        _context.Add(cmd);
        _context.SaveChanges();
        return Ok(cmd);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteIngredient(Guid id)
    {
        Ingredient? found = _context.Ingredient.Find(id);
        if (found is null) return NotFound();

        _context.Remove(found);
        _context.SaveChanges();
        return Ok();
    }
}