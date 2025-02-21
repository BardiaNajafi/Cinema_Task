using Project.Application.Dtos;
using Project.Domain.Models;

namespace Project.Application.Services;

public interface ICinemaService
{
    Task<List<Room>> GetRoomsAsync();
    Task<List<ShowTimeDto>> GetMoviesByRoomIdAsync(int roomId);
    Task<List<RoomSeatsDto>> GetAllSeatsAsync(int showtimeId);
    Task<string> BookSeatAsync(int seatId, int showtimeId, int userId);
}
