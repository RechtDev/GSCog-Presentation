using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCRecap.Models
{
    public class DestinationModel
    {
        [Key]
        public int DestID { get; set; }
        [Required]
        public string City { get; set; }
    }
}
