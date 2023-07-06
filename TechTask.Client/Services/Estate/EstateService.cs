using System.Text;
using System.Text.Json;
using TechTask.Client.Dto.Estate.Add;
using TechTask.Client.Dto.Estate.Update;

namespace TechTask.Client.Services.Estate;

public class EstateService : IEstateService
{
    private readonly string _baseUrl = "http://localhost:5230/api/estate";
    private readonly HttpClient _httpClient;

    public EstateService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<AddEstateResponse> Add(AddEstateRequest addEstateRequest)
    {
        var addEstateRequestJson = new StringContent(JsonSerializer.Serialize(addEstateRequest), Encoding.UTF8, "application/json");
        
        var response = await _httpClient.PostAsync($"{_baseUrl}/add", addEstateRequestJson);

        if (response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStringAsync();

            var addEstateResponse = JsonSerializer.Deserialize<AddEstateResponse>(responseBody,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return addEstateResponse;
        }

        return null;
    }

    public async Task<UpdateEstateResponse> Update(UpdateEstateRequest updateEstateRequest)
    {
        var updateEstateRequestJson = new StringContent(JsonSerializer.Serialize(updateEstateRequest), Encoding.UTF8, "application/json");
        
        var response = await _httpClient.PutAsync($"{_baseUrl}/update", updateEstateRequestJson);

        if (response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStringAsync();

            var updateEstateResponse = JsonSerializer.Deserialize<UpdateEstateResponse>(responseBody,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return updateEstateResponse;
        }

        return null;
    }

    public async Task<IEnumerable<Data.Estate>> GetAll()
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}/getAll");

        using (Stream responseStream = await response.Content.ReadAsStreamAsync())
        {
            var estates = await JsonSerializer.DeserializeAsync<IEnumerable<Data.Estate>>(responseStream,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return estates;
        }
    }

    public async Task<Data.Estate> GetById(int estateId)
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}/getById/{estateId}");

        using (Stream responseStream = await response.Content.ReadAsStreamAsync())
        {
            var estate = await JsonSerializer.DeserializeAsync<Data.Estate>(responseStream,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return estate;
        }
    }
}