using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Tables
{
    public interface ITableRepository
    {
        IEnumerable<Table> GetTables();
        Table GetById(int id);
        bool AddTable(Table table);
        bool UpdateTable(Table table);
        bool DeleteTable(int id);
        bool Save();
    }
}
