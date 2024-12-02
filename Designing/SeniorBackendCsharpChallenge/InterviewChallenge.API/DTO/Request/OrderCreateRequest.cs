namespace InterviewChallenge.API.DTO.Request
{
    public class OrderCreateRequest
    {
        public DateTime OrderDate { get; set; }
        public Guid CustomerId { get; set; }
        public List<OrderItemCreateRequest> orderItems { get; set; }

    }
}
