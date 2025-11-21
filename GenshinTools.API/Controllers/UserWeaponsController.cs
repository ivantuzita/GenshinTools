using GenshinTools.Application.DTOs;
using GenshinTools.Application.Services.Interfaces;
using GenshinTools.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace GenshinTools.API.Controllers; 
[Route("api/[controller]")]
[ApiController]
public class UserWeaponsController : ControllerBase {

    private readonly IUserWeaponService _userWeaponService;

    public UserWeaponsController(IUserWeaponService userWeaponService) {
        _userWeaponService = userWeaponService;
    }

    // POST: api/<UserWeaponsController>/link/
    [HttpPost("link/")]
    public async Task<ActionResult> AssociateWeaponToUser([FromBody] UserWeaponDTO model) {
        await _userWeaponService.AssociateWeaponToUser(model);
        return Ok();
    }

    // POST: api/<UserWeaponsController>/unlink/
    [HttpPost("unlink/")]
    public async Task<ActionResult> DisassociateWeaponToUser([FromBody] UserWeaponDTO model) {
        await _userWeaponService.DisassociateWeaponToUser(model);
        return Ok();
    }

    // GET api/<UserWeaponsController>/2
    [HttpGet("get-user-weapons")]
    public async Task<ActionResult<List<Weapon>>> GetUserWeapons(string userId) {
        var chars = await _userWeaponService.GetUserWeapons(userId);
        return Ok(chars);
    }

    // GET api/<UserWeaponsController>/filter/2
    [HttpGet("get-filtered-user-weapons")]
    public async Task<ActionResult<List<Weapon>>> GetUserWeaponsFiltered(string userId) {
        var chars = await _userWeaponService.GetUserWeaponsFiltered(userId);
        return Ok(chars);
    }
}
