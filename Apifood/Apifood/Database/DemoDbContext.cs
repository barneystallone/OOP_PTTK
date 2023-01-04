using backendtexxt.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apifood.Database;
using Apifood.Models;

namespace Apifood.Database
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<menu> menu { get; set; }
        public DbSet<food> food { get; set; }
        public DbSet<New> news { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerSP> CustomerSP { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<Slider> slide { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Bill> Bill { get; set; }
        public DbSet<BillDetail> BillDetail { get; set; }
        public DbSet<adminLogin> admin { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
