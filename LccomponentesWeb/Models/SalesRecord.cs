using LccomponentesWeb.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace LccomponentesWeb.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        public string Client { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Display(Name = "Price")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Price { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public SalesRecord()
        { }
        public SalesRecord(int id, DateTime date, double price, PaymentMethod paymentMethod, Product product, int productId)
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
