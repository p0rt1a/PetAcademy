using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
            var pet = _dbContext.Pets.Include(x => x.Genre).SingleOrDefault(x => x.Id == Model.PetId);
            var training = _dbContext.Trainings.Include(x => x.Genre).SingleOrDefault(x => x.Id == Model.TrainingId);

            if (enrollment is not null)
                throw new InvalidOperationException("Evcil hayvan zaten bu eğitimde mevcut.");

            if (pet.Genre.Name != training.Genre.Name)
                throw new InvalidOperationException("Evcil hayvan türü, eğitim türü için uygun değil.");

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
