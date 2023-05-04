using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Application.AuthOperations.Commands.Register;
using WebApi.Application.EnrollmentOperations.Commands.CreateEnrollment;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Application.PetOperations.Commands.CreatePet;
using WebApi.Application.PetOperations.Queries.PetDetail;
using WebApi.Application.TrainingOperations.Commands.CreateTraining;
using WebApi.Application.TrainingOperations.Queries.GetTrainingDetail;
using WebApi.Application.TrainingOperations.Queries.GetTrainings;
using WebApi.Application.UserOperations.Queries.GetPets;
using WebApi.Application.UserOperations.Queries.GetUserDetail;
using WebApi.Entities;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Training Mappings
            CreateMap<Training, TrainingViewModel>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Training, TrainingDetailViewModel>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                .ForMember(dest => dest.TrainerName, opt => opt.MapFrom(src => $"{src.User.Name} {src.User.Surname}"))
                .ForMember(dest => dest.TrainerEmail, opt => opt.MapFrom(src => src.User.Email));
            CreateMap<CreateTrainingModel, Training>();
            #endregion

            #region Genre Mappings
            CreateMap<Genre, GenreViewModel>();
            #endregion

            #region Enrollment Mappings
            CreateMap<CreateEnrollmentModel, Enrollment>();
            #endregion

            #region Auth Mappings
            CreateMap<RegisterModel, User>();
            #endregion

            #region Pet Mappings
            CreateMap<CreatePetModel, Pet>();
            CreateMap<Pet, UserPetViewModel>();
            CreateMap<Pet, PetViewModel>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            #endregion

            #region User Mappings
            CreateMap<User, UserDetailViewModel>();
            #endregion
        }
    }
}
