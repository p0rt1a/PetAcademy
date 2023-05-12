using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            
        }
    }
}
