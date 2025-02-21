using Project.Application.Dtos;
using Project.Domain.Models;

namespace Project.Application.Services;

public interface IRoomService
{
    Task<Room> CreateRoomAsync(CreateRoomDto room);
    Task<List<Room>> GetAllRoomsAsync();
    Task<Room> GetRoomByIdAsync(int id);
    Task<Room> UpdateRoomAsync(int id, Room updatedRoom);
    Task<bool> DeleteRoomAsync(int id);
}