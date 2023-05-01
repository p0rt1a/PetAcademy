﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Application.TrainingOperations.Commands.DeleteTraining
{
    public class DeleteTrainingCommand
    {
        private readonly IAcademyDbContext _dbContext;
        public int TrainingId { get; set; }

        public DeleteTrainingCommand(IAcademyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var training = _dbContext.Trainings.SingleOrDefault(x => x.Id == TrainingId);

            if (training is null)
                throw new InvalidOperationException("Silinecek eğitim bulunamadı");

            _dbContext.Trainings.Remove(training);
            _dbContext.SaveChanges();
        }
    }
}