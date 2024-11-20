using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Tables
{
    public class TableRepository : ITableRepository
    {
        private readonly DataContext _context;

        public TableRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddTableAsync(Table table)
        {
            await _context.AddAsync(table);
            return await SaveAsync();
        }

        public async Task<IEnumerable<Table>> GetTablesAsync()
        {
            return await _context.Tables.ToListAsync();
        }

        public async Task<Table> GetByIdAsync(int id)
        {
            return await _context.Tables.Where(t => t.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> DeleteTableAsync(int id)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table != null)
            {
                _context.Remove(table);
                return await SaveAsync();
            }
            return false;
        }

        public async Task<bool> SaveAsync()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0;
        }

        public async Task<IEnumerable<Table>> GetFreeTablesAsync(DateTime date, int numberOfGuests)
        {
            var freeTables = await _context.Tables
                    .Where(t => t.Capacity >= numberOfGuests &&
                                !t.Bookings.Any(b => b.Date.Date == date.Date)) 
                    .ToListAsync();
            return freeTables;
        }

        public async Task<bool> IsExistTable(string number)
        {
            return await _context.Tables.AnyAsync(t => t.Number == number);
        }
    }
}
