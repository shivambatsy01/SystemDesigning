using InterviewChallenge.API.Context;
using InterviewChallenge.API.DTO.Request;
using InterviewChallenge.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InterviewChallenge.API.Controllers
{
    [ApiController]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        private readonly DBContext _dbContext;
        public ProductsController(DBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                // Use Task.Run to wrap the synchronous operation
                var result = await Task.Run(() => _dbContext.ProductsCollection.FindAll().ToList());
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            try
            {
                // Use Task.Run to wrap the synchronous operation
                var result = await Task.Run(() => _dbContext.ProductsCollection.FindById(id));
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500, "Internal server error");
            }

        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCreateRequest request)
        {
            try
            {
                //assuming No empty body or empty body param is passed, else do validation, Not gonna implement here
                if(request.Ingredients != null)
                {
                    foreach(var ingredient in request.Ingredients)
                    {
                        var exist = _dbContext.IngredientsCollection.FindById(ingredient.Id);
                        if(exist == null)
                        {
                            return BadRequest($"ingredient {ingredient.Id} does not exist");
                        }
                    }
                }

                var product = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = request.Name,
                    Description = request.Description,
                    Price = request.Price,
                    StockQuantity = request.StockQuantity,
                    Ingredients = request.Ingredients
                };
                await Task.Run(() => _dbContext.ProductsCollection.Insert(product));
                return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500, "Internal server error");
            }

        }


        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            // in actual, I will use some flag to mark it deleted, to maintain history
            try
            {
                var product = await Task.Run(() => _dbContext.ProductsCollection.FindById(id));
                if (product == null)
                {
                    return NotFound($"Product with id: {id} not found");
                }

                await Task.Run(() => _dbContext.ProductsCollection.Delete(id));

                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500, "Internal server error");
            }

        }


        [HttpPatch]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCustomers(Guid id, [FromBody] ProductCreateRequest updatedProduct)
        {
            try
            {
                var existingProduct = await Task.Run(() => _dbContext.ProductsCollection.FindById(id));
                if (existingProduct == null)
                {
                    return NotFound($"Product with id: {id} not found");
                }
                if (updatedProduct == null)
                {
                    return BadRequest("Empty Body, Nothing to update");
                }

                existingProduct.Name = updatedProduct.Name;
                existingProduct.Price = updatedProduct.Price;
                existingProduct.StockQuantity = updatedProduct.StockQuantity;
                existingProduct.Description = updatedProduct.Description;
                existingProduct.Ingredients = updatedProduct.Ingredients;

                await Task.Run(() => _dbContext.ProductsCollection.Update((existingProduct)));

                return Ok(existingProduct);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500, "Internal server error");
            }

        }
    }
}
