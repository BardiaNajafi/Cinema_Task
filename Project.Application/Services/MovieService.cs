using Microsoft.EntityFrameworkCore;
using Project.Application.Data;
using Project.Application.Dtos;
using Project.Domain.Models;

namespace Project.Application.Services;


public class MovieService : IMovieService
{
    private readonly IApplicationDbContext _context;

    public MovieService(IApplicationDbContext context)
    {
        _context = context;
    }

    // Create
    public async Task<Movie> CreateMovieAsync(CreateMovieDto movieDto)
    {
        var movie = new Movie() { PosterUrl = movieDto.PosterUrl, Title = movieDto.Title };
        _context.Movies.Add(movie);
        await _context.SaveChangesAsync(CancellationToken.None);
        return movie;
    }

    // Read (Get All Movies)
    public async Task<List<Movie>> GetAllMoviesAsync()
    {
        return await _context.Movies.ToListAsync();
    }

    // Read (Get Movie by Id)
    public async Task<Movie> GetMovieByIdAsync(int id)
    {
        return await _context.Movies.FindAsync(id);
    }

    // Update
    public async Task<Movie> UpdateMovieAsync(int id, Movie updatedMovie)
    {
        var movie = await _context.Movies.FindAsync(id);
        if (movie == null)
        {
            return null; 
        }

        movie.Title = updatedMovie.Title;
        movie.PosterUrl = updatedMovie.PosterUrl;
        _context.Movies.Update(movie);
        await _context.SaveChangesAsync(CancellationToken.None);
        return movie;
    }

    // Delete
    public async Task<bool> DeleteMovieAsync(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        if (movie == null)
        {
            return false; 
        }

        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync(CancellationToken.None);
        return true;
    }
}