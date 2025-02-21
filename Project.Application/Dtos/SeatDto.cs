namespace Project.Application.Dtos;

public class SeatDto
{
    public int Row { get; set; }
    public int Number { get; set; }
    public bool IsBooked { get; set; }
}
public class RoomSeatsDto
{
    public string RoomName { get; set; }
    public List<SeatDto> Seats { get; set; }
}

public class ShowTimeDto
{
    public int ShowId { get; set; }
    public string MovieName { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}