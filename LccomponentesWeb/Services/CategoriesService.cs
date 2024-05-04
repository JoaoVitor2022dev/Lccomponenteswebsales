using LccomponentesWeb.Data;
using LccomponentesWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace LccomponentesWeb.Services
{
    public class CategoriesService
    {
        private readonly LccomponentesWebContext _context;

        public CategoriesService(LccomponentesWebContext context)
        {
            _context = context;
        }
        public async Task<List<Category>> FindAllAsync()
        {
            return await _context.Category.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
