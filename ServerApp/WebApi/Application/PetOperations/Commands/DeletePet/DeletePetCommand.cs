using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Application.PetOperations.Commands.DeletePet
{
    public class DeletePetCommand
    {
        private readonly IAcademyDbContext _dbContext;
        public int PetId { get; set; }

        public DeletePetCommand(IAcademyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var pet = _dbContext.Pets.SingleOrDefault(x => x.Id == PetId);

            if (pet is null)
                throw new InvalidOperationException("Evcil hayvan bulunamadı!");

            _dbContext.Pets.Remove(pet);
            _dbContext.SaveChanges();
        }
    }
}
