using Demo.Dal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Dal.Context
{
    public class Mydbcontext : IdentityDbContext<ApplicationUser>
    {
        public Mydbcontext(DbContextOptions<Mydbcontext>options):base(options) 
        {
            
        }
        //public Mydbcontext()
        //{

        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //=> optionsBuilder.UseSqlServer("Server=.;DataBase=ProjectMvc;Trusted_Connection=True;MultipleResultSets=True");

        public DbSet<Department> Deprtments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
