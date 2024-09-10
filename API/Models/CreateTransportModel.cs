namespace API.Models
{
    public class CreateTransportModel
    {
        public string Name { get; set; }
        public short EngineSize { get; set; }
        public short PassengersCount { get; set; }
        public int Price { get; set; }
        public short? ModelId { get; set; }
        public short AvailableLevel { get; set; }
    }
}
