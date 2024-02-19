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

    // POST: api/<UserWeaponsController>/link/1/2
    [HttpPost("link/{userId}/{weaponId}")]
    public async Task<ActionResult> AssociateWeaponToUser([FromRoute] int userId, [FromRoute] int weaponId) {
        await _userWeaponService.AssociateWeaponToUser(userId, weaponId);
        return Ok();
    }

    // POST: api/<UserWeaponsController>/unlink/1/2
    [HttpPost("unlink/{userId}/{weaponId}")]
    public async Task<ActionResult> DisassociateWeaponToUser([FromRoute] int userId, [FromRoute] int weaponId) {
        await _userWeaponService.DisassociateWeaponToUser(userId, weaponId);
        return Ok();
    }

    // GET api/<UserWeaponsController>/2
    [HttpGet("{userId}")]
    public async Task<ActionResult<List<Weapon>>> GetUserWeapons([FromRoute] int userId) {
        await _userWeaponService.GetUserWeapons(userId);
        return Ok();
    }

    // GET api/<UserWeaponsController>/filter/2
    [HttpGet("filter/{userId}")]
    public async Task<ActionResult<List<Weapon>>> GetUserWeaponsFiltered([FromRoute] int userId) {
        await _userWeaponService.GetUserWeaponsFiltered(userId);
        return Ok();
    }
}
