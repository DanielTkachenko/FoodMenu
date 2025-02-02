namespace FoodMenuWebApp.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        public List<MenuItemIngredient> MenuItemIngredients { get; set; }
    }
}
