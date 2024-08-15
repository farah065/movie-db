using Microsoft.AspNetCore.Mvc;
using movie_db.Models.DTO;
using movie_db.Services;
using System.Threading.Tasks;

namespace movie_db.Controllers
{
    [Route("api/MovieDB")]
    [ApiController]
    public class MovieDBController : ControllerBase
    {
        private readonly TmdbService _tmdbService;
        private readonly IMovieService _movieService;

        public MovieDBController(TmdbService tmdbService, IMovieService movieService)
        {
            _tmdbService = tmdbService;
            _movieService = movieService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAndSaveMovie(int id)
        {
            // Check if the movie already exists in the database
            var existingMovie = await _movieService.GetMovieByIdAsync(id);
            if (existingMovie != null)
            {
                return Ok(existingMovie);
            }

            // Fetch movie details from TMDB API
            var movieDto = await _tmdbService.GetMovieByIdAsync(id);
            if (movieDto == null)
            {
                return NotFound();
            }

            // Save the movie details to the database
            await _movieService.AddMovieAsync(movieDto);

            // Return the movie details
            return Ok(movieDto);
        }

        [HttpGet("popular")]
        public async Task<IActionResult> GetPopularMovies(int page)
        {
            // Fetch popular movies from TMDB API
            var popularMoviesDto = await _tmdbService.GetPopularMovies(page);
            if (popularMoviesDto == null)
            {
                return NotFound();
            }

            // Return the movies
            return Ok(popularMoviesDto);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchMovie(String keyword, int page)
        {
            // Fetch popular movies from TMDB API
            var popularMoviesDto = await _tmdbService.SearchMovie(keyword, page);
            if (popularMoviesDto == null)
            {
                return NotFound();
            }

            // Return the movies
            return Ok(popularMoviesDto);
        }
    }
}
