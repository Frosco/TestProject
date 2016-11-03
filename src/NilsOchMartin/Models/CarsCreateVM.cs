using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NilsOchMartin.Models
{
    public class CarsCreateVM
    {
        [Display(Name ="Make")]
        [Required(ErrorMessage ="Put in brand")]
        public string Brand { get; set; }

        [Range(3, 5, ErrorMessage ="Wrong number of door")]
        [Required(ErrorMessage = "Put in doors")]
        public int Doors { get; set; }

        [Range(0, 300, ErrorMessage = "Invalid speed input")]
        [Required(ErrorMessage = "Put in topspeed")]
        public int TopSpeed { get; set; }
    }
}
