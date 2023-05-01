using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.TrainingOperations.Commands.CreateTraining
{
    public class CreateTrainingCommand
    {
        private readonly IAcademyDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateTrainingModel Model { get; set; }

        public CreateTrainingCommand(IAcademyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var createdTraining = _mapper.Map<Training>(Model);

            _dbContext.Trainings.Add(createdTraining);
            _dbContext.SaveChanges();
        }
    }

    public class CreateTrainingModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
    }
}
