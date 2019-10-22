using keepr_final.Interfaces;

namespace keepr_final.Models
{
  public class VaultKeep : IVaultKeep
  {
    public int Id { get; set; }
    public int VaultId { get; set; }
    public int KeepId { get; set; }
    public string UserId { get; set; }
  }
}