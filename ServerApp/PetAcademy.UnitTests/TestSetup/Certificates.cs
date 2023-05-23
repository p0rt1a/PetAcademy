using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace PetAcademy.UnitTests.TestSetup
{
    public static class Certificates
    {
        public static void AddCertificates(this AcademyDbContext context)
        {
            context.Certificates.AddRange(
                new Certificate()
                {
                    PetId = 1,
                    TrainingId = 1,
                    Date = DateTime.Now.Date
                },
                new Certificate()
                {
                    PetId = 2,
                    TrainingId = 2,
                    Date = DateTime.Now.Date
                });
        }
    }
}
