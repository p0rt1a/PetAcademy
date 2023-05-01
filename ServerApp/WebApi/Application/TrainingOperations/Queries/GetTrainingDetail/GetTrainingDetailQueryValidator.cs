using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Application.TrainingOperations.Queries.GetTrainingDetail
{
    public class GetTrainingDetailQueryValidator : AbstractValidator<GetTrainingDetailQuery>
    {
        public GetTrainingDetailQueryValidator()
        {
            RuleFor(query => query.TrainingId).GreaterThan(0);
        }
    }
}
