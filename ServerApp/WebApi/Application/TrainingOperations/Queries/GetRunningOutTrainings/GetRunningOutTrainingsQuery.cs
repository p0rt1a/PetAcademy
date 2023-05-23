using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using WebApi.Application.TrainingOperations.Queries.GetTrainings;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.TrainingOperations.Queries.GetRunningOutTrainings
{
    public class GetRunningOutTrainingsQuery
    {
        private readonly IAcademyDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetRunningOutTrainingsQuery(IAcademyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<TrainingViewModel> Handle()
        {
            var trainings = _dbContext.Trainings
                .Include(x => x.Genre)
                .Where(x => x.MaxPetCount - x.Enrollments.Count < 5 && x.Enrollments.Count < x.MaxPetCount)
                .ToList<Training>();

            var vm = _mapper.Map<List<TrainingViewModel>>(trainings);

            return vm;
        }
    }
}
