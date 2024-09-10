using Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    [Table("transports")]
    public class Transport : ITransport
    {
        [Key]
        [Column(name: "id")]
        public int Id { get; set; }

        [Column(name: "name")]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [Column(name: "engine_size")]
        public short EngineSize { get; set; }

        [Required]
        [Column(name: "passengers_count")]
        public short PassengersCount { get; set; }

        [Required]
        [Column(name: "price")]
        public int Price { get; set; }

        [Column(name: "model_id")]
        public short? ModelId { get; set; }

        [Required]
        [Column(name: "available_level")]
        public short AvailableLevel { get; set; }
    }
}
