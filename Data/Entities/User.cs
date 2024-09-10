using Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("users")]
    [Index(nameof(ExternalId), Name = "ix_user_external_id")]
    public class User : IUser
    {
        [Key]
        [Column(name: "id")]
        public int Id { get; set; }

        [Column(name: "external_id")]
        [Required]
        public long ExternalId { get; set; }

        [Column(name: "level")]
        [Required]
        public short Level { get; set; }

        [Column(name: "user_name")]
        [MaxLength(150)] 
        public string? UserName { get; set; }

        [Column(name: "email")]
        [MaxLength(150)]
        public string? Email { get; set; }

        [Column(name: "ref_id")]
        public int? RefId { get; set; }

        [Column(name: "is_premium")]
        public bool IsPremium { get; set; }

        [Column(name: "region_id")]
        public int? RegionId { get; set; }

        [Column(name: "created_date")]
        public DateTime CreatedDate { get; set; }

        [Column(name: "last_signed_date")]
        public DateTime? LastSignedDate { get; set; }
    }
}
