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
            var enrollment = _dbContext.Enrollments.FirstOrDefault(x => x.PetId == Model.PetId && x.TrainingId == Model.TrainingId);
            var pet = _dbContext.Pets.SingleOrDefault(x => x.Id == Model.PetId);
            var training = _dbContext.Trainings.SingleOrDefault(x => x.Id == Model.TrainingId);

            if (enrollment is not null)
                throw new InvalidOperationException("Evcil hayvan zaten bu eğitimde mevcut.");

            if (pet.GenreId != training.GenreId)
                throw new InvalidOperationException("Evcil hayvan türü, eğitim türü için uygun değil.");

            if (training is null)
                throw new InvalidOperationException("Eğitim mevcut değil!");

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
