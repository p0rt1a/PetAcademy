using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace PetAcademy.UnitTests.TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this AcademyDbContext context)
        {
            context.Genres.AddRange(
                    new Genre()
                    {
                        Name = "Köpek"
                    },
                    new Genre()
                    {
                        Name = "Kedi"
                    },
                    new Genre()
                    {
                        Name = "At"
                    }
                );
        }
    }
}
