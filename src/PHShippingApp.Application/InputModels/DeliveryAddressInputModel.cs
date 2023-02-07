using PHShippingApp.Domain.ValueObjects;

namespace PHShippingApp.Application.InputModels
{
    public class DeliveryAddressInputModel
    {
        public string Street { get; set; }

        public string Number { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public DeliveryAddress ToValueObject() => new DeliveryAddress(Street, Number, ZipCode, City, State, Country);
    }
}
