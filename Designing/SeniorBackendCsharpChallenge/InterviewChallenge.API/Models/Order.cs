namespace InterviewChallenge.API.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid CustomerId { get; set; }
        public decimal OrderAmount { get; set; }

    }
}
