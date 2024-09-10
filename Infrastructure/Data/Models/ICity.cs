namespace Infrastructure.Data.Models
{
    public interface ICity
    {
        short Id { get; set; }
        string Name { get; set; }
        short MapId { get; set; }
        short AvailableLevel { get; set; }
    }
}
