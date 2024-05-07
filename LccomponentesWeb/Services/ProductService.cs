using LccomponentesWeb.Data;
using LccomponentesWeb.Models;
using LccomponentesWeb.Services.Exeptions;
using Microsoft.EntityFrameworkCore;

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
        public async Task InsertAsync(Product obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
        public async Task<Product> FindByIdAsync(int id)
        {
            return await _context.Product.Include(obj => obj.Category).FirstOrDefaultAsync(obj => obj.Id == id);
        }
        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Product.FindAsync(id);

            if (obj != null)
            {
                _context.Product.Remove(obj);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateAsync(Product obj)
        {
            if (!await _context.Product.AnyAsync(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id não encontrado.");
            }

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

    }
}

