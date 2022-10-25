using AutoOA.Core;
using System.ComponentModel.DataAnnotations;

namespace AutoOA.Repository.Dto.VehicleDto
{
    public class VehicleCreateDto
    {
        [Required]
        public DateTime FirstRegistrationDate { get; set; }

        [Required]
        public string? RegionName { get; set; }

        [Required]
        public string? BodyTypeName { get; set; }

        [Required]
        public string? VehicleModelName { get; set; }

        [Required]
        public string? DriveTypeName { get; set; }

        [Required]
        public string? StateNumber { get; set; }

        [Required]
        public DateTime ProductionDate { get; set; }

        [Required]
        public string? VehicleBrandName { get; set; }

        [Required]
        public string? GearBoxName { get; set; }

        [Required]
        public int NumberOfSeats { get; set; }

        [Required]
        public int NumberOfDoors { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public bool isNew { get; set; }

        [Required]
        public int? Mileage { get; set; }

        [Required]
        public string? VehicleIconPath { get; set; }

        [Required]
        public string? FuelTypeName { get; set; }

        [Required]
        public string? Color { get; set; }

        [Required]
        public string? Description { get; set; }

        public SalesData? SalesData { get; set; }
    }
}
