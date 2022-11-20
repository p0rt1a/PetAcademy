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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Training> Trainings { get; set; }

        public AcademyContext(DbContextOptions<AcademyContext> options) : base(options)
        {
        }
    }
}
