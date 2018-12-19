using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ShakespeareAPI.Services;
using ShakespeareAPI.Models;

namespace ShakespeareAPI.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class WorksController : ControllerBase {
        private readonly IWorkService workService;

        public WorksController (IWorkService svc) {
            workService = svc;
        }

        [HttpGet]
        public ActionResult<List<Work>> GetAll () {
            return workService.GetAll().ToList();
        }

        [HttpGet ("{id}")]
        [ProducesResponseType (200)]
        [ProducesResponseType (404)]
        public ActionResult<Work> GetById(int id) {
            if (!workService.GetById(id, out var work)) {
                return NotFound ();
            }

            return work;
        }
    }

}