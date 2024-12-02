using InterviewChallenge.API.Context;
using InterviewChallenge.API.DTO.Request;
using InterviewChallenge.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace InterviewChallenge.API.Controllers
{
    [ApiController]
    [Route("api/ingredients")]
    public class IngredientsController : Controller
    {
        private readonly DBContext _dbContext;
        public IngredientsController(DBContext dbContext)
        {
            this._dbContext = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetIngredient()
        {
            try
            {
                // Use Task.Run to wrap the synchronous operation
                var result = await Task.Run(() => _dbContext.IngredientsCollection.FindAll().ToList());
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
        public async Task<IActionResult> GetIngredient(Guid id)
        {
            try
            {
                // Use Task.Run to wrap the synchronous operation
                var result = await Task.Run(() => _dbContext.IngredientsCollection.FindById(id));
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500, "Internal server error");
            }

        }


        [HttpPost]
        public async Task<IActionResult> CreateIngredient([FromBody] string ingredientName)
        {
            try
            {
                var ingredient = new Ingredient
                {
                    //can use validations here
                    Id = Guid.NewGuid(),
                    Name = ingredientName,
                };
                await Task.Run(() => _dbContext.IngredientsCollection.Insert(ingredient));
                return CreatedAtAction(nameof(GetIngredient), new { id = ingredient.Id }, ingredient);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500, "Internal server error");
            }

        }
    }
}
