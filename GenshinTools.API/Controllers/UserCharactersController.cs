using GenshinTools.Application.DTOs;
using GenshinTools.Application.Services.Interfaces;
using GenshinTools.Domain.Models;
using Microsoft.AspNetCore.Mvc;
namespace GenshinTools.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserCharactersController : ControllerBase {

    private readonly IUserCharacterService _userCharacterService;

    public UserCharactersController(IUserCharacterService userCharacterService) {
        _userCharacterService = userCharacterService;
    }

    // POST: api/<UserCharactersController>/link/
    [HttpPost("link")]
    public async Task<ActionResult> AssociateCharacterToUser([FromBody] UserCharacterDTO model) {
        await _userCharacterService.AssociateCharacterToUser(model);
        return Ok();
    }

    // POST: api/<UserCharactersController>/unlink
    [HttpPost("unlink")]
    public async Task<ActionResult> DisassociateCharacterToUser([FromBody] UserCharacterDTO model) {
        await _userCharacterService.DisassociateCharacterToUser(model);
        return Ok();
    }

    // GET api/<UserCharactersController>/2
    [HttpGet("c/{userId}")]
    public async Task<ActionResult<List<Character>>> GetUserCharacters([FromRoute] string userId) {
        var chars = await _userCharacterService.GetUserCharacters(userId);
        return Ok(chars);
    }

    // GET api/<UserCharactersController>/filter/2
    [HttpGet("c/filter/{userId}")]
    public async Task<ActionResult<List<Character>>> GetUserCharactersFiltered([FromRoute] string userId) {
        var chars = await _userCharacterService.GetUserCharactersFiltered(userId);
        return Ok(chars);
    }
}
