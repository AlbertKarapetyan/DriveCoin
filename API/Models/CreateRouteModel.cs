namespace API.Models
{
    public class CreateRouteModel
    {
        public string Name { get; set; }
        public short ACityId { get; set; }
        public short BCityId { get; set; }
        public short TimeDelay { get; set; }
    }
}
