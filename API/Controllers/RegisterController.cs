using API.Data;
using API.Entities;
using API.Interface;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("api/account/")]
    public class RegisterController : Controller
    {
        public RegisterController(LocalDb localDb, ZipCodeService zipCode)
        {
            _localDb = localDb;
            _zipCode = zipCode;
            

        }
        private LocalDb _localDb;
        private ZipCodeService _zipCode;
        



        [HttpGet]
        public IEnumerable<IUser> GetClients()
        {
            List<IUser> clientsAddress = new List<IUser>();

            var clients = _localDb.Clients.ToList();
            var address = _localDb.Address.ToList();

            foreach (var client in clients)
            {
                IUser client2 = new Client();
                  client2  = client;
                client2.Address = address.FirstOrDefault(a => a.AddressId == client.Tax_id);
                clientsAddress.Add(client2);
            }

            return clientsAddress;
        }

       
        [HttpGet("name/{name}")]
        public IEnumerable<IUser> GetClientsFilterName(string name)
        {
            List<IUser> clientsAddress = new List<IUser>();

            var clients = _localDb.Clients.ToList();
            var address = _localDb.Address.ToList();

             
            foreach (var client in clients)
            {
                IUser client2 = new Client();
                client2 = client;
                client2.Address = address.FirstOrDefault(a => a.AddressId == client.Tax_id);
                clientsAddress.Add(client2);
            }

            List<IUser> filterList = clientsAddress.Where(a => a.Name.ToLower() == name.ToLower()).ToList();

            return filterList;
        }

        [HttpGet("date/")]
        public IEnumerable<IUser> GetClientsFilterDate()
        {
            List<IUser> clientsAddress = new List<IUser>();

            var clients = _localDb.Clients.ToList();
            var address = _localDb.Address.ToList();


            foreach (var client in clients)
            {
                IUser client2 = new Client();
                client2 = client;
                client2.Address = address.FirstOrDefault(a => a.AddressId == client.Tax_id);
                clientsAddress.Add(client2);
            }           
           

           List<IUser> filterList = clientsAddress.OrderByDescending(c => c.Created_at).ToList();

            
            return filterList;
        }


        [HttpGet("{taxId}")]
        public IActionResult GetClientByTaxId(string taxId)
        {

            IUser client = new Client();
            client = _localDb.Clients.FirstOrDefault(x => x.Tax_id == taxId);
                if(client == null)
            {
                return NotFound("Usuario não encontrado!");
            }
                client.Address = _localDb.Address.FirstOrDefault(a => a.AddressId == taxId);
                
                 
                return Ok(client);              

        }


        [HttpPost]
        public IActionResult AddClient([FromBody] Client client)
        {
            if (client == null)
            {
                return NotFound("usuario vazio!");
            }

            
            string cpf = client.Tax_id;
            var validation = IdentityValidationService.IsCpfValid(cpf);
            if (validation == false)
            {
                return StatusCode(400, "CPF Invalido!");
            }


                if (!client.Postal_Code.All(char.IsDigit) || string.IsNullOrWhiteSpace(client.Postal_Code))
            {
                client.Status = "Pending";
                client.Address.AddressId = client.Tax_id;
            }
            else
            {
                client.Address = _zipCode.GetJsonInfoZipCode(client.Postal_Code);
                client.Address.AddressId = client.Tax_id;
                client.Status = "Approved";
              
            }

            _localDb.Clients.Add(client);
            _localDb.SaveChanges();
           
            return CreatedAtAction(nameof(GetClients), new { TaxId = client.Tax_id }, client);
        }

        



        [HttpDelete("{taxId}")]
        public IActionResult DeleteClientByTaxId(string taxId)
        {
            IUser client = _localDb.Clients.FirstOrDefault(x => x.Tax_id == taxId);
            IAddress address = _localDb.Address.FirstOrDefault(a => a.AddressId == taxId);

            
            if (client != null && client.Address != null)
            {
                
                _localDb.Remove(client);
                _localDb.Remove(address);
                _localDb.SaveChanges();
                return Ok("Usuario removido");
            }

            return NotFound("Usuario não encontrado!");
        }


    }
}
