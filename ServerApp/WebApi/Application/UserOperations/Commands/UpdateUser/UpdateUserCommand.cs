using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.IO;
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
            user.Image = string.IsNullOrEmpty(Model.Image.Trim()) ? user.Image : SaveAndReturnImage();

            _dbContext.SaveChanges();
        }

        public string SaveAndReturnImage()
        {
            string localPath = "Images";
            string imageName = $"user_{UserId}.jpg";
            string localFilePath = Path.Combine(localPath, imageName);

            var base64string = Model.Image;
            byte[] imageBytes = Convert.FromBase64String(base64string);

            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                using (FileStream fs = new FileStream(localFilePath, FileMode.Create))
                {
                    ms.CopyTo(fs);
                }
            }

            return imageName;
        }
    }

    public class UpdateUserModel
    {
        public string Image { get; set; }
        public string Email { get; set; }
    }
}
