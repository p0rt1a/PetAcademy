using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Application.PetOperations.Queries.PetDetail
{
    public class PetDetailQueryValidator : AbstractValidator<PetDetailQuery>
    {
        public PetDetailQueryValidator()
        {
            RuleFor(query => query.PetId).GreaterThan(0); 
        }
    }
}
