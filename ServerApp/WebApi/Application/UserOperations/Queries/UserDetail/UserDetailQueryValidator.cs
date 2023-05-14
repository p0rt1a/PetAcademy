using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Application.UserOperations.Queries.UserDetail
{
    public class UserDetailQueryValidator : AbstractValidator<UserDetailQuery>
    {
        public UserDetailQueryValidator()
        {
            RuleFor(query => query.UserId).GreaterThan(0);
        }
    }
}
