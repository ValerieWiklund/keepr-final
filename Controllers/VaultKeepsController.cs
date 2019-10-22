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
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _vks;
    public VaultKeepsController(VaultKeepsService vks)
    {
      _vks = vks;
    }

    [HttpGet("{vaultId}")]

    public ActionResult<IEnumerable<Keep>> GetKeeps(int vaultId)
    {
      try
      {
        var userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_vks.GetKeeps(vaultId, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<VaultKeep> Create([FromBody] VaultKeep newVaultKeep)
    {
      try
      {
        newVaultKeep.UserId = HttpContext.User.FindFirstValue("Id");
        return Ok(_vks.Create(newVaultKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


  }
}