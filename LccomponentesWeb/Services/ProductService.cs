using LccomponentesWeb.Data;
using LccomponentesWeb.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace LccomponentesWeb.Services
{
    public class ProductService
    {
        private readonly LccomponentesWebContext _context;

        public ProductService(LccomponentesWebContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> FindAllAsync()
        {
            return await _context.Product.ToListAsync();
        }
    }
}
