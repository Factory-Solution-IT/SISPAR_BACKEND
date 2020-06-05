using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sispar.Infra.ExternalServices
{
    public class AddressService
    {
        private readonly HttpClient _httpClient;

        public AddressService() => _httpClient = new HttpClient();

        public async Task<AddressModel> DoSearh(string zipCode)
        {
            var url = @$"https://viacep.com.br/ws/{ zipCode.Trim() }/json";
            var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var viaCepModel = await JsonSerializer.DeserializeAsync<ViaCepModel>(responseStream);

            var result = (viaCepModel.cep == null) 
                ? null 
                : new AddressModel(
                    viaCepModel.cep,
                    viaCepModel.logradouro,
                    viaCepModel.complemento,
                    viaCepModel.bairro,
                    viaCepModel.localidade,
                    viaCepModel.uf
                );
            return result;
        }

        internal class ViaCepModel
        {
            public string cep { get; set; }
            public string logradouro { get; set; }
            public string complemento { get; set; }
            public string bairro { get; set; }
            public string localidade { get; set; }
            public string uf { get; set; }
            public string unidade { get; set; }
            public string ibge { get; set; }
            public string gia { get; set; }
        }
    }
}
