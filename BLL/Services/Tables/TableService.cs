using AutoMapper;
using BLL.Services.Tables.Descriptors;
using DAL.Exceptions;
using DAL.Models;
using DAL.Repositories.Tables;
using System.Net;

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
            if (existingTable)
            {
                throw new BusinessException(HttpStatusCode.Conflict, $"Table with number {descriptor.Number} already exists.");
            }

            var tableToCreate = _mapper.Map<Table>(descriptor);
            await _tableRepository.AddTableAsync(tableToCreate);
            await _tableRepository.SaveAsync();
        }

        public async Task DeleteTableAsync(int tableId)
        {
            var tableToDelete = await _tableRepository.GetByIdAsync(tableId);
            if (tableToDelete == null)
            {
                throw new BusinessException(HttpStatusCode.NotFound, $"Table with ID {tableId} was not found.");
            }

            await _tableRepository.DeleteTableAsync(tableId);
            await _tableRepository.SaveAsync();
        }

        public async Task<IEnumerable<Table>> GetFreeTablesAsync(SearchTableDescriptor descriptor)
        {
            if (descriptor == null)
            {
                throw new ArgumentNullException(nameof(descriptor));
            }

            if (descriptor.Date.Date < DateTime.UtcNow.Date)
            {
                throw new BusinessException(HttpStatusCode.BadRequest, "Cannot search for free tables for a past date.");
            }

            return await _tableRepository.GetFreeTablesAsync(descriptor.Date, descriptor.NumberOfGuests);
        }

        public async Task<IEnumerable<Table>> GetTablesAsync()
        {
            return await _tableRepository.GetTablesAsync();
        }
    }
}
