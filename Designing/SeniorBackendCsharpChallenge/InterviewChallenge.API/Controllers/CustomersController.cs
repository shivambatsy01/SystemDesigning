using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InterviewChallenge.API.Context;
using InterviewChallenge.API.DTO.Request;
using InterviewChallenge.API.Models;

namespace InterviewChallenge.API.Controllers
{
    [ApiController]
    [Route("api/Customers")]
    public class CustomersController : Controller
    {
        private readonly DBContext _dbContext;
        public CustomersController(DBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                // Use Task.Run to wrap the synchronous operation
                var result = await Task.Run(() => _dbContext.CustomersCollection.FindAll().ToList());
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
        public async Task<IActionResult> GetCustomer(Guid id)
        {
            try
            {
                // Use Task.Run to wrap the synchronous operation
                var result = await Task.Run(() => _dbContext.CustomersCollection.FindById(id));
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500, "Internal server error");
            }

        }


        [HttpPost]
        public async Task<IActionResult> CreateCustomers([FromBody] CustomerCreateRequest request)
        {
            try
            {
                var customer = new Customer
                { //further can use validation here e.g. Name should not be empty and return 400 bad request if name is null.
                    //Not going to implement here
                    Id = Guid.NewGuid(),
                    Name = request.Name,
                    Address = request.Address
                };
                await Task.Run(() => _dbContext.CustomersCollection.Insert(customer));
                return CreatedAtAction(nameof(GetCustomer), new {id = customer.Id}, customer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500, "Internal server error");
            }

        }


        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteCustomers(Guid id)
        {
            try
            {
                var customer = await Task.Run(() => _dbContext.CustomersCollection.FindById(id));
                if(customer == null)
                {
                    return NotFound($"Customer with id: {id} not found");
                }

                await Task.Run(() => _dbContext.CustomersCollection.Delete(id));

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
        public async Task<IActionResult> UpdateCustomers(Guid id,[FromBody] CustomerCreateRequest customer)
        {
            try
            {
                var existingcustomer = await Task.Run(() => _dbContext.CustomersCollection.FindById(id));
                if (existingcustomer == null)
                {
                    return NotFound($"Customer with id: {id} not found");
                }
                if(customer == null)
                {
                    return BadRequest("Empty Body, Nothing to update");
                }

                existingcustomer.Name = customer.Name;
                existingcustomer.Address = customer.Address;

                await Task.Run(() => _dbContext.CustomersCollection.Update((existingcustomer)));

                return Ok(existingcustomer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500, "Internal server error");
            }

        }
    }
}
