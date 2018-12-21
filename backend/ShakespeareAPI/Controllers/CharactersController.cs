using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ShakespeareAPI.Models;
using ShakespeareAPI.Services;

namespace ShakespeareAPI.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class CharactersController : ControllerBase {
    private readonly ICharacterService characterService;

    public CharactersController(ICharacterService svc) {
      characterService = svc;
    }

    [HttpGet]
    [ProducesResponseType(200)]
    public ActionResult<List<Character>> GetAll(int? work) {
      var characters = characterService.GetAll();

      if (work != null) {
        var workId = work.Value;
        characters = characters
          .Where(c => c.Paragraphs
            .Where(p => p.Scene.WorkId == work)
            .Count() > 0);
      }

      return characters.ToList();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public ActionResult<Character> GetById(int id) {
      if (!characterService.TryGetById(id, out var character)) {
        return NotFound();
      }

      return character;
    }
  }
}