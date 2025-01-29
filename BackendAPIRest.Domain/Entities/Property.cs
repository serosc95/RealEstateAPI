namespace BackendAPIRest.Domain.Entities
{
    public class Property
    {
        public string Id { get; set; } = string.Empty;
        public string IdOwner { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
