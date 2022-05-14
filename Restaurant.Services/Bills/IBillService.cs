using Restaurant.Mapping.Models.Bills;

namespace Restaurant.Services.Bills
{
    public interface IBillService
    {
        Task Create(BillCreateDto input);

        Task Update(string id, BillUpdateDto input);

        Task<BillResultDto> GetById(string id);

        Task<IEnumerable<BillListDto>> GetAll();

        Task Delete(string id);
    }
}
