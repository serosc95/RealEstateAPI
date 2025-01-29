using BackendAPIRest.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendAPIRest.Application.Interfaces
{
    public interface IPropertyRepository
    {
        Task<IEnumerable<Property>> GetAllAsync();
        Task<Property> GetByIdAsync(string id);
        Task<IEnumerable<Property>> GetFilteredAsync(string name, string address, decimal? minPrice, decimal? maxPrice);
        Task AddAsync(Property property);
        Task UpdateAsync(Property property);
        Task DeleteAsync(string id);
    }
}
