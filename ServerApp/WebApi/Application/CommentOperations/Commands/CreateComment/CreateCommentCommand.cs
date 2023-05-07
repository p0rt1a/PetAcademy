using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.CommentOperations.Commands.CreateComment
{
    public class CreateCommentCommand
    {
        private readonly IAcademyDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateCommentModel Model { get; set; }

        public CreateCommentCommand(IAcademyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var comment = _mapper.Map<Comment>(Model);

            _dbContext.Comments.Add(comment);
            _dbContext.SaveChanges();
        }
    }

    public class CreateCommentModel
    {
        public string Body { get; set; }
        public int UserId { get; set; }
        public int TrainingId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now.Date;
    }
}
