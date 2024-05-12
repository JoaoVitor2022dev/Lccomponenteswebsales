namespace LccomponentesWeb.Models.ViewModels
{
    public class SalesRecordFormViewModel
    {
        public SalesRecord SalesRecord { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
