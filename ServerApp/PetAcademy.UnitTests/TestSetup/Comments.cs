using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace PetAcademy.UnitTests.TestSetup
{
    public static class Comments
    {
        public static void AddComments(this AcademyDbContext context)
        {
            context.Comments.AddRange(
                        new Comment()
                        {
                            Body = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Pariatur officia laudantium eius dignissimos laborum mollitia " +
                            "iusto animi laboriosam exercitationem inventore.",
                            Date = DateTime.Now.Date,
                            UserId = 2,
                            TrainingId = 1
                        },
                        new Comment()
                        {
                            Body = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Pariatur officia laudantium eius dignissimos laborum mollitia " +
                            "iusto animi laboriosam exercitationem inventore.",
                            Date = DateTime.Now.Date,
                            UserId = 2,
                            TrainingId = 2
                        },
                        new Comment()
                        {
                            Body = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Pariatur officia laudantium eius dignissimos laborum mollitia " +
                            "iusto animi laboriosam exercitationem inventore.",
                            Date = DateTime.Now.Date,
                            UserId = 1,
                            TrainingId = 2
                        },
                        new Comment()
                        {
                            Body = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Pariatur officia laudantium eius dignissimos laborum mollitia " +
                            "iusto animi laboriosam exercitationem inventore.",
                            Date = DateTime.Now.Date,
                            UserId = 1,
                            TrainingId = 1
                        }
                    );
        }
    }
}
