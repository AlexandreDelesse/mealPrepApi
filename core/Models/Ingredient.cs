namespace MealPrep.core.models;

public class Ingredient
{
    public Guid Id { get; set; } = new Guid();
    public required string Name { get; set; }
    public required int Proteins { get; set; }
    public required int Fats { get; set; }
    public required int Carbs { get; set; }
}

