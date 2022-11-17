using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop.Infrastructure;
using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data
{
    public class AcademyContext : DbContext
    {
        public AcademyContext(DbContextOptions<AcademyContext> options) : base(options)
        {
        }
        public DbSet<Pet> Pets { get; set; }
    }
}
