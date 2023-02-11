using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ErnestoParking.Models;

namespace ErnestoParking.Data
{
    public class ErnestoParkingContext : DbContext
    {
        public ErnestoParkingContext (DbContextOptions<ErnestoParkingContext> options)
            : base(options)
        {
        }

        public DbSet<ErnestoParking.Models.Conveniado> Conveniado { get; set; } = default!;
    }
}
