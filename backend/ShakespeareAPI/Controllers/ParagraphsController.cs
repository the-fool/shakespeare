using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShakespeareAPI.Models;
using ShakespeareAPI.Services;

namespace ShakespeareAPI.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class ParagraphsController : ControllerBase {
    private readonly IParagraphService paragraphService;

    public ParagraphsController(IParagraphService svc) {
      paragraphService = svc;
    }

    [HttpGet]
    [ProducesResponseType(200)]
    public ActionResult<PaginatedList<Paragraph>> GetAll(string search, int? work, int? pageIndex) {
      var paragraphs = paragraphService.GetAll();

      Console.WriteLine(work);
      if (work != null) {
        paragraphs = paragraphs.Where(p => p.Scene.WorkId == work);
      }
      if (!String.IsNullOrEmpty(search)) {
        paragraphs = paragraphs.Where(p => EF.Functions.ILike(p.Text, $"%{search}%"));
      }
      int pageSize = 10;
      return PaginatedList<Paragraph>.Create(paragraphs.AsNoTracking(), pageIndex ?? 1, pageSize);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public ActionResult<Paragraph> GetById(int id) {
      if (!paragraphService.TryGetById(id, out var paragraph)) {
        return NotFound();
      }

      return paragraph;
    }
  }
}