using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Application.PetOperations.Queries.PetCertificates
{
    public class PetCertificatesQueryValidator : AbstractValidator<PetCertificatesQuery>
    {
        public PetCertificatesQueryValidator()
        {
            RuleFor(query => query.PetId).GreaterThan(0);
        }
    }
}
