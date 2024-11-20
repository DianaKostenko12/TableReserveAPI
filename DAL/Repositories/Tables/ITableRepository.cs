using DAL.Models;

namespace DAL.Repositories.Tables
{
    public interface ITableRepository
    {
        Task<IEnumerable<Table>> GetTablesAsync();
        Task<Table> GetByIdAsync(int id);
        Task<IEnumerable<Table>> GetFreeTablesAsync(DateTime date, int numberOfGuests);
        Task<bool> AddTableAsync(Table table);
        Task<bool> DeleteTableAsync(int id);
        Task<bool> IsExistTable(string number);
        Task<bool> SaveAsync();
    }
}
