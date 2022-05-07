using Restaurant.Mapping.Models.Tables;

namespace Restaurant.Services.Tables
{
    public interface ITableService
    {
        Task Create(TableCreateDto input);

        Task Update(string id, TableUpdateDto input);

        Task<TableResultDto> GetById(string id);

        Task<IEnumerable<TableResultDto>> GetAll();

        Task Delete(string id);
    }
}
