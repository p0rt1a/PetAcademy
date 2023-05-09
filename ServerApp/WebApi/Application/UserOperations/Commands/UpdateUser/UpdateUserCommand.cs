using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Application.UserOperations.Commands.UpdateUser
{
    public class UpdateUserCommand
    {
        private readonly IAcademyDbContext _dbContext;
        public UpdateUserModel Model { get; set; }
        public int UserId { get; set; }

        public UpdateUserCommand(IAcademyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Id == UserId);

            if (user is null)
                throw new InvalidOperationException("Kullanıcı bulunamadı");

            user.Email = string.IsNullOrEmpty(Model.Email.Trim()) ? user.Email : Model.Email;

            _dbContext.SaveChanges();
        }
    }

    public class UpdateUserModel
    {
        public string Email { get; set; }
    }
}
