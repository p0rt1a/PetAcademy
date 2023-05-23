using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Application.UserOperations.Queries.GetPets
{
    public class GetPetsQueryValidator : AbstractValidator<GetPetsQuery>
    {
        public GetPetsQueryValidator()
        {
            RuleFor(query => query.UserId).GreaterThan(0);
        }
    }
}
