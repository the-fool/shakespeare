using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ShakespeareAPI.Models;

namespace ShakespeareAPI.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class PlayController : ControllerBase {
        private readonly IPlayRepository repository;

        public PlayController (IPlayRepository repo) {
            repository = repo;
        }

        [HttpGet]
        public ActionResult<List<Play>> GetAll () {
            return repository.GetAll().ToList();
        }

        [HttpGet ("{id}")]
        [ProducesResponseType (200)]
        [ProducesResponseType (404)]
        public ActionResult<Play> GetById(int id) {
            if (!repository.TryGetPlay(id, out var play)) {
                return NotFound ();
            }

            return play;
        }
    }

}