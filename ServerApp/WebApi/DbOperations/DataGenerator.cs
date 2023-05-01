using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WebApi.Entities;

namespace WebApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new AcademyDbContext(serviceProvider.GetRequiredService<DbContextOptions<AcademyDbContext>>()))
            {
                if (context.Trainings.Any())
                    return;

                context.Trainings.AddRange(
                        new Training()
                        {
                            Title = "Yürüme Eğitimi",
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            City = "İzmir",
                            Address = "Karşıyaka",
                            Price = 1350,
                            GenreId = 1
                        },
                        new Training()
                        {
                            Title = "Tuvalet Eğitimi",
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            City = "Ankara",
                            Address = "Çankaya",
                            Price = 1250,
                            GenreId = 2
                        },
                        new Training()
                        {
                            Title = "Tuvalet Eğitimi",
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            City = "Denizli",
                            Address = "Albayrak",
                            Price = 2000,
                            GenreId = 1
                        }
                    );

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

                context.Pets.AddRange(
                        new Pet()
                        {
                            Name = "Huysuz",
                            Age = 2,
                            GenreId = 1
                        },
                        new Pet()
                        {
                            Name = "Bonjour",
                            Age = 1,
                            GenreId = 2
                        },
                        new Pet()
                        {
                            Name = "Tekir",
                            Age = 3,
                            GenreId = 2
                        }
                    );

                context.Enrollments.AddRange(
                        new Enrollment()
                        {
                            TrainingId = 1,
                            PetId = 1
                        },
                        new Enrollment()
                        {
                            TrainingId = 2,
                            PetId = 1
                        },
                        new Enrollment()
                        {
                            TrainingId = 2,
                            PetId = 2
                        }
                    );

                context.SaveChanges();
            }
        }
    }
}
