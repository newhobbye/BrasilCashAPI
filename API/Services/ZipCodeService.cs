using API.Entities;
using Newtonsoft.Json;
using RestSharp;

namespace API.Services
{
    public class ZipCodeService
    {

        public Address GetJsonInfoZipCode(string zipCode)
        {
            string url = "https://viacep.com.br/ws/" + zipCode + "/json";
            var param = new RestClient(url);
            var request = new RestRequest(Method.GET);
            var response = param.Execute(request);
            var result = JsonConvert.DeserializeObject<CepResult>(response.Content);

            Address address = new Address();
            address.Street = result.logradouro;
            address.District = result.bairro;
            address.City = result.localidade;
            address.State = result.uf;

            return address;
        }
    }
}
