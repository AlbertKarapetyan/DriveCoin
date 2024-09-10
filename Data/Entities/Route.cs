using Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("routes")]
    [Index(nameof(ACityId), Name = "ix_routes_a_city_id")]
    [Index(nameof(BCityId), Name = "ix_routes_b_city_id")]
    public class Route : IRoute
    {
        [Key]
        [Column(name: "id")]
        public int Id { get; set; }

        [Required]
        [Column(name: "name")]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [Column(name: "a_city_id")]
        public short ACityId { get; set; }

        [Required]
        [Column(name: "b_city_id")]
        public short BCityId { get; set; }

        [Required]
        [Column(name: "time_delay")]
        public short TimeDelay { get; set; }

        [Required]
        public City ACity { get; set; }

        [Required]
        public City BCity { get; set; }
    }
}
