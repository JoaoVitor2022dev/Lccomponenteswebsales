namespace LccomponentesWeb.Models.ViewModels
{
    public class ProductFormViewModel
    {
        public Product Product { get; set; }
        public ICollection<Category> Category { get; set; }
    }
}
