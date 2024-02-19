﻿using GenshinTools.Application.Services.Interfaces;
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

    // POST: api/<UserCharactersController>/link/1/2
    [HttpPost("link/{userId}/{charId}")]
    public async Task<ActionResult> AssociateCharacterToUser([FromRoute] int userId, [FromRoute] int charId) {
        await _userCharacterService.AssociateCharacterToUser(userId, charId);
        return Ok();
    }

    // POST: api/<UserCharactersController>/unlink/1/2
    [HttpPost("unlink/{userId}/{charId}")]
    public async Task<ActionResult> DisassociateCharacterToUser([FromRoute] int userId, [FromRoute] int charId) {
        await _userCharacterService.DisassociateCharacterToUser(userId, charId);
        return Ok();
    }

    // GET api/<UserCharactersController>/2
    [HttpGet("{userId}")]
    public async Task<ActionResult<List<Character>>> GetUserCharacters([FromRoute] int userId) {
        await _userCharacterService.GetUserCharacters(userId);
        return Ok();
    }

    // GET api/<UserCharactersController>/filter/2
    [HttpGet("filter/{userId}")]
    public async Task<ActionResult<List<Character>>> GetUserCharactersFiltered([FromRoute] int userId) {
        await _userCharacterService.GetUserCharactersFiltered(userId);
        return Ok();
    }
}
