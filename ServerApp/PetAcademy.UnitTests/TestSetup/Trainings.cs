using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace PetAcademy.UnitTests.TestSetup
{
    public static class Trainings
    {
        public static void AddTrainings(this AcademyDbContext context)
        {
            context.Trainings.AddRange(
                new Training()
                {
                    Title = "Yürüme Eğitimi",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    City = "İzmir",
                    Address = "Karşıyaka",
                    Price = 1350,
                    GenreId = 1,
                    UserId = 1,
                    MaxPetCount = 10
                },
                new Training()
                {
                    Title = "Tuvalet Eğitimi",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    City = "Ankara",
                    Address = "Çankaya",
                    Price = 1250,
                    GenreId = 2,
                    UserId = 2,
                    MaxPetCount = 5
                },
                new Training()
                {
                    Title = "Tuvalet Eğitimi",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    City = "Denizli",
                    Address = "Albayrak",
                    Price = 2000,
                    GenreId = 1,
                    UserId = 2,
                    MaxPetCount = 10
                },
                new Training()
                {
                    Title = "İtaat Eğitimi",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    City = "İzmir",
                    Address = "Alsancak",
                    Price = 3750,
                    GenreId = 1,
                    UserId = 2,
                    MaxPetCount = 12
                },
                new Training()
                {
                    Title = "Komut Eğitimi",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    City = "Ankara",
                    Address = "Şeyhşamil",
                    Price = 1000,
                    GenreId = 2,
                    UserId = 1,
                    MaxPetCount = 10
                },
                new Training()
                {
                    Title = "Saldırganlık Eğitimi",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    City = "İstanbul",
                    Address = "Çekmeköy",
                    Price = 7000,
                    GenreId = 2,
                    UserId = 2,
                    MaxPetCount = 10
                }
            );
        }
    }
}
