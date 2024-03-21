using GenshinTools.Application.Services.Interfaces;
using GenshinTools.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GenshinTools.API.Controllers; 

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CharactersController : ControllerBase {

    private readonly ICharacterService _characterService;

    public CharactersController(ICharacterService characterService)
    {
        _characterService = characterService;
    }

    // GET: api/<CharactersController>
    [HttpGet]
    public async Task<ActionResult<List<Character>>> GetAllAsync() {
        var result = await _characterService.GetAllAsync();
        return Ok(result);
    }

    // GET api/<CharactersController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Character>> GetByIdAsync(int id) {
        var result = await _characterService.GetByIdAsync(id);
        return Ok(result);
    }
}
