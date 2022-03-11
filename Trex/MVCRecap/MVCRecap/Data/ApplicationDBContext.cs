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
        public DbSet<Airline> Airline { get; set; }
        public DbSet<Destination> Destination { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
    }
}
