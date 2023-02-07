namespace PHShippingApp.Domain.ValueObjects
{
    public class DeliveryAddress
    {
        public DeliveryAddress(string street, string number, string zipCode, string city, string state, string country)
        {
            Street = street;
            Number = number;
            ZipCode = zipCode;
            City = city;
            State = state;
            Country = country;
        }

        public string Street { get; set; }

        public string Number { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }
    }
}
