using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.EnrollmentOperations.Commands.CreateEnrollment
{
    public class CreateEnrollmentCommand
    {
        private readonly IAcademyDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateEnrollmentModel Model { get; set; }

        public CreateEnrollmentCommand(IAcademyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var enrollment = _dbContext.Enrollments.SingleOrDefault(x => x.PetId == Model.PetId && x.TrainingId == Model.TrainingId);

            if (enrollment is not null)
                throw new InvalidOperationException("Evcil hayvan zaten bu eğitimde mevcut");

            enrollment = _mapper.Map<Enrollment>(Model);

            _dbContext.Enrollments.Add(enrollment);
            _dbContext.SaveChanges();
        }
    }

    public class CreateEnrollmentModel
    {
        public int PetId { get; set; }
        public int TrainingId { get; set; }
    }
}
