﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.TrainingOperations.Queries.GetTrainings
{
    public class GetTrainingsQuery
    {
        private readonly IAcademyDbContext _dbContext;
        private readonly IMapper _mapper;
        public string Title { get; set; }
        public string City { get; set; }
        public string Genre { get; set; }

        public GetTrainingsQuery(IAcademyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<TrainingViewModel> Handle()
        {
            var trainings = _dbContext.Trainings
                .Include(x => x.Genre)
                .Include(x => x.Enrollments)
                .Where(x => x.IsActive)
                .ToList<Training>();

            if (Title != default)
                trainings = trainings.Where(x => x.Title.ToLower().Contains(Title.ToLower())).ToList<Training>();

            if (City != default)
                trainings = trainings.Where(x => x.City.ToLower().Contains(City.ToLower())).ToList<Training>();

            if (Genre != default)
                trainings = trainings.Where(x => x.Genre.Name.ToLower().Contains(Genre.ToLower())).ToList<Training>();

            var vm = _mapper.Map<List<TrainingViewModel>>(trainings);

            return vm;
        }
    }

    public class TrainingViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public bool IsFull { get; set; }
    }
}
