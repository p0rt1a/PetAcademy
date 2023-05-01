﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Application.TrainingOperations.Queries.GetTrainings;
using WebApi.Entities;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Training Mappings
            CreateMap<Training, TrainingViewModel>();
            #endregion
        }
    }
}
