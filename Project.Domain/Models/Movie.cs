using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.Domain.Models;

public class Room
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<ShowTime>? ShowTimes { get; set; } = new();
    
    public List<Seat>? Seats { get; set; }
}


public class Movie
{
    public int Id { get; set; } 
    public string Title { get; set; } = string.Empty;
    public string PosterUrl { get; set; } = string.Empty;
    public List<ShowTime>? ShowTimes { get; set; } = new();
}
public class ShowTime
{
    public int Id { get; set; } 
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
    public int RoomId { get; set; }
    public Room Room { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    //public List<Seat> AvailableSeats { get; set; } = new();
}

public class Seat
{
    public int Id { get; set; } 
    public int Row { get; set; }
    public int Number { get; set; }
    public bool IsBooked { get; set; } = false;
    public int RoomId { get; set; }
    public Room Room { get; set; }
}

public class Booking
{
    public int Id { get; set; } 
    public int UserId { get; set; } 
    public int ShowTimeId { get; set; }
    public ShowTime ShowTime { get; set; }
    public int SeatId { get; set; }
    public Seat Seat { get; set; }
    public DateTime BookedAt { get; set; } = DateTime.UtcNow;
}
