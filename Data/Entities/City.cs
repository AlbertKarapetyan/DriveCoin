using Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("cities")]
    [Index(nameof(MapId), Name = "ix_cities_map_id")]
    public class City : ICity
    {
        [Key]
        [Column(name: "id")]
        public short Id { get; set; }

        [Column(name: "name")]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [Column(name: "map_id")]
        public short MapId { get; set; }

        [Required]
        [Column(name: "available_level")]
        public short AvailableLevel { get; set; }

        [Required]
        public Map Map { get; set; }
    }
}
