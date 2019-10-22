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


    public IEnumerable<Keep> GetKeeps(int vaultId)
    {
      Vault vault = _vaultrepo.Get(vaultId);
      if (vault == null) { throw new Exception("Invalid Vault Id"); }
      return _repo.GetKeeps(vaultId);
    }

    public VaultKeep Create(VaultKeep newVaultKeep)
    {
      //add the keepid, userid and the vaultid to a vaultkeepid
      return newVaultKeep;
    }
  }
}