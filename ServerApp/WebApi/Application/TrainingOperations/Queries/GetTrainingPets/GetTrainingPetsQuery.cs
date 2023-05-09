using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.TrainingOperations.Queries.GetTrainingPets
{
    public class GetTrainingPetsQuery
    {
        private readonly IAcademyDbContext _dbContext;
        private readonly IMapper _mapper;
        public int TrainingId { get; set; }

        public GetTrainingPetsQuery(IAcademyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<TrainingPetViewModel> Handle()
        {
            var enrollments = _dbContext.Enrollments
                .Include(x => x.Pet)
                .ThenInclude(x => x.Genre)
                .Include(x => x.Pet)
                .ThenInclude(x => x.User)
                .Where(x => x.TrainingId == TrainingId)
                .ToList<Enrollment>();

            if (enrollments is null)
                throw new InvalidOperationException("Eğitim bulunamadı");

            var vm = _mapper.Map<List<TrainingPetViewModel>>(enrollments);

            return vm;
        }
    }

    public class TrainingPetViewModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Genre { get; set; }
        public string UserEmail { get; set; }
    }
}
