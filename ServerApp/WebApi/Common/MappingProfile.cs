using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using WebApi.Application.AuthOperations.Commands.Register;
using WebApi.Application.CommentOperations.Commands.CreateComment;
using WebApi.Application.EnrollmentOperations.Commands.CreateEnrollment;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Application.PetOperations.Commands.CreatePet;
using WebApi.Application.PetOperations.Queries.PetCertificates;
using WebApi.Application.PetOperations.Queries.PetDetail;
using WebApi.Application.TrainingOperations.Commands.CreateTraining;
using WebApi.Application.TrainingOperations.Queries.GetComments;
using WebApi.Application.TrainingOperations.Queries.GetTrainingDetail;
using WebApi.Application.TrainingOperations.Queries.GetTrainingPets;
using WebApi.Application.TrainingOperations.Queries.GetTrainings;
using WebApi.Application.UserOperations.Queries.GetPets;
using WebApi.Application.UserOperations.Queries.UserDetail;
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
            CreateMap<Enrollment, TrainingPetViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Pet.Name))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Pet.Age))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Pet.Genre.Name))
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.Pet.User.Email));
            #endregion

            #region Auth Mappings
            CreateMap<RegisterModel, User>();
            #endregion

            #region Pet Mappings
            CreateMap<CreatePetModel, Pet>();
            CreateMap<Pet, UserPetViewModel>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name.ToString()));
            CreateMap<Pet, PetViewModel>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Certificate, PetCertificateViewModel>()
                .ForMember(dest => dest.GraduateDate, opt => opt.MapFrom(src => src.Date.ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.TrainingTitle, opt => opt.MapFrom(src => src.Training.Title))
                .ForMember(dest => dest.PetName, opt => opt.MapFrom(src => src.Pet.Name));
            #endregion

            #region User Mappings
            CreateMap<User, UserDetailViewModel>();
            #endregion

            #region Comment Mappings
            CreateMap<Comment, TrainingCommentViewModel>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => $"{src.User.Name} {src.User.Surname}"))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToString("dd/MM/yyyy")));
            CreateMap<CreateCommentModel, Comment>();
            #endregion
        }
    }
}
