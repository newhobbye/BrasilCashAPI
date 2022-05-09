using API.Entities;
using System;

namespace API.Interface
{
    public interface IUser
    {
        public string Tax_id { get; set; }

        
        public string Name { get; set; }

        
        public string Password { get; set; }
        public string Phone_number { get; set; }
        public DateTime Created_at { get; set; }
        public string Postal_Code { get; set; }
        public string Status { get; set; }

        public string AddressId { get; set; }
        public Address Address { get; set; }
    }
}
