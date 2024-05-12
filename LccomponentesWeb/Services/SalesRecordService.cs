using LccomponentesWeb.Data;
using LccomponentesWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic; 

namespace LccomponentesWeb.Services
{
    public class SalesRecordService
    {
        private readonly LccomponentesWebContext _context;

        public SalesRecordService(LccomponentesWebContext context)
        {
            _context = context;
        }
        public async Task<List<SalesRecord>> FindAllAsync()
        {
            return await _context.SalesRecord.ToListAsync();
        }
        public async Task InsertAsync(SalesRecord obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
        public async Task<SalesRecord> FindByIdAsync(int id)
        {
            return await _context.SalesRecord.Include(obj => obj.Product).FirstOrDefaultAsync(obj => obj.Id == id);
        }
    }
}