using LiteDB;
using InterviewChallenge.API.Models;

namespace InterviewChallenge.API.Context
{
    public class DBContext
    {
        private readonly LiteDatabase database;
        public DBContext(LiteDatabase database)
        {
            this.database = database;
        }
        public LiteDatabase Database { get { return database; } }


        public ILiteCollection<Customer> CustomersCollection => database.GetCollection<Customer>("Customers");
        public ILiteCollection<Order> OrdersCollection => database.GetCollection<Order>("Orders");
        public ILiteCollection<OrderItem> OrderItemsCollection => database.GetCollection<OrderItem>("OrderItems");
        public ILiteCollection<Product> ProductsCollection => database.GetCollection<Product>("Products");
        public ILiteCollection<Ingredient> IngredientsCollection => database.GetCollection<Ingredient>("Ingredients");
        public ILiteCollection<BakingSchedule> BakingSchedulesCollection => database.GetCollection<BakingSchedule>("BakingSchedules");

    }
}
