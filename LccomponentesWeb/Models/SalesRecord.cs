using LccomponentesWeb.Models.Enums;

namespace LccomponentesWeb.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public SalesRecord()
        { }
        public SalesRecord(int id, DateTime date, decimal price, PaymentMethod paymentMethod, Product product, int productId)
        {
            Id = id;
            Date = date;
            Price = price;
            PaymentMethod = paymentMethod;
            Product = product;
            ProductId = productId;
        }
    }
}
