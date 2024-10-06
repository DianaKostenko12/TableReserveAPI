using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Tables
{
    public class TableRepository : ITableRepository
    {
        private readonly DataContext _context;
        public TableRepository(DataContext context)
        {
            _context = context;
        }

        public bool AddTable(Table table)
        {
            _context.Add(table);
            return Save();
        }

        public IEnumerable<Table> GetTables()
        {
            return _context.Tables.OrderBy(t => t.Id).ToList();
        }

        public Table GetById(int id)
        {
            return _context.Tables.Where(t => t.Id == id).FirstOrDefault();
        }

        public bool UpdateTable(Table table)
        {
            _context.Update(table);
            return Save();
        }

        public bool DeleteTable(int id)
        {
            _context.Remove(id);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
