
using API.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("dbo.clientAPI")]
    public class Client: IUser
    {
        [Key]
        public string Tax_id { get; set; }

       
        public string Name { get; set; }

        public string Password { get; set; }
        public string Phone_number { get; set; }
        public DateTime Created_at { get; set; }
        public string Postal_Code { get; set; }
        public string Status{ get; set; }

        public string AddressId { get; set; }
        public Address Address { get; set; }
       

        public Client()
        {
            Address = new Address();
            Created_at = DateTime.Now;
        }

    }
}
