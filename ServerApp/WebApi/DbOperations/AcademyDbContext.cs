﻿using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DbOperations
{
    public class AcademyDbContext : DbContext, IAcademyDbContext
    {
        public AcademyDbContext(DbContextOptions<AcademyDbContext> options) : base(options)
        {
        }

        public DbSet<Training> Trainings { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
