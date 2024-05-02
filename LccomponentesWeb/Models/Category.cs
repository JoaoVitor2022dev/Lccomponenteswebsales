namespace LccomponentesWeb.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public Category()
        { }

        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public void AddProducts(Product product)
        {
            Products.Add(product);
        }
        public void RemoverProducts(Product product)
        {
            Products.Remove(product);
        }
    }
}
