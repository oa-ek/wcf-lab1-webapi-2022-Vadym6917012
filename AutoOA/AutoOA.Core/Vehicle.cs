using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoOA.Core
{
    public class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VehicleId { get; set; }

        public int BodyTypeId { get; set; }
        public BodyType? BodyType { get; set; } // Тип кузова

        public int VehicleModelId { get; set; }
        public VehicleModel? VehicleModel { get; set; } // Модель

        public int GearBoxId { get; set; }
        public GearBox? GearBoxe { get; set; } // Коробка передач

        public decimal Price { get; set; } // Ціна
        public bool isNew { get; set; } // Новий?
        public int Mileage { get; set; } // Пробіг

        public string? IconPath { get; set; } // Шлях до іконки

        public int FuelTypeId { get; set; }
        public FuelType? FuelType { get; set; } // Тип палива
        
        public string? Color { get; set; } // Колір
    }
}
