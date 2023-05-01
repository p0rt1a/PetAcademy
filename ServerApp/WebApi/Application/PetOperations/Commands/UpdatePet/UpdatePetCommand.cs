using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Application.PetOperations.Commands.UpdatePet
{
    public class UpdatePetCommand
    {
        private readonly IAcademyDbContext _dbContext;
        private readonly IMapper _mapper;
        public UpdatePetModel Model { get; set; }
        public int PetId { get; set; }

        public UpdatePetCommand(IAcademyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Id == Model.UserId);

            if (user is null)
                throw new InvalidOperationException("Kullanıcı bulunamadı");

            //TODO: Create mapping and update pet
        }
    }

    public class UpdatePetModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
