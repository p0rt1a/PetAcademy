using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Application.TrainingOperations.Queries.GetTrainings;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.UserOperations.Queries.GetUserTrainings
{
    public class GetUserTrainingsQuery
    {
        private readonly IAcademyDbContext _dbContext;
        private readonly IMapper _mapper;
        public int UserId { get; set; }

        public GetUserTrainingsQuery(IAcademyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<TrainingViewModel> Handle()
        {
            var trainings = _dbContext.Trainings
                .Include(x => x.Genre)
                .Where(x => x.UserId == UserId)
                .ToList<Training>();

            var vm = _mapper.Map<List<TrainingViewModel>>(trainings);

            return vm;
        }
    }
}
