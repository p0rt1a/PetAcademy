using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop.Infrastructure;
using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data
{
    public class AcademyContext : IdentityDbContext<User, Role, int>
    {
        public AcademyContext(DbContextOptions<AcademyContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<CategoryTraining> CategoryTraining { get; set; }
    }
}
