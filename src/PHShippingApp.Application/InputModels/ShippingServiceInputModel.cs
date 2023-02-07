using PHShippingApp.Domain.Entities;

namespace PHShippingApp.Application.InputModels
{
    public class ShippingServiceInputModel
    {
        public string Title { get; set; }

        public decimal PricePerKg { get; set; }

        public decimal FixedPrice { get; set; }

        public ShippingService ToEntity() => new ShippingService(Title, PricePerKg, FixedPrice);
    }
}
