using Restaurant.Mapping.Models.Tables;

namespace Restaurant.Services.Tables
{
    public interface ITableService
    {
        Task Create(TableCreateDto input);

        Task Update(string id, TableUpdateDto input);

        Task<TableResultDto> GetById(string id);

        Task<IEnumerable<TableListDto>> GetAll(TablePaginationDto filters);

        Task<int> GetCount(TablePaginationDto filters);

        Task Delete(string id);
    }
}
