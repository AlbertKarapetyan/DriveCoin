using Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("maps")]
    public class Map : IMap
    {
        [Key]
        [Column(name: "id")]
        public short Id { get; set; }

        [Required]
        [Column(name: "name")]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [Column(name: "available_level")]
        public short AvailableLevel { get; set; }
    }
}
