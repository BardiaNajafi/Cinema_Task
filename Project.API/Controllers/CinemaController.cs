using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Application.Data;
using Project.Application.Services;
using Project.Domain.Models;

namespace Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private readonly ICinemaService _cinemaService;

        public CinemaController(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }
        [HttpGet("rooms")]
        public async Task<IActionResult> GetRooms()
        {
            var rooms = await _cinemaService.GetRoomsAsync();
            return Ok(rooms);
        }

        [HttpGet("moviesByRoomId/{roomId}")]
        public async Task<IActionResult> GetMoviesByRoomId(int roomId)
        {
            var movies = await _cinemaService.GetMoviesByRoomIdAsync(roomId);
            return Ok(movies);
        }

        [HttpGet("seats/{showId}")]
        public async Task<IActionResult> GetAllSeats(int showId)
        {
            var data = await _cinemaService.GetAllSeatsAsync(showId);
            return Ok(data);
        }

       
        

        [HttpPost("book-seat")]
        public async Task<IActionResult> BookSeat(int seatId, int showtimeId, int userId)
        {
            var msg = await _cinemaService.BookSeatAsync(seatId,showtimeId, userId);

            return Ok(msg);
        }

    }
}
