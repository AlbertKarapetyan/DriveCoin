namespace API.Models
{
    public class CreateUserModel
    {
        public long ExternalId { get; set; }
        public string? UserName { get; set; }
        public long? RefId { get; set; }
        public bool IsPremium { get; set; }
    }
}
