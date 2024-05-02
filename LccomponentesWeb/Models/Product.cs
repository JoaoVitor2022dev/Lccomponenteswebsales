using System.ComponentModel.DataAnnotations;

namespace LccomponentesWeb.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Display(Name = "Price")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Product()
        { }

        public Product(int id, string name, string description, double price, int quantity)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }
    }
}
