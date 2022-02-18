using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCRecap.Models
{
    public class AirlineModel
    {
        [Key]
        public int AirID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool available { get; set; }
    }
}
