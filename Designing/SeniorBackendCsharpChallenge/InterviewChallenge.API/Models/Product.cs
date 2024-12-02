namespace InterviewChallenge.API.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int StockQuantity { get; set; } // Inventory level
        public List<Ingredient> Ingredients { get; set; } 
        //didn't used IngredientId here, number of ingredients may be large in db, but object size is small,
        //haven't used quantity of ingredient, otherwise dictionary or mapping could be used
    }
}
