using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.TrainingOperations.Commands.UpdateTraining
{
    public class UpdateTrainingCommand
    {
        private readonly IAcademyDbContext _dbContext;
        public int TrainingId { get; set; }
        public UpdateTrainingModel Model { get; set; }

        public UpdateTrainingCommand(IAcademyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var training = _dbContext.Trainings.SingleOrDefault(x => x.Id == TrainingId);

            if (training is null)
                throw new InvalidOperationException("Güncellenecek eğitim bulunamadı");

            training.Description = string.IsNullOrEmpty(Model.Description.Trim()) ? training.Description : Model.Description;
            training.Price = Model.Price > 0 ? Model.Price : training.Price;
            training.MaxPetCount = Model.MaxPetCount > 0 ? Model.MaxPetCount : training.MaxPetCount;

            _dbContext.SaveChanges();
        }
    }

    public class UpdateTrainingModel
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int MaxPetCount { get; set; }
    }
}
