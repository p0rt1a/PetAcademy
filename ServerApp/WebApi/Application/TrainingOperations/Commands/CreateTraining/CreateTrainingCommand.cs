using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Application.TrainingOperations.Commands.CreateTraining
{
    public class CreateTrainingCommand
    {
        private readonly IAcademyDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateTrainingCommand(IAcademyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            //TODO: Create training with using mapper
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
