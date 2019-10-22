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

    public IEnumerable<Keep> GetKeeps(int vaultId, string userId)
    {
      string sql = @"SELECT * FROM vaultkeeps vk
                INNER JOIN keeps k ON k.id = vk.keepId 
                WHERE (vaultId = @vaultId AND vk.userId = @userId)";
      return _db.Query<Keep>(sql, new { vaultId });
    }

    internal int Create(VaultKeep newVaultKeep)
    {
      string sql = @"INSERT INTO vaultkeeps
                (vaultId, keepId, userId)
                VALUES
                (@VaultId, @KeepId, @UserId);
                SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newVaultKeep);
    }
  }
}