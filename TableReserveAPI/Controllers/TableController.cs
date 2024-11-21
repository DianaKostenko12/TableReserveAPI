using AutoMapper;
using BLL.Services.Tables;
using BLL.Services.Tables.Descriptors;
using DAL.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TableReserveAPI.DTOs;

namespace TableReserveAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController, Route("table")]
    public class TableController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITableService _tableService;
        private readonly IMapper _mapper;
        public TableController(ITableService tableService, IHttpContextAccessor httpContextAccessor, IMapper mapper) 
        {
            _tableService = tableService;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddTable([FromBody] CreateTableDescriptor descriptor)
        {
            if (descriptor == null)
            {
                return BadRequest("Table descriptor cannot be null.");
            }

            try
            {
                await _tableService.AddTableAsync(descriptor);
                return Ok("Table added successfully.");
            }
            catch (BusinessException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTable(int tableId)
        {
            try
            {
                await _tableService.DeleteTableAsync(tableId);
                return Ok($"Table with ID {tableId} deleted successfully.");
            }
            catch (BusinessException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("free-tables")]
        public async Task<IActionResult> GetFreeTables([FromQuery] SearchTableDescriptor descriptor)
        {
            try
            {
                var freeTables = await _tableService.GetFreeTablesAsync(descriptor);
                var tablesDto = _mapper.Map<List<TableResponse>>(freeTables);
                return Ok(tablesDto);
            }
            catch (BusinessException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetTables()
        {
            try
            {
                var tables = await _tableService.GetTablesAsync();
                var tablesDto = _mapper.Map<List<TableResponse>>(tables);
                return Ok(tablesDto);
            }
            catch (BusinessException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
    }
}
