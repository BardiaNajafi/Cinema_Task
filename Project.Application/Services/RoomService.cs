using Project.Application.Dtos;

namespace Project.Application.Services;

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Application.Data;
using Project.Domain.Models;


public class RoomService : IRoomService
{
    private readonly IApplicationDbContext _context;

    public RoomService(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Room> CreateRoomAsync(CreateRoomDto roomDto)
    {
        var room = new Room()
        {
            Name = roomDto.Name
        };
        _context.Rooms.Add(room);
        await _context.SaveChangesAsync(CancellationToken.None);
        return room;
    }

    public async Task<List<Room>> GetAllRoomsAsync()
    {
        return await _context.Rooms.ToListAsync();
    }

    public async Task<Room> GetRoomByIdAsync(int id)
    {
        return await _context.Rooms.FindAsync(id);
    }

    public async Task<Room> UpdateRoomAsync(int id, Room updatedRoom)
    {
        var room = await _context.Rooms.FindAsync(id);
        if (room == null)
        {
            return null;
        }

        room.Name = updatedRoom.Name;
        _context.Rooms.Update(room);
        await _context.SaveChangesAsync(CancellationToken.None);
        return room;
    }

    public async Task<bool> DeleteRoomAsync(int id)
    {
        var room = await _context.Rooms.FindAsync(id);
        if (room == null)
        {
            return false;
        }

        _context.Rooms.Remove(room);
        await _context.SaveChangesAsync(CancellationToken.None);
        return true;
    }
}