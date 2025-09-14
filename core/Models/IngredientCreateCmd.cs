namespace MealPrep.core.models;

public class IngredientCreateCmd
{
    public required string Name { get; set; }
    public required int Proteins { get; set; }
    public required int Fats { get; set; }
    public required int Carbs { get; set; }
}

