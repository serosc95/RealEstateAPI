using BackendAPIRest.Application.DTOs;
using BackendAPIRest.Application.Interfaces;
using BackendAPIRest.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAPIRest.Application.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyService(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task<IEnumerable<PropertyDto>> GetAllAsync()
        {
            var properties = await _propertyRepository.GetAllAsync();
            return properties.Select(p => new PropertyDto
            {
                IdOwner = p.IdOwner,
                Name = p.Name,
                Address = p.Address,
                Price = p.Price,
                ImageUrl = p.ImageUrl
            });
        }

        public async Task<PropertyDto> GetByIdAsync(string id)
        {
            var property = await _propertyRepository.GetByIdAsync(id);
            if (property == null) return null;

            return new PropertyDto
            {
                IdOwner = property.IdOwner,
                Name = property.Name,
                Address = property.Address,
                Price = property.Price,
                ImageUrl = property.ImageUrl
            };
        }

        public async Task<IEnumerable<PropertyDto>> GetFilteredAsync(string name, string address, decimal? minPrice, decimal? maxPrice)
        {
            var properties = await _propertyRepository.GetFilteredAsync(name, address, minPrice, maxPrice);
            return properties.Select(p => new PropertyDto
            {
                IdOwner = p.IdOwner,
                Name = p.Name,
                Address = p.Address,
                Price = p.Price,
                ImageUrl = p.ImageUrl
            });
        }

        public async Task CreateAsync(PropertyDto propertyDto)
        {
            var property = new Property
            {
                IdOwner = propertyDto.IdOwner,
                Name = propertyDto.Name,
                Address = propertyDto.Address,
                Price = propertyDto.Price,
                ImageUrl = propertyDto.ImageUrl
            };

            await _propertyRepository.AddAsync(property);
        }

        public async Task UpdateAsync(string id, PropertyDto propertyDto)
        {
            var property = new Property
            {
                Id = id,
                IdOwner = propertyDto.IdOwner,
                Name = propertyDto.Name,
                Address = propertyDto.Address,
                Price = propertyDto.Price,
                ImageUrl = propertyDto.ImageUrl
            };

            await _propertyRepository.UpdateAsync(property);
        }

        public async Task DeleteAsync(string id)
        {
            await _propertyRepository.DeleteAsync(id);
        }
    }
}
