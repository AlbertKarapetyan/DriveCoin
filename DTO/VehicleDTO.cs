namespace DTO
{
    public class VehicleDTO
    {
        public int Id { get; set; }
        public int TransportId { get; set; }
        public int UserId { get; set; }
        public short BoostLevel { get; set; }
        public short EngineSize { get; set; }
        public short PassengersCount { get; set; }
        public short? CityId { get; set; }
        public int? RouteId { get; set; }
        public DateTime? StartDate { get; set; }
    }
}
