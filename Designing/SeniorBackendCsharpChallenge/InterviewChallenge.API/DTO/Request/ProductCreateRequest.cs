using InterviewChallenge.API.Models;

namespace InterviewChallenge.API.DTO.Request
{
    public class ProductCreateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int StockQuantity { get; set; }
        public List<Ingredient> Ingredients { get; set; }
    }
}
