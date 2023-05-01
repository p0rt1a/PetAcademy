using Microsoft.EntityFrameworkCore;
using System;
using WebApi.Entities;

namespace WebApi.DbOperations
{
    public interface IAcademyDbContext
    {
        DbSet<Training> Trainings { get; set; }
        DbSet<Genre> Genres { get; set; }
        int SaveChanges();
    }
}
