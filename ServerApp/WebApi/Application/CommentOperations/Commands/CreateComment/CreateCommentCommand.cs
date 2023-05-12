using AutoMapper;
using Microsoft.AspNetCore.Server.IIS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
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
            var training = _dbContext.Trainings.SingleOrDefault(x => x.Id == Model.TrainingId);

            if (training is null)
                throw new InvalidOperationException("Eğitim bulunamadı");

            var user = _dbContext.Users.SingleOrDefault(x => x.Id == Model.UserId);

            if (user is null)
                throw new InvalidOperationException("Kullanıcı bulunamadı");

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
