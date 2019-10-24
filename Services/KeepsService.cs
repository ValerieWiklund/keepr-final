using System;
using System.Collections.Generic;
using keepr_final.Models;
using keepr_final.Repositories;

namespace keepr_final.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;
    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Keep> Get()
    {

      return _repo.Get();
    }

    public Keep Get(int id)
    {
      Keep exists = _repo.Get(id);
      if (exists == null) { throw new Exception("Invalid Id"); }
      return exists;
    }

    public IEnumerable<Keep> GetByUser(string userId)
    {
      return _repo.GetByUser(userId);
    }

    public Keep Create(Keep newKeep)
    {
      int id = _repo.Create(newKeep);
      newKeep.Id = id;
      return newKeep;
    }

    public Keep Edit(Keep editKeep)
    {
      Keep keep = _repo.Get(editKeep.Id);
      if (keep == null) { throw new Exception("Invalid Id"); }
      keep.Name = editKeep.Name;
      keep.Description = editKeep.Description;
      keep.Img = editKeep.Img;
      keep.IsPrivate = editKeep.IsPrivate;
      keep.Views = editKeep.Views;
      keep.Keeps = editKeep.Keeps;
      keep.Shares = editKeep.Shares;
      _repo.Edit(keep);
      return keep;
    }

    public string Delete(int id)
    {
      Keep exists = _repo.Get(id);
      if (exists == null) { throw new Exception("Invalid Id"); }
      if (exists.IsPrivate == false) { throw new Exception("You cannot delete a public keep"); }
      _repo.Delete(id);
      return "Successfully Deleted";
    }


  }
}