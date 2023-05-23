using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Application.EnrollmentOperations.Commands.DeleteEnrollment
{
    public class DeleteEnrollmentCommand
    {
        private readonly IAcademyDbContext _dbContext;
        private readonly IMapper _mapper;
        public int TrainingId { get; set; }
        public int PetId { get; set; }

        public DeleteEnrollmentCommand(IAcademyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var enrollment = _dbContext.Enrollments
                .FirstOrDefault(x => x.PetId == PetId && x.TrainingId == TrainingId);

            if (enrollment is null)
                throw new InvalidOperationException("Evcil hayvan bu eğitime üye değil!");

            _dbContext.Enrollments.Remove(enrollment);
            _dbContext.SaveChanges();
        }
    }
}
