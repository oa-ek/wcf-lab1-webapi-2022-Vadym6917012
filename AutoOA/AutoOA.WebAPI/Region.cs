﻿using System.ComponentModel.DataAnnotations;

namespace AutoOA.WebAPI
{
    public class Region
    {
        [Key]
        public int RegionId { get; set; }
        public string? RegionName { get; set; }

        public virtual ICollection<Vehicle>? Vehicles { get; set; }
    }
}