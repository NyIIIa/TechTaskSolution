using System.Text;
using System.Text.Json;
using TechTask.Client.Dto.User.Add;
using TechTask.Client.Dto.User.Update;

namespace TechTask.Client.Services.User;

public class UserService : IUserService
{
    private readonly string _baseUrl = "http://localhost:5230/api/user";
    private readonly HttpClient _httpClient;

    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<AddUserResponse> Add(AddUserRequest addUserRequest)
    {
        var addUserRequestJson = new StringContent(JsonSerializer.Serialize(addUserRequest), Encoding.UTF8, "application/json");
        
        var response = await _httpClient.PostAsync($"{_baseUrl}/add", addUserRequestJson);

        if (response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStringAsync();

            var addedUserResponse = JsonSerializer.Deserialize<AddUserResponse>(responseBody,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return addedUserResponse;
        }

        return null;
    }

    public async Task<UpdateUserResponse> Update(UpdateUserRequest updateUserRequest)
    {
        var updateUserRequestJson = new StringContent(JsonSerializer.Serialize(updateUserRequest), Encoding.UTF8, "application/json");
        
        var response = await _httpClient.PutAsync($"{_baseUrl}/update", updateUserRequestJson);

        if (response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStringAsync();

            var updateUserResponse = JsonSerializer.Deserialize<UpdateUserResponse>(responseBody,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return updateUserResponse;
        }

        return null;
    }

    public async Task<IEnumerable<Data.User>> GetAll()
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}/getAll");

        using (Stream responseStream = await response.Content.ReadAsStreamAsync())
        {
            var users = await JsonSerializer.DeserializeAsync<IEnumerable<Data.User>>(responseStream,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return users;
        }
    }

    public async Task<Data.User> GetById(int userId)
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}/getById/{userId}");

        using (Stream responseStream = await response.Content.ReadAsStreamAsync())
        {
            var user = await JsonSerializer.DeserializeAsync<Data.User>(responseStream,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return user;
        }
    }
}