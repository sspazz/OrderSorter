using Core.DTOs;
using Core.Models;

namespace Core.Abstractions.Services
{
    public interface IGenericService<TEntityModel, TEntityDTO> where TEntityModel : BaseEntityModel where TEntityDTO : BaseEntityDTO
    {
        public Task<TEntityDTO> Get(int id);

        public Task<List<TEntityDTO>> Get();

        Task<PaginationResult<TEntityDTO>> GetPage(int page, int pageSize);

        public Task<TEntityDTO> Add(TEntityDTO entity);

        public Task<TEntityDTO> Update(TEntityDTO entity);

        public Task<TEntityDTO> Delete(int id);
    }
}
