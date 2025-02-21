using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Dtos;
using Project.Application.Services;
using Project.Domain.Models;

namespace Project.API.Controllers;


[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class RoomController : ControllerBase
{
    private readonly IRoomService _roomService;

    public RoomController(IRoomService roomService)
    {
        _roomService = roomService;
    }

    [HttpPost("Create")]
    public async Task<ActionResult<Room>> CreateRoom(CreateRoomDto room)
    {
        var createdRoom = await _roomService.CreateRoomAsync(room);
        return CreatedAtAction(nameof(GetRoomById), new { id = createdRoom.Id }, createdRoom);
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<List<Room>>> GetAllRooms()
    {
        var rooms = await _roomService.GetAllRoomsAsync();
        return Ok(rooms);
    }

    [HttpGet("GetRoom/{id}")]
    public async Task<ActionResult<Room>> GetRoomById(int id)
    {
        var room = await _roomService.GetRoomByIdAsync(id);
        if (room == null)
        {
            return NotFound();
        }
        return Ok(room);
    }

    [HttpPut("Update/{id}")]
    public async Task<ActionResult<Room>> UpdateRoom(int id, Room updatedRoom)
    {
        var room = await _roomService.UpdateRoomAsync(id, updatedRoom);
        if (room == null)
        {
            return NotFound();
        }
        return Ok(room);
    }

    [HttpDelete("Delete/{id}")]
    public async Task<ActionResult<bool>> DeleteRoom(int id)
    {
        var result = await _roomService.DeleteRoomAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return Ok(result);
    }
}
