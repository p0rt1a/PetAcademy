using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Application.EnrollmentOperations.Commands.CreateEnrollment
{
    public class CreateEnrollmentCommand
    {
        private readonly IAcademyDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateEnrollmentCommand(IAcademyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            //TODO: Add enrollment controls and throw error

            //TODO: Map model to enrollment and save
        }
    }

    public class CreateEnrollmentModel
    {
        public int PetId { get; set; }
        public int TrainingId { get; set; }
    }
}
