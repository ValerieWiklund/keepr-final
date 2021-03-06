using System;
using System.Collections.Generic;
using keepr_final.Models;
using keepr_final.Repositories;

namespace keepr_final.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;
    private readonly KeepsRepository _keeprepo;
    private readonly VaultsRepository _vaultrepo;
    public VaultKeepsService(VaultKeepsRepository repository, KeepsRepository keeprepo, VaultsRepository vaultrepo)
    {
      _keeprepo = keeprepo;
      _vaultrepo = vaultrepo;
      _repo = repository;
    }


    public IEnumerable<Keep> GetKeeps(int vaultId, string userId)
    {
      Vault vault = _vaultrepo.Get(vaultId);
      if (vault == null || vault.UserId != userId) { throw new Exception("Invalid Request"); }
      return _repo.GetKeeps(vaultId, userId);
    }


    internal VaultKeep Create(VaultKeep newVaultKeep)
    {
      int id = _repo.Create(newVaultKeep);
      newVaultKeep.Id = id;
      return newVaultKeep;
    }

    public string RemoveVaultKeep(VaultKeep vaultKeep, string userId)
    {
      VaultKeep vk = _repo.GetVaultKeep(vaultKeep);
      int id = vk.Id;
      if (vk == null || vk.UserId != userId) { throw new Exception("Invalid Information"); }
      _repo.RemoveVaultKeep(id);
      return "successfully Deleted";
    }
  }
}