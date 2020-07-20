using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIproject.Models; 

namespace APIproject.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<usr_in_cty> city { get; set; }
        public DbSet<usr_in_dys> days { get; set; }
        //public DbSet<usr_in_intrst> interest { get; set; }
        //public DbSet<usr_out_cty_attrn> attractions { get; set; }
        //public DbSet<usr_out_trvl_plan> travelPlan { get; set; }

    }
}
