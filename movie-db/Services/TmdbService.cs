﻿using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using movie_db.Models.DTO;
using Newtonsoft.Json;

namespace movie_db.Services
{
    public class TmdbService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public TmdbService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["TmdbApiSettings:ApiKey"];
        }

        public async Task<MovieDTO> GetMovieByIdAsync(int id)
        {
            var requestUrl = $"https://api.themoviedb.org/3/movie/{id}?api_key={_apiKey}";
            var response = await _httpClient.GetStringAsync(requestUrl);
            var movie = JsonConvert.DeserializeObject<MovieDTO>(response);
            return movie;
        }

        public async Task<MovieResultsDTO> GetPopularMovies(int page)
        {
            var requestUrl = $"https://api.themoviedb.org/3/movie/popular?api_key={_apiKey}&page={page}";
            var response = await _httpClient.GetStringAsync(requestUrl);
            var movies = JsonConvert.DeserializeObject<MovieResultsDTO>(response);
            return movies;
        }

        public async Task<MovieResultsDTO> SearchMovie(String keyword, int page)
        {
            // Make sure to URL encode the keyword to handle special characters
            var encodedKeyword = Uri.EscapeDataString(keyword);

            // Corrected API endpoint for searching movies by title
            var requestUrl = $"https://api.themoviedb.org/3/search/movie?query={encodedKeyword}&api_key={_apiKey}&page={page}";

            var response = await _httpClient.GetStringAsync(requestUrl);
            var movies = JsonConvert.DeserializeObject<MovieResultsDTO>(response);
            return movies;
        }
    }
}
