using Microsoft.EntityFrameworkCore;

namespace WebApi.DbOperations
{
    public class AcademyDbContext : DbContext, IAcademyDbContext
    {
        public AcademyDbContext(DbContextOptions<AcademyDbContext> options) : base(options)
        {
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
