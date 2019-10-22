namespace keepr_final.Interfaces
{
  public interface IKeep
  {
    int Id { get; set; }
    string Name { get; set; }
    string Description { get; set; }
    string Img { get; set; }
    bool IsPrivate { get; set; }
    int Views { get; set; }
    int Shares { get; set; }
    int Keeps { get; set; }
    string UserId { get; set; }
  }
}