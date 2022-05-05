using API.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("dbo.client")]
    public class Client
    {
        public Client()
        {
            Address = new Address();
        }
        [Key]
        [Required(ErrorMessage = "Campo CPF é obrigatório!")]
        [StringLength(11, MinimumLength = 11)]
        public string Tax_id { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo senha é obrigatório!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Campo telefone é obrigatório!")]
        public string Phone_number { get; set; }
        public string Postal_Code { get; set; }
        public string Status{ get; set; }

        public Address Address { get; set; }
}
}
