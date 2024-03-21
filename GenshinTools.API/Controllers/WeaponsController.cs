using GenshinTools.Application.Services.Interfaces;
using GenshinTools.Domain.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GenshinTools.API.Controllers; 

[Route("api/[controller]")]
[ApiController]
public class WeaponsController : ControllerBase {

    private readonly IWeaponService _weaponService;

    public WeaponsController(IWeaponService weaponService)
    {
        _weaponService = weaponService;
    }

    // GET: api/<WeaponsController>
    [HttpGet]
    public async Task<ActionResult<List<Weapon>>> GetAllAsync() {
        var result = await _weaponService.GetAllAsync();
        return Ok(result);
    }

    // GET api/<WeaponsController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Weapon>> GetByIdAsync(int id) {
        var result = await _weaponService.GetByIdAsync(id);
        return Ok(result);
    }
}
