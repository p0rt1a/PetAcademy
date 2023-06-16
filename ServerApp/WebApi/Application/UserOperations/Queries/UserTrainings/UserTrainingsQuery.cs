using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Application.TrainingOperations.Queries.GetTrainings;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.UserOperations.Queries.UserTrainings
{
    public class UserTrainingsQuery
    {
        private readonly IAcademyDbContext _dbContext;
        private readonly IMapper _mapper;
        public int UserId { get; set; }

        public UserTrainingsQuery(IAcademyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<TrainingViewModel> Handle()
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Id == UserId);

            if (user is null)
                throw new InvalidOperationException("Kullanıcı mevcut değil!");

            var trainings = _dbContext.Trainings
                .Include(x => x.Genre)
                .Where(x => x.UserId == UserId && x.IsActive == true)
                .ToList<Training>();

            var vm = _mapper.Map<List<TrainingViewModel>>(trainings);

            return vm;
        }
    }
}
