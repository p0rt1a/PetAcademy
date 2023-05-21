using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.CertificateOperations.Commands.CreateCertificate
{
    public class CreateCertificateCommand
    {
        private readonly IAcademyDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateCertificateModel Model { get; set; }

        public CreateCertificateCommand(IAcademyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var pet = _dbContext.Pets.SingleOrDefault(x => x.Id == Model.PetId);

            if (pet is null)
                throw new InvalidOperationException("Evcil hayvan bulunamadı!");

            var training = _dbContext.Trainings.SingleOrDefault(x => x.Id == Model.TrainingId);

            if (training is null)
                throw new InvalidOperationException("Eğitim bulunamadı!");

            var enrollment = _dbContext.Enrollments.SingleOrDefault(x => x.PetId == Model.PetId && x.TrainingId == Model.TrainingId);

            if (enrollment is null)
                throw new InvalidOperationException("Evcil hayvan bu eğitime kayıtlı değil!");

            _dbContext.Enrollments.Remove(enrollment);

            var certificate = _mapper.Map<Certificate>(Model);

            _dbContext.Certificates.Add(certificate);
            _dbContext.SaveChanges();
        }
    }

    public class CreateCertificateModel
    {
        public int PetId { get; set; }
        public int TrainingId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now.Date;
    }
}
