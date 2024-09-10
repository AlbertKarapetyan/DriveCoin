using Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("vehicles")]
    [Index(nameof(TransportId), Name = "ix_vehicles_transport_id")]
    [Index(nameof(UserId), Name = "ix_vehicles_user_id")]
    [Index(nameof(CityId), Name = "ix_vehicles_city_id")]
    [Index(nameof(RouteId), Name = "ix_vehicles_route_id")]
    public class Vehicle : IVehicle
    {
        [Key]
        [Column(name: "id")]
        public int Id { get; set; }

        [Required]
        [Column(name: "transport_id")]
        public int TransportId { get; set; }

        [Required]
        [Column(name: "user_id")]
        public int UserId { get; set; }

        [Column(name: "boost_level")]
        public short BoostLevel { get; set; }

        [Column(name: "engine_size")]
        public short EngineSize { get; set; }

        [Column(name: "passengers_count")]
        public short PassengersCount { get; set; }

        [Column(name: "city_id")]
        public short? CityId { get; set; }

        [Column(name: "route_id")]
        public int? RouteId { get; set; }

        [Column(name: "start_date")]
        public DateTime? StartDate { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public Transport Transport { get; set; }

        public City? City { get; set; }

        public Route? Route { get; set; }
    }
}
