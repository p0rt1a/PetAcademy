using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Application.UserOperations.Queries.UserTrainings
{
    public class UserTrainingsQueryValidator : AbstractValidator<UserTrainingsQuery>
    {
        public UserTrainingsQueryValidator()
        {
            RuleFor(query => query.UserId).GreaterThan(0);
        }
    }
}
