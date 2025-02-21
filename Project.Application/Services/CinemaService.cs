using Microsoft.EntityFrameworkCore;
using Project.Application.Data;
using Project.Application.Dtos;
using Project.Domain.Models;


namespace Project.Application.Services
{
    public class CinemaService : ICinemaService
    {
        private readonly IApplicationDbContext _context;

        public CinemaService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Room>> GetRoomsAsync()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<List<ShowTimeDto>> GetMoviesByRoomIdAsync(int roomId)
        {
            var movies = await _context.ShowTimes
                .Where(s => s.RoomId == roomId)
                .Select(s => new ShowTimeDto()
                {
                    ShowId = s.Id,
                    MovieName = s.Movie.Title,
                    StartTime = s.StartTime,
                    EndTime = s.EndTime
                })
                .ToListAsync();

            return movies;

        }

        public async Task<List<RoomSeatsDto>> GetAllSeatsAsync(int showtimeId)
        {
            var data = await _context.ShowTimes
                .Include(s => s.Room)
                .ThenInclude(r => r.Seats)
                .Where(s => s.Id == showtimeId)
                .Select(s => new RoomSeatsDto
                {
                    RoomName = s.Room.Name,
                    Seats = s.Room.Seats.Select(r => new SeatDto
                    {
                        Number = r.Number,
                        Row = r.Row,
                        IsBooked = r.IsBooked
                    }).ToList()
                })
                .ToListAsync();
            return data;

        }

        public async Task<string> BookSeatAsync(int seatId, int showtimeId, int userId)
        {
            var seat = await _context.Seats.FirstOrDefaultAsync(s => s.Id == seatId);
            if (seat == null || seat.IsBooked)
                return "Seat is not available";

            // Mark as booked
            seat.IsBooked = true;

            // Create a booking record
            var booking = new Booking
            {
                UserId = userId,
                ShowTimeId = showtimeId,
                SeatId = seatId,
                BookedAt = DateTime.UtcNow
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync(CancellationToken.None);

            return "Seat booked successfully";
        }
    }
}