using System;
using System.Collections.Generic;
using keepr_final.Models;
using keepr_final.Repositories;

namespace keepr_final.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;
    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Vault> Get(string userId)
    {

      return _repo.Get(userId);
    }

    public Vault Get(int id)
    {
      Vault exists = _repo.Get(id);
      if (exists == null) { throw new Exception("Invalid Id"); }
      return exists;
    }

    // public IEnumerable<Vault> GetByUser(string userId)
    // {
    //   return _repo.GetByUser(userId);
    // }

    public Vault Create(Vault newVault)
    {
      int id = _repo.Create(newVault);
      newVault.Id = id;
      return newVault;
    }

    public Vault Edit(Vault editVault)
    {
      Vault Vault = _repo.Get(editVault.Id);
      if (Vault == null) { throw new Exception("Invalid Id"); }
      Vault.Name = editVault.Name;
      Vault.Description = editVault.Description;
      _repo.Edit(Vault);
      return Vault;
    }

    public string Delete(int id)
    {
      Vault exists = _repo.Get(id);
      if (exists == null) { throw new Exception("Invalid Id"); }
      _repo.Delete(id);
      return "Successfully Deleted";
    }


  }
}