using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.TrainingOperations.Queries.GetComments
{
    public class GetCommentsQuery
    {
        private readonly IAcademyDbContext _dbContext;
        private readonly IMapper _mapper;
        public int TrainingId { get; set; }

        public GetCommentsQuery(IAcademyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<TrainingCommentViewModel> Handle()
        {
            var comments = _dbContext.Comments
                .Include(x => x.User)
                .Where(x => x.TrainingId == TrainingId)
                .ToList<Comment>();

            var vm = _mapper.Map<List<TrainingCommentViewModel>>(comments);

            return vm;
        }
    }

    public class TrainingCommentViewModel
    {
        public int UserId { get; set; }
        public string Body { get; set; }
        public string User { get; set; }
        public string Date { get; set; }
    }
}
