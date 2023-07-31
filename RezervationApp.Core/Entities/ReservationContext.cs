using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ReservationApp.Core.Entities
{
    public class ReservationContext : DbContext
    {
        public DbSet<Table> Table { get; set; }
        public DbSet<Reservation> Reservation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=C:\Users\060739\Desktop\örnek vaka\Rezervation.db");
    }
}
