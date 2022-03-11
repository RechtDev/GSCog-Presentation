using MVCRecap.Models.ValidationClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCRecap.Models
{
    public class Ticket
    {
        [Key]
        public int TicketID { get; set; }
        [Required]
        public string ClientName { get; set; }
        [Required]
        public string Airline { get; set; }
        [Required]
        public string Origin { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double Cost { get; set; }
        [Required]
        [DateValidation]
        public DateTime DepartDate { get; set; }
        [DateValidation]
        public DateTime ReturnDate { get; set; }
    }
}
