using PHShippingApp.Domain.Entities;

namespace PHShippingApp.Application.ViewModels
{
    public class ShippingServiceViewModel
    {
        public ShippingServiceViewModel(Guid id, string title, decimal pricePerKg, decimal fixedPrice)
        {
            Id = id;
            Title = title;
            PricePerKg = pricePerKg;
            FixedPrice = fixedPrice;
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public decimal PricePerKg { get; set; }

        public decimal FixedPrice { get; set; }

        public static ShippingServiceViewModel GetFromEntity(ShippingService shippingService)
        {
            return new ShippingServiceViewModel(shippingService.Id, shippingService.Title, shippingService.PricePerKg, shippingService.FixedPrice);
        }
    }
}
