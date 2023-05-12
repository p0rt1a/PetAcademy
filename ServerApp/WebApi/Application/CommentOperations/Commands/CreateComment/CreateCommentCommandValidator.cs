using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Application.CommentOperations.Commands.CreateComment
{
    public class CreateCommentCommandValidator: AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(command => command.Model.UserId).GreaterThan(0);
            RuleFor(command => command.Model.TrainingId).GreaterThan(0);
        }
    }
}
