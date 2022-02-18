using Microsoft.EntityFrameworkCore;
using MVCRecap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCRecap.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<AirlineModel> AirlineModel { get; set; }
        public DbSet<DestinationModel> DestinationModel { get; set; }
        public DbSet<MVCRecap.Models.TicketModel> TicketModel { get; set; }
    }
}
