using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkInAPI.Models.DTOs
{
    public class NationalParkDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Area { get; set; }
        public DateTime Created { get; set; }
        public DateTime Established { get; set; }
    }
}
