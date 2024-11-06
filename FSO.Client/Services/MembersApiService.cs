using System.Text.Json;

namespace FSO.Client.Services;

public class MembersApiService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl = "http://localhost:5046/api/members";

    public MembersApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<MemberApiDTO>> GetMembersAsync()
    {
        var response = await _httpClient.GetAsync(_baseUrl);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<MemberApiDTO>>(content);
    }
}