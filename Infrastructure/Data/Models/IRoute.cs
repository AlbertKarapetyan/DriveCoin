namespace Infrastructure.Data.Models
{
    public interface IRoute
    {
        int Id { get; set; }
        string Name { get; set; }
        short ACityId { get; set; }
        short BCityId { get; set; }
        short TimeDelay { get; set; }
    }
}
