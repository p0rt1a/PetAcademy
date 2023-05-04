using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Application.PetOperations.Queries.PetDetail
{
    public class PetDetailQuery
    {
        private readonly IAcademyDbContext _dbContext;
        private readonly IMapper _mapper;
        public int PetId { get; set; }

        public PetDetailQuery(IAcademyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public PetViewModel Handle()
        {
            var pet = _dbContext.Pets
                .Include(x => x.Genre)
                .SingleOrDefault(x => x.Id == PetId);

            if (pet is null)
                throw new InvalidOperationException("Evcil hayvan bulunamadı!");

            var vm = _mapper.Map<PetViewModel>(pet);

            return vm;
        }
    }

    public class PetViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Genre { get; set; }
    }
}
