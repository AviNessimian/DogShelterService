using Application.Contracts;
using Infrastructure.Configuration;
using Infrastructure.TheDogApi.Models;
using System.Text.Json;

namespace Infrastructure.TheDogApi
{
    public class TheDogApiBreedsApiService : IBreadDetailsContract
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseurl;
        public TheDogApiBreedsApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(nameof(HttpClientSettings.TheDogApiV1BreedsUrl));
            _baseurl = _httpClient.BaseAddress.ToString();
        }

        public async Task<BreadDetails> GetAsync(string breed, CancellationToken cancellationToken = default)
        {
            var searcResponse = await SearchAsync(breed, cancellationToken);
            if (searcResponse != null && searcResponse.Count() > 0)
            {
                return searcResponse.Select(x => new BreadDetails
                {
                    Id = x.Id,
                    Temperaments = x.Temperaments,
                    AverageHeight = x.CalcAverageHeight()
                }).FirstOrDefault();
            }

            return null;
        }

        private async Task<IEnumerable<DogBreedsSearchResponse>> SearchAsync(string query, CancellationToken cancellationToken = default)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_baseurl}/search?q={query}"),
            };

            var httpResponseMessage = await _httpClient.SendAsync(request, cancellationToken);
            httpResponseMessage.EnsureSuccessStatusCode();
            using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
            var response = await JsonSerializer
                .DeserializeAsync<IEnumerable<DogBreedsSearchResponse>>(contentStream, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }, cancellationToken);
            return response;
        }
    }
}
