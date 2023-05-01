using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenres
{
    public class GetGenresQuery
    {
        private readonly IAcademyDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGenresQuery(IAcademyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            //TODO: Get genres with using mapper
        }
    }

    public class GenreViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
