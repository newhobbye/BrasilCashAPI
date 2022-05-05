using API.Data;
using API.Entities;
using API.Enums;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class RegisterController : Controller
    {
        private LocalDb _localDb;

        public RegisterController(LocalDb localDb)
        {
            _localDb = localDb;
        }

        [HttpGet]
        public IEnumerable<Client> GetClients()
        {
            return _localDb.Clients;
        }

        
    }
}
