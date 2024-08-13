using movie_db.Models.DTO;
using System.Threading.Tasks;

namespace movie_db.Services
{
    public interface IMovieService
    {
        Task<MovieDTO> GetMovieByIdAsync(int id);
        Task AddMovieAsync(MovieDTO movieDto);
    }
}
