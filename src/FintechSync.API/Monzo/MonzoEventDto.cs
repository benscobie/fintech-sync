namespace FintechSync.API.Monzo
{
    public class MonzoEventDto
    {
        public string Type { get; set; }
        public DataDto Data { get; set; }
    }

    public class DataDto
    {
        public string AccountId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Created { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }
        public string Category { get; set; }
        public bool IsLoad { get; set; }
        public DateTime Settled { get; set; }
        public MerchantDto Merchant { get; set; }
    }

    public class AddressDto
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Postcode { get; set; }
        public string Region { get; set; }
    }

    public class MerchantDto
    {
        public AddressDto Address { get; set; }
        public DateTime Created { get; set; }
        public string GroupId { get; set; }
        public string Id { get; set; }
        public string Logo { get; set; }
        public string Emoji { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
    }
}
