using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace PetAcademy.UnitTests.TestSetup
{
    public static class Pets
    {
        public static void AddPets(this AcademyDbContext context)
        {
            context.Pets.AddRange(
                new Pet()
                {
                    Name = "Huysuz",
                    Age = 2,
                    GenreId = 1,
                    UserId = 1
                },
                new Pet()
                {
                    Name = "Bonjour",
                    Age = 1,
                    GenreId = 2,
                    UserId = 2
                },
                new Pet()
                {
                    Name = "Tekir",
                    Age = 3,
                    GenreId = 2,
                    UserId = 1
                }
            );
        }
    }
}
