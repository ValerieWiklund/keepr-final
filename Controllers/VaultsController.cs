using System;
using System.Collections.Generic;
using System.Security.Claims;
using keepr_final.Models;
using keepr_final.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr_final.Controllers
{
  [Authorize]
  [ApiController]
  [Route("/api/[controller]")]
  public class VaultsController : ControllerBase
  {
    private readonly VaultsService _vs;
    public VaultsController(VaultsService vs)
    {
      _vs = vs;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Vault>> Get()
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_vs.Get(userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Vault> Get(int id)
    {
      try
      {
        return Ok(_vs.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // [Authorize]
    // [HttpGet("user")]
    // public ActionResult<IEnumerable<Vault>> GetByUser()
    // {
    //   try
    //   {
    //     string userId = HttpContext.User.FindFirstValue("Id");
    //     return Ok(_vs.GetByUser(userId));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }

    // [Authorize]
    [HttpPost]
    public ActionResult<Vault> Create([FromBody] Vault newVault)
    {
      try
      {
        newVault.UserId = HttpContext.User.FindFirstValue("Id");
        return Ok(_vs.Create(newVault));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // [Authorize]
    [HttpPut("{id}")]

    public ActionResult<Vault> Edit([FromBody] Vault editVault, int id)
    {
      try
      {
        editVault.Id = id;
        return Ok(_vs.Edit(editVault));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // [Authorize]
    [HttpDelete("{id}")]

    public ActionResult<Vault> Delete(int id)
    {
      try
      {
        return Ok(_vs.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}

