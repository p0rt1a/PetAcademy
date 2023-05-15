using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.PetOperations.Queries.PetCertificates
{
    public class PetCertificatesQuery
    {
        private readonly IAcademyDbContext _dbContext;
        private readonly IMapper _mapper;
        public int PetId { get; set; }

        public PetCertificatesQuery(IAcademyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<PetCertificateViewModel> Handle()
        {
            var certificates = _dbContext.Certificates
                .Include(x => x.Pet)
                .Include(x => x.Training)
                .Where(x => x.PetId == PetId)
                .ToList<Certificate>();

            var vm = _mapper.Map<List<PetCertificateViewModel>>(certificates);

            return vm;
        }
    }

    public class PetCertificateViewModel
    {
        public string TrainingTitle { get; set; }
        public string GraduateDate { get; set; }
        public string PetName { get; set; }
    }
}
