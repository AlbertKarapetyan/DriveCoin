namespace Infrastructure.Data.Models
{
    public interface IMap
    {
        short Id { get; set; }
        string Name { get; set; }
        short AvailableLevel { get; set; }
    }
}
