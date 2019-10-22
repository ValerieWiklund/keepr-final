using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr_final.Models;

namespace keepr_final.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Keep> GetKeeps(int vaultId)
    {
      string sql = @"SELECT * FROM vaultkeeps vk
                INNER JOIN keeps k ON k.id = vk.keepId 
                WHERE (vaultId = @vaultId AND vk.userId = @userId)";
      return _db.Query<Keep>(sql, new { vaultId });
    }
  }
}