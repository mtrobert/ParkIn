using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkInAPI.Models
{
    public class NationalPark
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        public string Area { get; set; }

        public DateTime Created { get; set; }

        public DateTime Established { get; set; }


    }
}
