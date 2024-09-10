namespace Infrastructure.Data.Models
{
    public interface IBalance
    {
        int Id { get; set; }
        int UserId { get; set; }
        double Coins { get; set; }
    }
}