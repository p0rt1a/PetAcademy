using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Application.TrainingOperations.Queries.GetTrainingDetail
{
    public class GetTrainingDetailQuery
    {
        private readonly IAcademyDbContext _dbContext;
        private readonly IMapper _mapper;
        public int TrainingId { get; set; }

        public GetTrainingDetailQuery(IAcademyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var training = _dbContext.Trainings.SingleOrDefault(x => x.Id == TrainingId);

            if (training is null)
                throw new InvalidOperationException("Eğitim bulunamadı");

            //TODO: Map training and return viewModel
        }
    }

    public class TrainingDetailViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
    }
}
