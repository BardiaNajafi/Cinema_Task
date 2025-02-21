using Project.Application.Dtos;
using Project.Domain.Models;

namespace Project.Application.Services;

public interface IMovieService
{
    Task<Movie> CreateMovieAsync(CreateMovieDto movie);
    Task<List<Movie>> GetAllMoviesAsync();
    Task<Movie> GetMovieByIdAsync(int id);
    Task<Movie> UpdateMovieAsync(int id, Movie updatedMovie);
    Task<bool> DeleteMovieAsync(int id);
}