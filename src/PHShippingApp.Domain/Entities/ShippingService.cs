namespace PHShippingApp.Domain.Entities
{
    public class ShippingService : BaseEntity
    {
        public ShippingService(string title, decimal pricePerKg, decimal fixedPrice)
        {
            Title = title;
            PricePerKg = pricePerKg;
            FixedPrice = fixedPrice;
        }

        public string Title { get; protected set; }

        public decimal PricePerKg { get; protected set; }

        public decimal FixedPrice { get; protected set; }
    }
}
