using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;
using movies_rating.Models;
using movies_rating.Data;

public class TMDbMovieImporter
{
    private readonly HttpClient _http;
    private readonly string _apiKey;
    private readonly ApplicationDbContext _db;

    public TMDbMovieImporter(
        IHttpClientFactory httpFactory,
        IConfiguration config,
        ApplicationDbContext db)
    {
        _http = httpFactory.CreateClient("tmdb");
        _apiKey = config["TMDb:ApiKey"]!;
        _db = db;
    }

    public async Task ImportPopularAsync(int totalMovies = 100)
    {
        var imported = new List<Movie>();
        int perPage = 20;
        int pages = (int)Math.Ceiling(totalMovies / (double)perPage);

        for (int page = 1; page <= pages; page++)
        {
            var resp = await _http.GetFromJsonAsync<TMDbPage>(
                $"movie/popular?api_key={_apiKey}&page={page}");

            foreach (var item in resp!.Results)
            {
                if (_db.Movies.Any(m =>
                        m.Title == item.Title &&
                        m.ReleaseDate == DateTime.Parse(item.ReleaseDate)))
                    continue;

                var movie = new Movie
                {
                    Title = item.Title,
                    ReleaseDate = DateTime.Parse(item.ReleaseDate),
                    Description = item.Overview,
                };
                _db.Movies.Add(movie);
                imported.Add(movie);

                if (imported.Count >= totalMovies)
                    break;
            }

            if (imported.Count >= totalMovies)
                break;
        }

        await _db.SaveChangesAsync();
    }

    private class TMDbPage
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("results")]
        public List<TMDbMovie> Results { get; set; } = new();
    }

    private class TMDbMovie
    {
        [JsonPropertyName("title")]
        public string Title { get; set; } = "";

        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; } = "";

        [JsonPropertyName("overview")]
        public string Overview { get; set; } = "";

        [JsonPropertyName("poster_path")]
        public string? PosterPath { get; set; }
    }
}
