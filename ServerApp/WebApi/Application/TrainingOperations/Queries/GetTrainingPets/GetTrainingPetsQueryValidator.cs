using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Application.TrainingOperations.Queries.GetTrainingPets
{
    public class GetTrainingPetsQueryValidator : AbstractValidator<GetTrainingPetsQuery>
    {
        public GetTrainingPetsQueryValidator()
        {
            RuleFor(query => query.TrainingId).GreaterThan(0);
        }
    }
}
