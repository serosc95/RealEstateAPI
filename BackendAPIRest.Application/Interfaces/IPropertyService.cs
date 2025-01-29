using BackendAPIRest.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendAPIRest.Application.Interfaces
{
    public interface IPropertyService
    {
        Task<IEnumerable<PropertyDto>> GetAllAsync();
        Task<PropertyDto> GetByIdAsync(string id);
        Task<IEnumerable<PropertyDto>> GetFilteredAsync(string name, string address, decimal? minPrice, decimal? maxPrice);
        Task CreateAsync(PropertyDto propertyDto);
        Task UpdateAsync(string id, PropertyDto propertyDto);
        Task DeleteAsync(string id);
    }
}
