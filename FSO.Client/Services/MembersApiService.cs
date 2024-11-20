using System.Text.Json;

namespace FSO.Client.Services;

public class MembersApiService
{
    private readonly HttpClient _httpClient;

    private readonly string? _apiEndpoint;  
    
    
    public MembersApiService(HttpClient httpClient, IConfiguration configuration)
    {
        
        _httpClient = httpClient;
        
        _apiEndpoint = configuration.GetValue<string>("ApiEndpointUrl");     
                
    }


    public async Task<List<MemberApiDTO>?> GetMembersAsync()
    {
        var response = await _httpClient.GetAsync(_apiEndpoint);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<MemberApiDTO>>(content);
    }
}