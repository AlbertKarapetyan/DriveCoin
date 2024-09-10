namespace Infrastructure.Data.Models
{
    public interface IVehicle
    {
        int Id { get; set; }
        int TransportId { get; set; }
        int UserId { get; set; }
        short BoostLevel { get; set; }
        short EngineSize { get; set; }
        short PassengersCount { get; set; }
        short? CityId { get; set; }
        int? RouteId { get; set; }
        DateTime? StartDate { get; set; }
    }
}
