using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Application.TrainingOperations.Queries.GetTrainings;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.TrainingOperations.Queries.GetFullTrainings
{
    public class GetFullTrainingsQuery
    {
        private readonly IAcademyDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFullTrainingsQuery(IAcademyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<TrainingViewModel> Handle()
        {
            var trainings = _dbContext.Trainings
                .Include(x => x.Enrollments)
                .Where(x => x.MaxPetCount <= x.Enrollments.Count)
                .ToList<Training>();

            var vm = _mapper.Map<List<TrainingViewModel>>(trainings);

            return vm;
        }
    }
}
