using BackendAPIRest.Application.Interfaces;
using BackendAPIRest.Domain.Entities;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendAPIRest.Infrastructure.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly IMongoCollection<Property> _properties;

        public PropertyRepository(IMongoDatabase database)
        {
            _properties = database.GetCollection<Property>("Properties");
        }

        public async Task<IEnumerable<Property>> GetAllAsync()
        {
            return await _properties.Find(_ => true).ToListAsync();
        }

        public async Task<Property> GetByIdAsync(string id)
        {
            return await _properties.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Property>> GetFilteredAsync(string name, string address, decimal? minPrice, decimal? maxPrice)
        {
            var filter = Builders<Property>.Filter.Empty;
            
            if (!string.IsNullOrEmpty(name))
                filter &= Builders<Property>.Filter.Eq(p => p.Name, name);

            if (!string.IsNullOrEmpty(address))
                filter &= Builders<Property>.Filter.Eq(p => p.Address, address);

            if (minPrice.HasValue)
                filter &= Builders<Property>.Filter.Gte(p => p.Price, minPrice.Value);

            if (maxPrice.HasValue)
                filter &= Builders<Property>.Filter.Lte(p => p.Price, maxPrice.Value);

            return await _properties.Find(filter).ToListAsync();
        }

        public async Task AddAsync(Property property)
        {
            await _properties.InsertOneAsync(property);
        }

        public async Task UpdateAsync(Property property)
        {
            await _properties.ReplaceOneAsync(p => p.Id == property.Id, property);
        }

        public async Task DeleteAsync(string id)
        {
            await _properties.DeleteOneAsync(p => p.Id == id);
        }
    }
}