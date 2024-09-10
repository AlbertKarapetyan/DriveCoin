namespace DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public long ExternalId { get; set; }
        public short Level { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public int? RefId { get; set; }
        public bool IsPremium { get; set; }
        public int? RegionId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastSignedDate { get; set; }
    }
}
