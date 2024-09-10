namespace Infrastructure.Data.Models
{
    public interface IUser
    {
        int Id { get; set; }
        long ExternalId { get; set; }
        short Level { get; set; }
        string? UserName { get; set; }
        string? Email { get; set; }
        int? RefId { get; set; }
        bool IsPremium { get; set; }
        int? RegionId { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime? LastSignedDate { get; set; }
    }
}
