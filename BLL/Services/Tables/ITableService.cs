using BLL.Services.Tables.Descriptors;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
