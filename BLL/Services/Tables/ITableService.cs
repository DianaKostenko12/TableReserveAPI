using BLL.Services.Tables.Descriptors;
using DAL.Models;

namespace BLL.Services.Tables
{
    public interface ITableService
    {
        Task AddTableAsync(CreateTableDescriptor descriptor);
        Task DeleteTableAsync(int tableId);
        Task<IEnumerable<Table>> GetTablesAsync();
        Task<IEnumerable<Table>> GetFreeTablesAsync(SearchTableDescriptor descriptor);
    }
}
