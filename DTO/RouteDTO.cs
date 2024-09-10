namespace DTO
{
    public class RouteDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short ACityId { get; set; }
        public short BCityId { get; set; }
        public short TimeDelay { get; set; }
    }
}
