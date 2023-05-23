using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Common;
using WebApi.DbOperations;

namespace PetAcademy.UnitTests.TestSetup
{
    public class CommonTestFixture
    {
        public AcademyDbContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<AcademyDbContext>().UseInMemoryDatabase(databaseName: "AcademyTestDb").Options;
            Context = new AcademyDbContext(options);

            Context.Database.EnsureCreated();
            Context.AddTrainings();
            Context.AddGenres();
            Context.AddUsers();
            Context.AddPets();
            Context.AddEnrollments();
            Context.AddComments();
            Context.AddCertificates();
            Context.SaveChanges();

            Mapper = new MapperConfiguration(config => { config.AddProfile<MappingProfile>(); }).CreateMapper();
        }
    }
}
