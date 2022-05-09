using API.Entities;

namespace API.Interface
{
    public interface IAddress
    {
        public string AddressId { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public string ClientId { get; set; }
        public Client Client { get; set; }
    }
}
