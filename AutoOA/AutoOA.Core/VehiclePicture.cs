using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoOA.Core
{
    public class VehiclePicture
    {
        [Key]
        public int PictureId { get; set; }
        public string? PictureName { get; set; }
        public string? PicturePath { get; set; }
    }
}
