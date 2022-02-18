using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCRecap.Models
{
    public class TicketModel
    {
        [Key]
        public int TicketID { get; set; }
        [Required]
        public string Airline { get; set; }
        [Required]
        public string Origin { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double Cost { get; set; }
        public DateTime Date { get; set; }
    }
}
