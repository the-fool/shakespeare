using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShakespeareAPI.Models;
using ShakespeareAPI.Services;
using ShakespeareAPI.Tools;

namespace ShakespeareAPI.Controllers {
  [Route ("api/[controller]")]
  [ApiController]
  public class WorksController : ControllerBase {
    private readonly IWorkService workService;

    public WorksController (IWorkService svc) {
      workService = svc;
    }

    [HttpGet]
    [ProducesResponseType (200)]
    public ActionResult<List<Work>> GetAll (Genre? genre) {
      var baseQuery = workService.GetAll ().AsNoTracking ();

      if (genre != null) {
        baseQuery = baseQuery.Where (w => w.Genre == genre);
      }

      return baseQuery.Include (w => w.Scenes).ToList ();
    }

    [HttpGet ("{id}")]
    [ProducesResponseType (200)]
    [ProducesResponseType (404)]
    public ActionResult<Work> GetById (int id) {
      if (!workService.GetById (id, out var work)) {
        return NotFound ();
      }

      return work;
    }
  }
}