using InterviewChallenge.API.Models;

namespace InterviewChallenge.API.DTO.Request
{
    public class OrderItemCreateRequest
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
