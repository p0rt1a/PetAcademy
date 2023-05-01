using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.PetOperations.Commands.CreatePet
{
    public class CreatePetCommand
    {
        private readonly IAcademyDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreatePetModel Model { get; set; }

        public CreatePetCommand(IAcademyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Id == Model.UserId);

            if (user is null)
                throw new InvalidOperationException("Kullanıcı mevcut değil");

            var genre = _dbContext.Genres.SingleOrDefault(x => x.Id == Model.GenreId);

            if (genre is null)
                throw new InvalidOperationException("Tür mevcut değil");

            var pet = _mapper.Map<Pet>(Model);

            _dbContext.Pets.Add(pet);
            _dbContext.SaveChanges();
        }
    }

    public class CreatePetModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int GenreId { get; set; }
        public int UserId { get; set; }
    }
}
