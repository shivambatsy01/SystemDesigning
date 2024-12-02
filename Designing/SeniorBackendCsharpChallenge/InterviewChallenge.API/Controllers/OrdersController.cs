using InterviewChallenge.API.Context;
using InterviewChallenge.API.DTO.Request;
using InterviewChallenge.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace InterviewChallenge.API.Controllers
{
    [ApiController]
    [Route("api/Orders")]
    public class OrdersController : Controller
    {
        private readonly DBContext _dbContext;
        public OrdersController(DBContext dbContext)
        {
            this._dbContext = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                // Use Task.Run to wrap the synchronous operation
                var result = await Task.Run(() => _dbContext.OrdersCollection.FindAll().ToList());
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
        public async Task<IActionResult> GetOrder(Guid id)
        {
            try
            {
                // Use Task.Run to wrap the synchronous operation
                var result = await Task.Run(() => _dbContext.OrdersCollection.FindById(id));
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500, "Internal server error");
            }

        }


        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderCreateRequest orderRequest)
        {
            try
            {
                var customer = _dbContext.CustomersCollection.FindById(orderRequest.CustomerId);
                if(customer == null)
                {
                    return BadRequest($"Customer {orderRequest.CustomerId} does not exist.");
                }

                var allProductsValid = orderRequest.orderItems.TrueForAll(x => (_dbContext.ProductsCollection.FindById(x.ProductId)!=null));
                if (!allProductsValid)
                {
                    return BadRequest($"Products not valid, Please check again.");
                }

                if (orderRequest.OrderDate > DateTime.Now)
                {
                    return BadRequest($"Can not create future date order");
                }

                try
                {
                    var order = new Order
                    {
                        Id = Guid.NewGuid(),
                        CustomerId = customer.Id,
                        OrderDate = orderRequest.OrderDate

                    };
                    double orderAmount = 0.0;

                    List<OrderItem> orderItems = new List<OrderItem>();
                    foreach(var item in orderRequest.orderItems)
                    {
                        var product = _dbContext.ProductsCollection.FindById(item.ProductId);

                        orderItems.Add(new OrderItem
                        {
                            Id = Guid.NewGuid(),
                            OrderId = order.Id,
                            Product = product,
                            Quantity = item.Quantity
                        });
                        orderAmount += item.Quantity*product.Price;
                    }


                    var transaction = _dbContext.Database.BeginTrans();
                    if(transaction)
                    {
                        try
                        {
                            _dbContext.OrdersCollection.Insert(order);
                            foreach (var item in orderItems)
                            {
                                var product = _dbContext.ProductsCollection.FindById(item.Product.Id);
                                if (product == null)
                                {
                                    throw new BadHttpRequestException($"Products {item.Product.Id} not valid, Please check again.");
                                }
                                if (product.StockQuantity < item.Quantity)
                                {
                                    throw new BadHttpRequestException($"Products {item.Product.Id} has {product.StockQuantity} in stock");
                                }
                                else
                                {
                                    product.StockQuantity -= item.Quantity;
                                    _dbContext.ProductsCollection.Update(product);
                                }

                                _dbContext.OrderItemsCollection.Insert(item);
                            }

                            _dbContext.OrdersCollection.Insert(order);

                            _dbContext.Database.Commit();
                        }
                        catch (BadHttpRequestException ex)
                        {
                            _dbContext.Database.Rollback();
                            return BadRequest(ex.Message);
                        }
                        catch (Exception ex)
                        {
                            _dbContext.Database.Rollback();
                            return StatusCode(500, "Internal server error: Please try again!"); //custom HTTP codes and messages can be implemented
                        }

                        return CreatedAtAction(nameof(GetOrder), new {id = order.Id}, order);
                    }
                    else
                    {
                        throw new Exception("Unable to perform DB transaction this time");
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500, "Internal server error: " +  ex.Message); //custom messages can be implemented
            }

        }
    }
}
