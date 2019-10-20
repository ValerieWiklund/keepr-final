using keepr_final.Interfaces;

namespace keepr_final.Models
{
  public class Keep : IKeep
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Img { get; set; }
    public bool IsPrivate { get; set; }
    public string UserId { get; set; }
  }
}