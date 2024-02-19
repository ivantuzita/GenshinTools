using GenshinTools.Application.DTOs;
using GenshinTools.Application.Services.Interfaces;
using GenshinTools.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace GenshinTools.API.Controllers; 
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase {

    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    // GET: api/<UsersController>
    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAllAsync() {
        await _userService.GetAllAsync();
        return Ok();
    }

    // GET api/<UsersController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<UserDTO>> GetByIdAsync(int id) {
        await _userService.GetByIdAsync(id);
        return Ok();
    }

    // POST api/<UsersController>
    [HttpPost]
    public async Task<ActionResult> CreateAsync([FromBody] UserDTO userDTO) {
        await _userService.CreateAsync(userDTO);
        return Ok();
    }

    // PUT api/<UsersController>/5
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAsync([FromBody] UserDTO userDTO) {
        await _userService.UpdateAsync(userDTO);
        return Ok();
    }

    // DELETE api/<UsersController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync([FromRoute] int id) {
        await _userService.DeleteByIdAsync(id);
        return Ok();
    }
}
