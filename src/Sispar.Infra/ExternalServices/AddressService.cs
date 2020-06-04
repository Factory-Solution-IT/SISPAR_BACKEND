using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sispar.Infra.ExternalServices
{
    public class AddressService
    {
        private readonly HttpClient _httpClient;
        private readonly string ZipCoode;

        public AddressService(string zipCode)
        {
            this._httpClient = new HttpClient();
            ZipCoode = zipCode;
        }

        public async Task<AddressModel> DoSearh()
        {
            var url = @$"https://viacep.com.br/ws/{ ZipCoode }/json";
            var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            //string responseBody = await response.Content.ReadAsStringAsync();

            //return JsonSerializer.Deserialize<AddressModel>(responseBody);

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync
                <AddressModel>(responseStream);

        }
    }
}
