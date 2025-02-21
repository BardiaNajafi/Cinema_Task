using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Dtos;
using Project.Application.Services;
using Project.Domain.Models;

namespace Project.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class MovieController : ControllerBase
{
    private readonly IMovieService _movieService;

    public MovieController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpPost("Create")]
    public async Task<ActionResult<Movie>> CreateMovie(CreateMovieDto movieDto)
    {
        var createdMovie = await _movieService.CreateMovieAsync(movieDto);
        return CreatedAtAction(nameof(GetMovieById), new { id = createdMovie.Id }, createdMovie);
    }

    [HttpGet]
    public async Task<ActionResult<List<Movie>>> GetAllMovies()
    {
        var movies = await _movieService.GetAllMoviesAsync();
        return Ok(movies);
    }

         [HttpGet("Get/{id}")]
    public async Task<ActionResult<Movie>> GetMovieById(int id)
    {
        var movie = await _movieService.GetMovieByIdAsync(id);
        if (movie == null)
        {
            return NotFound();          }
        return Ok(movie);
    }

         [HttpPut("Update/{id}")]
    public async Task<ActionResult<Movie>> UpdateMovie(int id, Movie updatedMovie)
    {
        var movie = await _movieService.UpdateMovieAsync(id, updatedMovie);
        if (movie == null)
        {
            return NotFound();          }
        return Ok(movie);
    }

         [HttpDelete("Delete/{id}")]
    public async Task<ActionResult<bool>> DeleteMovie(int id)
    {
        var result = await _movieService.DeleteMovieAsync(id);
        if (!result)
        {
            return NotFound();          }
        return Ok(result);
    }
}
