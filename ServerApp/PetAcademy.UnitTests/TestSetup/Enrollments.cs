using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace PetAcademy.UnitTests.TestSetup
{
    public static class Enrollments
    {
        public static void CreateEnrollments(this AcademyDbContext context)
        {
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
        }
    }
}
