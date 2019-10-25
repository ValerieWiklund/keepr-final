using System;
using System.Collections.Generic;
using System.Security.Claims;
using keepr_final.Models;
using keepr_final.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr_final.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]

  public class KeepsController : ControllerBase
  {
    private readonly KeepsService _ks;
    public KeepsController(KeepsService ks)
    {
      _ks = ks;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {
      try
      {
        return Ok(_ks.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Keep> Get(int id)
    {
      try
      {
        return Ok(_ks.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpGet("user")]
    public ActionResult<IEnumerable<Keep>> GetByUser()
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_ks.GetByUser(userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpPost]
    public ActionResult<Keep> Create([FromBody] Keep newKeep)
    {
      try
      {
        newKeep.UserId = HttpContext.User.FindFirstValue("Id");
        return Ok(_ks.Create(newKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}/view")]

    public ActionResult<Keep> EditViewCount([FromBody] Keep editKeep, int id)
    {
      try
      {
        editKeep.Id = id;
        return Ok(_ks.EditViewCount(editKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpPut("{id}")]

    public ActionResult<Keep> Edit([FromBody] Keep editKeep, int id)
    {
      try
      {
        //   id = editKeep.Id;
        return Ok(_ks.Edit(editKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpDelete("{id}")]

    public ActionResult<Keep> Delete(int id)
    {
      try
      {
        return Ok(_ks.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


  }
}