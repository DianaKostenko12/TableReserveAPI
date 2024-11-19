using AutoMapper;
using BLL.Services.Bookings.Descriptors;
using BLL.Services.Tables.Descriptors;
using DAL.Models;
using DAL.Repositories.Bookings;
using DAL.Repositories.Tables;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Tables
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;
        private readonly IMapper _mapper;

        public TableService(ITableRepository tableRepository,IMapper mapper)
        {
            _tableRepository = tableRepository;
            _mapper = mapper;
        }

        public async Task AddTableAsync(CreateTableDescriptor descriptor)
        {
            if(descriptor == null) 
                throw new ArgumentNullException(nameof(descriptor));

            var existingTable = await _tableRepository.IsExistTable(descriptor.Number);
            if (!existingTable)
            {
                var tableToCreate = _mapper.Map<Table>(descriptor);
                await _tableRepository.AddTableAsync(tableToCreate);
                await _tableRepository.SaveAsync();
            }
        }

        public async Task DeleteTableAsync(int tableId)
        {
            var tableToDelete = await _tableRepository.GetByIdAsync(tableId);
            if (tableToDelete == null)
            {
                throw new KeyNotFoundException($"Table with ID {tableId} was not found.");
            }

            await _tableRepository.DeleteTableAsync(tableId);
            await _tableRepository.SaveAsync();
        }

        public async Task<IEnumerable<Table>> GetFreeTablesAsync(SearchTableDescriptor descriptor)
        {
           return await _tableRepository.GetFreeTablesAsync(descriptor.Date, descriptor.NumberOfGuests);
        }

        public async Task<IEnumerable<Table>> GetTablesAsync()
        {
            return await _tableRepository.GetTablesAsync();
        }
    }
}
