using Microsoft.EntityFrameworkCore;
using System;
using WebApi.Entities;

namespace WebApi.DbOperations
{
    public interface IAcademyDbContext
    {
        DbSet<Training> Trainings { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Pet> Pets { get; set; }
        DbSet<Enrollment> Enrollments { get; set; }
        DbSet<User> Users { get; set; }
        int SaveChanges();
    }
}
