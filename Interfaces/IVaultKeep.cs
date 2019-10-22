namespace keepr_final.Interfaces
{
  public interface IVaultKeep
  {
    int Id { get; set; }
    int VaultId { get; set; }
    int KeepId { get; set; }
    string UserId { get; set; }
  }
}