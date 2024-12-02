using InterviewChallenge.API.Models;


namespace InterviewChallenge.API.Context
{
    public class DummyDataSeeder
    {
        private DBContext _dbContext;

        public DummyDataSeeder(DBContext dBContext)
        {
                _dbContext = dBContext;
        }


        public void GenerateDummyData()
        {
            var existingCustomersCollectionCount = _dbContext.CustomersCollection.Count();
            if(existingCustomersCollectionCount > 0)
            {
                return;
            }

            List<Customer> customers = new List<Customer>
            {
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "John",
                    Address = "New York"
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Max",
                    Address = "Seattle"
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Alex",
                    Address = "SF"
                },
            };
            _dbContext.CustomersCollection.InsertBulk(customers);


            List<Ingredient> ingredients = new List<Ingredient>
            {
                new Ingredient
                {
                    Id = Guid.NewGuid(),
                    Name = "Wheat Floor",
                },
                new Ingredient
                {
                    Id = Guid.NewGuid(),
                    Name = "Whole Wheat Floor",
                },
                new Ingredient
                {
                    Id = Guid.NewGuid(),
                    Name = "Butter",
                },
                new Ingredient
                {
                    Id = Guid.NewGuid(),
                    Name = "Sugar"
                },
                new Ingredient
                {
                    Id = Guid.NewGuid(),
                    Name = "Salt"
                },
                new Ingredient
                {
                    Id = Guid.NewGuid(),
                    Name = "Milk",
                },
                new Ingredient
                {
                    Id = Guid.NewGuid(),
                    Name = "Cream",
                },
                new Ingredient
                {
                    Id = Guid.NewGuid(),
                    Name = "Egg",
                }
            };
            _dbContext.IngredientsCollection.InsertBulk(ingredients);



            List<Product> products = new List<Product>
            {
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Whole Wheat Bread",
                    Description = "Made of whole wheat, no cholesterol",
                    Price = 10.4,
                    StockQuantity = 100,
                    Ingredients = new List<Ingredient>{ingredients[1], ingredients[3]}
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Cream Bun",
                    Description = "Creamy and Tasty",
                    Price = 20.0,
                    StockQuantity = 50,
                    Ingredients = new List<Ingredient>{ingredients[0], ingredients[6]}
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Cookies",
                    Description = "Sweet and salty",
                    Price = 5.0,
                    StockQuantity = 180,
                    Ingredients = new List<Ingredient> {ingredients[0], ingredients[3], ingredients[4], ingredients[6]}
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Cake",
                    Description = "Yummy",
                    Price = 5.0,
                    StockQuantity = 180,
                    Ingredients = new List<Ingredient> {ingredients[3], ingredients[6], ingredients[7]}
                }
            };
            _dbContext.ProductsCollection.InsertBulk(products);



            List<OrderItem> orderItems = new List<OrderItem>()
            {
                new OrderItem
                {
                    Id = Guid.NewGuid(),
                    Product = products[0],
                    Quantity = 2,
                },
                new OrderItem
                {
                    Id = Guid.NewGuid(),
                    Product = products[1],
                    Quantity = 3,
                },
                new OrderItem
                {
                    Id = Guid.NewGuid(),
                    Product = products[3],
                    Quantity = 1,
                },
                new OrderItem
                {
                    Id = Guid.NewGuid(),
                    Product = products[2],
                    Quantity = 3,
                },
                new OrderItem
                {
                    Id = Guid.NewGuid(),
                    Product = products[3],
                    Quantity = 4,
                },
                new OrderItem
                {
                    Id = Guid.NewGuid(),
                    Product = products[1],
                    Quantity = 2,
                },
                new OrderItem
                {
                    Id = Guid.NewGuid(),
                    Product = products[0],
                    Quantity = 5,
                }
            };
            _dbContext.OrderItemsCollection.InsertBulk(orderItems);



            List<Order> orders = new List<Order>
            {
                new Order
                {
                    Id= Guid.NewGuid(),
                    OrderDate = new DateTime(2024, 01, 04),
                    CustomerId = customers[0].Id
                },
                new Order
                {
                    Id= Guid.NewGuid(),
                    OrderDate = new DateTime(2023, 02, 08),
                    CustomerId = customers[1].Id
                },
                new Order
                {
                    Id= Guid.NewGuid(),
                    OrderDate = new DateTime(2024, 02, 20),
                    CustomerId = customers[2].Id
                }
            };
            _dbContext.OrdersCollection.InsertBulk(orders);
        }

    }
}
