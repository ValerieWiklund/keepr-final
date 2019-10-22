using keepr_final.Interfaces;

namespace keepr_final.Models
{
  public class Vault : IVault
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string UserId { get; set; }
  }
}