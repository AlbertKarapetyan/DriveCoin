namespace Infrastructure.Data.Models
{
    public interface ITransport
    {
        int Id { get; set; }
        string Name { get; set; }
        short EngineSize { get; set; }
        short PassengersCount { get; set; }
        int Price { get; set; }
        short? ModelId { get; set; }
        short AvailableLevel { get; set; }
    }
}
