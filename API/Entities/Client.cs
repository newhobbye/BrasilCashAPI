
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("dbo.clientAPI")]
    public class Client
    {
        [Key]
        [Required(ErrorMessage = "Campo CPF é obrigatório!")]
        [StringLength(11, MinimumLength = 11)]
        public string Tax_id { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo senha é obrigatório!")]
        [StringLength(40, MinimumLength = 8)]
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
