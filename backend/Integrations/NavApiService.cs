namespace backend.Integrations;

public class NavApiService
{
    private readonly HttpClient _httpClient;

    public NavApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetJobsAsync()
    {
        var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJuYXYudGVhbS5hcmJlaWRzcGxhc3NlbkBuYXYubm8iLCJraWQiOiI5YTY2OTc2MS1hMmFhLTQ2YjQtOWZkNi0yYTQ5YmNjZjJmNjUiLCJpc3MiOiJuYXYtbm8iLCJhdWQiOiJmZWVkLWFwaS12MiIsImlhdCI6MTc3ODYwOTYyOCwiZXhwIjoxNzgxNjMzNjI4fQ.qP6VWcO3alJmAM89y0-U1VcY0AJy0ZDMl9Tl7gK30tk";
        _httpClient.DefaultRequestHeaders.Authorization =
        new System.Net.Http.Headers.AuthenticationHeaderValue(
            "Bearer",
            token
        );

        var response = await _httpClient.GetAsync(
            "https://pam-stilling-feed.nav.no/api/v1/feed"
        );
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}