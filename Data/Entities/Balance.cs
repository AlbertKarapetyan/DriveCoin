using Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Data.Entities
{
    [Table("balances")]
    [Index(nameof(UserId), Name = "ix_balances_user_id")]
    public class Balance : IBalance
    {
        [Key]
        [Column(name: "id")]
        public int Id { get; set; }

        [Required]
        [Column(name: "user_id")]
        public int UserId { get; set; }

        [Required]
        [Column(name: "coins")]
        public double Coins { get; set; }

        [Required]
        public User User { get; set; }
    }
}
