using Incident.SOR.Domain.DTO.Request;

namespace Incident.SOR.Application.Persistence
{
    public interface IRepository<T>
    {
        Task<T> GetAsync(int systemId);
        Task<int> CountRecordsAsync();
        Task<IEnumerable<T>> GetManyAsync(FilterRequestDto filterRequest);
        Task<IEnumerable<T>> GetManyAsync();
        Task<Guid> AddAsync(T record);
        Task<T?> UpdateAsync(int systemId, T record);
        Task<bool> DeleteAsync(int systemId);
    }
}
