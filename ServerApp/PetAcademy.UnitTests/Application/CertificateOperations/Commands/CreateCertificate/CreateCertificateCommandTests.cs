using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PetAcademy.UnitTests.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.CertificateOperations.Commands.CreateCertificate;
using WebApi.DbOperations;
using Xunit;

namespace PetAcademy.UnitTests.Application.CertificateOperations.Commands.CreateCertificate
{
    public class CreateCertificateCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly AcademyDbContext _context;
        private readonly IMapper _mapper;

        public CreateCertificateCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenDoesntExistPetIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            CreateCertificateCommand command = new(_context, _mapper);
            command.Model = new CreateCertificateModel()
            {
                PetId = 0,
                TrainingId = 1
            };

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>("Evcil hayvan bulunamadı!");
        }

        [Fact]
        public void WhenDoesntExistTrainingIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            CreateCertificateCommand command = new(_context, _mapper);
            command.Model = new CreateCertificateModel()
            {
                PetId = 1,
                TrainingId = 0
            };

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>("Eğitim bulunamadı!");
        }

        [Fact]
        public void WhenGivenPetDoesntHaveEnrollmentToTraining_InvalidOperationException_ShouldBeReturn()
        {
            CreateCertificateCommand command = new(_context, _mapper);
            command.Model = new CreateCertificateModel()
            {
                PetId = 1,
                TrainingId = 2
            };

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>("Evcil hayvan bu eğitime kayıtlı değil!");
        }

        [Fact]
        public void WhenGivenPetDoesHaveEnrollmentToTraining_Certificate_ShouldBeCreated()
        {
            CreateCertificateCommand command = new(_context, _mapper);
            command.Model = new CreateCertificateModel()
            {
                PetId = 1,
                TrainingId = 1
            };

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var certificate = _context.Certificates.FirstOrDefault(x => x.PetId == command.Model.PetId && x.TrainingId == command.Model.TrainingId);
            certificate.PetId.Should().Be(command.Model.PetId);
            certificate.TrainingId.Should().Be(command.Model.TrainingId);
        }
    }
}
