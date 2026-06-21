using backend.DTOs;
using System.Text.Json;
namespace backend.Integrations;

public class NavApiService
{
    private readonly HttpClient _httpClient;

    public NavApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<NavJobDto>> GetJobsAsync()
    {
        var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJuYXYudGVhbS5hcmJlaWRzcGxhc3NlbkBuYXYubm8iLCJraWQiOiI5YTY2OTc2MS1hMmFhLTQ2YjQtOWZkNi0yYTQ5YmNjZjJmNjUiLCJpc3MiOiJuYXYtbm8iLCJhdWQiOiJmZWVkLWFwaS12MiIsImlhdCI6MTc4MTI2OTExOCwiZXhwIjoxNzg0MjkzMTE4fQ.x0qEOjDyWQpT6aw4Q0RW1VQEUHtYqXFzoVygHraXI6s";
        _httpClient.DefaultRequestHeaders.Authorization =
        new System.Net.Http.Headers.AuthenticationHeaderValue(
            "Bearer",
            token);

        var response = await _httpClient.GetAsync(
            //https://pam-stilling-feed.nav.no/api/publicToken , find new public token
            "https://pam-stilling-feed.nav.no/api/v1/feed"
        );
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };
        var apiResult = JsonSerializer.Deserialize<NavApiResponse>(json, options);
        if (apiResult?.Items == null)
        {
            return new List<NavJobDto>();
        }
        return apiResult.Items.Select(job => new NavJobDto
        {
            Title = job.Title,
            Company = job.FeedEntry?.BusinessName ?? "Unknown",
            Location = job.FeedEntry?.Municipal ?? "Unknown"
        }).ToList();
    }
}