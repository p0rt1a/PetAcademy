using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace PetAcademy.UnitTests.TestSetup
{
    public static class Users
    {
        public static void AddUsers(this AcademyDbContext context)
        {
            context.Users.AddRange(
                        new User()
                        {
                            Name = "Alperen",
                            Surname = "Polat",
                            Email = "alperen@hotmail.com",
                            Password = "Alperen.123",
                            BirthOfDate = new DateTime(1999, 07, 21)
                        },
                        new User()
                        {
                            Name = "Kerem",
                            Surname = "Yılmaz",
                            Email = "kerem@hotmail.com",
                            Password = "Kerem.123",
                            BirthOfDate = new DateTime(1999, 10, 13)
                        }
                    );
        }
    }
}
