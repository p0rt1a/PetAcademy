using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WebApi.Entities;

namespace WebApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new AcademyDbContext(serviceProvider.GetRequiredService<DbContextOptions<AcademyDbContext>>()))
            {
                if (context.Trainings.Any())
                    return;

                context.Trainings.AddRange(
                        new Training()
                        {
                            Title = "Tasmasız Yürüme Eğitimi",
                            Description = "Evcil hayvanınızla doğa yürüyüşlerini seviyor fakat bunu tasmasız yapmakta zorlanıyorsanız sizleri bu eğitimde buluşmak üzere bekliyoruz.",
                            City = "İzmir",
                            Address = "Karşıyaka",
                            Price = 1350,
                            GenreId = 1,
                            UserId = 1,
                            MaxPetCount = 3
                        },
                        new Training()
                        {
                            Title = "Oyun Eğitimi",
                            Description = "Evcil hayvanınızla birlikte geçirdiğiniz zamanın kalitesini artıracak oyunları ve birlikte oynamayı öğrenmek istiyorsanız bu eğitim tam size göre!",
                            City = "Ankara",
                            Address = "Çankaya",
                            Price = 2250,
                            GenreId = 1,
                            UserId = 2,
                            MaxPetCount = 1
                        },
                        new Training()
                        {
                            Title = "Tuvalet Eğitimi",
                            Description = "Sadece 1 haftada hamster kafesinizdeki kokudan ve hamster borularındaki dışkılardan kurtulmak istiyorsanız sizi böyle bekleriz!",
                            City = "Denizli",
                            Address = "Albayrak",
                            Price = 500,
                            GenreId = 7,
                            UserId = 2,
                            MaxPetCount = 1
                        },
                        new Training()
                        {
                            Title = "Tuvalet Eğitimi",
                            Description = "Evcil hayvan sahibi olmanın en zor bölümü kesinlikle tuvalet. Bu eğitim sayesinde evcil hayvanınız ortalığı pisletmeyecek ve temiz bir şekilde işini görmeyi öğrenecek.",
                            City = "İzmir",
                            Address = "Alsancak",
                            Price = 3750,
                            GenreId = 1,
                            UserId = 2,
                            MaxPetCount = 3
                        },
                        new Training()
                        {
                            Title = "Komut Eğitimi",
                            Description = "Bu eğitim, evcil hayvanınızla aranızdaki iletişimi güçlendirecek ve beraber daha keyifli vakit geçirmenizi sağlayacak!",
                            City = "Ankara",
                            Address = "Şeyhşamil",
                            Price = 1000,
                            GenreId = 1,
                            UserId = 1,
                            MaxPetCount = 8
                        },
                        new Training()
                        {
                            Title = "Saldırganlık Eğitimi",
                            Description = "Evcil hayvanınızın saldırganlık göstermesi gayet doğal ve eğitilebilir bir durumdur. Bu eğitim sayesinde bunu 2 hafta gibi bir sürede kontrol altına alabiliriz.",
                            City = "İstanbul",
                            Address = "Çekmeköy",
                            Price = 7000,
                            GenreId = 2,
                            UserId = 1,
                            MaxPetCount = 5
                        },
                        new Training()
                        {
                            Title = "Tasmasız Yürüme Eğitimi",
                            Description = "Evcil hayvanınızla doğa yürüyüşlerini seviyor fakat bunu tasmasız yapmakta zorlanıyorsanız sizleri bu eğitimde buluşmak üzere bekliyoruz.",
                            City = "İzmir",
                            Address = "Karşıyaka",
                            Price = 1350,
                            GenreId = 1,
                            UserId = 2,
                            MaxPetCount = 2
                        },
                        new Training()
                        {
                            Title = "Oyun Eğitimi",
                            Description = "Evcil hayvanınızla birlikte geçirdiğiniz zamanın kalitesini artıracak oyunları ve birlikte oynamayı öğrenmek istiyorsanız bu eğitim tam size göre!",
                            City = "Ankara",
                            Address = "Çankaya",
                            Price = 2250,
                            GenreId = 1,
                            UserId = 1,
                            MaxPetCount = 2
                        },
                        new Training()
                        {
                            Title = "Tuvalet Eğitimi",
                            Description = "Sadece 1 haftada hamster kafesinizdeki kokudan ve hamster borularındaki dışkılardan kurtulmak istiyorsanız sizi böyle bekleriz!",
                            City = "Denizli",
                            Address = "Albayrak",
                            Price = 500,
                            GenreId = 7,
                            UserId = 1,
                            MaxPetCount = 2
                        },
                        new Training()
                        {
                            Title = "Tuvalet Eğitimi",
                            Description = "Evcil hayvan sahibi olmanın en zor bölümü kesinlikle tuvalet. Bu eğitim sayesinde evcil hayvanınız ortalığı pisletmeyecek ve temiz bir şekilde işini görmeyi öğrenecek.",
                            City = "İzmir",
                            Address = "Alsancak",
                            Price = 3750,
                            GenreId = 1,
                            UserId = 1,
                            MaxPetCount = 12
                        },
                        new Training()
                        {
                            Title = "Komut Eğitimi",
                            Description = "Bu eğitim, evcil hayvanınızla aranızdaki iletişimi güçlendirecek ve beraber daha keyifli vakit geçirmenizi sağlayacak!",
                            City = "Ankara",
                            Address = "Şeyhşamil",
                            Price = 1000,
                            GenreId = 1,
                            UserId = 3,
                            MaxPetCount = 6
                        },
                        new Training()
                        {
                            Title = "Saldırganlık Eğitimi",
                            Description = "Evcil hayvanınızın saldırganlık göstermesi gayet doğal ve eğitilebilir bir durumdur. Bu eğitim sayesinde bunu 2 hafta gibi bir sürede kontrol altına alabiliriz.",
                            City = "İstanbul",
                            Address = "Çekmeköy",
                            Price = 7000,
                            GenreId = 2,
                            UserId = 3,
                            MaxPetCount = 5
                        },
                        new Training()
                        {
                            Title = "Komut Eğitimi",
                            Description = "Bu eğitim, evcil hayvanınızla aranızdaki iletişimi güçlendirecek ve beraber daha keyifli vakit geçirmenizi sağlayacak!",
                            City = "İstanbul",
                            Address = "Çekmeköy",
                            Price = 7000,
                            GenreId = 1,
                            UserId = 3,
                            MaxPetCount = 5
                        }
                    );

                context.Genres.AddRange(
                        new Genre()
                        {
                            Name = "Köpek"
                        },  //Köpek
                        new Genre()
                        {
                            Name = "Kedi"
                        },  //Kedi
                        new Genre()
                        {
                            Name = "At"
                        },  //At
                        new Genre()
                        {
                            Name = "Muhabbet Kuşu"
                        },  //Muhabbet Kuşu
                        new Genre()
                        {
                            Name = "Papağan"
                        },  //Papağan
                        new Genre()
                        {
                            Name = "Civciv"
                        },  //Civciv
                        new Genre()
                        {
                            Name = "Hamster"
                        },  //Hamster
                        new Genre()
                        {
                            Name = "Tavşan"
                        }   //Tavşan
                    );

                context.Pets.AddRange(
                        new Pet()
                        {
                            Name = "Huysuz",
                            Age = 2,
                            GenreId = 1,
                            UserId = 1
                        },
                        new Pet()
                        {
                            Name = "Bonjour",
                            Age = 1,
                            GenreId = 2,
                            UserId = 2
                        },
                        new Pet()
                        {
                            Name = "Tekir",
                            Age = 3,
                            GenreId = 2,
                            UserId = 1
                        },
                        new Pet()
                        {
                            Name = "Lokum",
                            Age = 3,
                            GenreId = 1,
                            UserId = 1
                        },
                        new Pet()
                        {
                            Name = "Limon",
                            Age = 3,
                            GenreId = 4,
                            UserId = 2
                        },
                        new Pet()
                        {
                            Name = "Pamuk",
                            Age = 2,
                            GenreId = 8,
                            UserId = 2
                        },
                        new Pet()
                        {
                            Name = "Helva",
                            Age = 2,
                            GenreId = 1,
                            UserId = 2
                        },
                        new Pet()
                        {
                            Name = "Fındık",
                            Age = 2,
                            GenreId = 7,
                            UserId = 3
                        },
                        new Pet()
                        {
                            Name = "Mestan",
                            Age = 2,
                            GenreId = 2,
                            UserId = 3
                        },
                        new Pet()
                        {
                            Name = "Karabaş",
                            Age = 2,
                            GenreId = 1,
                            UserId = 3
                        }
                    );

                context.Enrollments.AddRange(
                        new Enrollment()
                        {
                            TrainingId = 1,
                            PetId = 7
                        },
                        new Enrollment()
                        {
                            TrainingId = 1,
                            PetId = 4
                        },
                        new Enrollment()
                        {
                            TrainingId = 1,
                            PetId = 10
                        },
                        new Enrollment()
                        {
                            TrainingId = 2,
                            PetId = 7
                        },
                        new Enrollment()
                        {
                            TrainingId = 7,
                            PetId = 7
                        },
                        new Enrollment()
                        {
                            TrainingId = 8,
                            PetId = 10
                        },
                        new Enrollment()
                        {
                            TrainingId = 5,
                            PetId = 7
                        },
                        new Enrollment()
                        {
                            TrainingId = 4,
                            PetId = 7
                        },
                        new Enrollment()
                        {
                            TrainingId = 12,
                            PetId = 9
                        },
                        new Enrollment()
                        {
                            TrainingId = 6,
                            PetId = 3
                        },
                        new Enrollment()
                        {
                            TrainingId = 12,
                            PetId = 9
                        }
                    );

                context.Users.AddRange(
                        new User()
                        {
                            Image = "user_1.jpg",
                            Name = "Alperen",
                            Surname = "Polat",
                            Email = "alperen@hotmail.com",
                            Password = "Alperen.123",
                            BirthOfDate = new DateTime(1999, 07, 21)
                        },
                        new User()
                        {
                            Image = "user_2.jpg",
                            Name = "Kerem",
                            Surname = "Yılmaz",
                            Email = "kerem@hotmail.com",
                            Password = "Kerem.123",
                            BirthOfDate = new DateTime(1980, 10, 13)
                        },
                        new User()
                        {
                            Image = "user_3.jpg",
                            Name = "Hilal",
                            Surname = "Yıldız",
                            Email = "hilal@hotmail.com",
                            Password = "Hilal.123",
                            BirthOfDate = new DateTime(1999, 10, 13)
                        },
                        new User()
                        {
                            Image = "user_4.jpg",
                            Name = "Ahmet",
                            Surname = "Sabahat",
                            Email = "ahmet@hotmail.com",
                            Password = "Ahmet.123",
                            BirthOfDate = new DateTime(1999, 07, 21)
                        },
                        new User()
                        {
                            Image = "user_5.jpg",
                            Name = "Ayşe",
                            Surname = "Tokat",
                            Email = "ayse@hotmail.com",
                            Password = "Ayse.123",
                            BirthOfDate = new DateTime(1999, 07, 21)
                        },
                        new User()
                        {
                            Image = "user_6.jpg",
                            Name = "Selahattin",
                            Surname = "Durak",
                            Email = "selo@hotmail.com",
                            Password = "Selahattin.123",
                            BirthOfDate = new DateTime(1999, 07, 21)
                        },
                        new User()
                        {
                            Image = "user_7.jpg",
                            Name = "Zeynep",
                            Surname = "Say",
                            Email = "zeynep@hotmail.com",
                            Password = "Zeynep.123",
                            BirthOfDate = new DateTime(1999, 10, 13)
                        },
                        new User()
                        {
                            Image = "user_8.jpg",
                            Name = "Fazıl",
                            Surname = "Küs",
                            Email = "fazil@hotmail.com",
                            Password = "Fazıl.123",
                            BirthOfDate = new DateTime(1999, 07, 21)
                        },
                        new User()
                        {
                            Image = "user_9.jpg",
                            Name = "Hasan",
                            Surname = "Çal",
                            Email = "hasan@hotmail.com",
                            Password = "Hasan.123",
                            BirthOfDate = new DateTime(1999, 10, 13)
                        }
                    );

                context.Comments.AddRange(
                        new Comment()
                        {
                            Body = "Çok faydalı bir eğitim oldu, eğitmen çok ilgiliydi, bizimle sürekli ilgilendi ve maillerimize çok hızlı şekilde dönüş sağladı. Alanında gerçekten profesyonel ve tavsiyelerinden çok memnun kaldık. Umarım daha fazla eğitim hizmeti sunar ve onlardan da başarıyla mezun olabiliriz :). Eğitmenimize ve PetAcademy'e teşekkür ederiz.",
                            Date = DateTime.Now.Date,
                            UserId = 4,
                            TrainingId = 1
                        },
                        new Comment()
                        {
                            Body = "Çok faydalı bir eğitim oldu, eğitmen çok ilgiliydi, bizimle sürekli ilgilendi ve maillerimize çok hızlı şekilde dönüş sağladı. Alanında gerçekten profesyonel ve tavsiyelerinden çok memnun kaldık. Umarım daha fazla eğitim hizmeti sunar ve onlardan da başarıyla mezun olabiliriz :). Eğitmenimize ve PetAcademy'e teşekkür ederiz.",
                            Date = DateTime.Now.Date,
                            UserId = 4,
                            TrainingId = 2
                        },
                        new Comment()
                        {
                            Body = "Çok faydalı bir eğitim oldu, eğitmen çok ilgiliydi, bizimle sürekli ilgilendi ve maillerimize çok hızlı şekilde dönüş sağladı. Alanında gerçekten profesyonel ve tavsiyelerinden çok memnun kaldık. Umarım daha fazla eğitim hizmeti sunar ve onlardan da başarıyla mezun olabiliriz :). Eğitmenimize ve PetAcademy'e teşekkür ederiz.",
                            Date = DateTime.Now.Date,
                            UserId = 4,
                            TrainingId = 3
                        },
                        new Comment()
                        {
                            Body = "Çok faydalı bir eğitim oldu, eğitmen çok ilgiliydi, bizimle sürekli ilgilendi ve maillerimize çok hızlı şekilde dönüş sağladı. Alanında gerçekten profesyonel ve tavsiyelerinden çok memnun kaldık. Umarım daha fazla eğitim hizmeti sunar ve onlardan da başarıyla mezun olabiliriz :). Eğitmenimize ve PetAcademy'e teşekkür ederiz.",
                            Date = DateTime.Now.Date,
                            UserId = 4,
                            TrainingId = 4
                        },
                        new Comment()
                        {
                            Body = "Çok faydalı bir eğitim oldu, eğitmen çok ilgiliydi, bizimle sürekli ilgilendi ve maillerimize çok hızlı şekilde dönüş sağladı. Alanında gerçekten profesyonel ve tavsiyelerinden çok memnun kaldık. Umarım daha fazla eğitim hizmeti sunar ve onlardan da başarıyla mezun olabiliriz :). Eğitmenimize ve PetAcademy'e teşekkür ederiz.",
                            Date = DateTime.Now.Date,
                            UserId = 4,
                            TrainingId = 5
                        },
                        new Comment()
                        {
                            Body = "Çok faydalı bir eğitim oldu, eğitmen çok ilgiliydi, bizimle sürekli ilgilendi ve maillerimize çok hızlı şekilde dönüş sağladı. Alanında gerçekten profesyonel ve tavsiyelerinden çok memnun kaldık. Umarım daha fazla eğitim hizmeti sunar ve onlardan da başarıyla mezun olabiliriz :). Eğitmenimize ve PetAcademy'e teşekkür ederiz.",
                            Date = DateTime.Now.Date,
                            UserId = 4,
                            TrainingId = 6
                        },
                        new Comment()
                        {
                            Body = "Çok faydalı bir eğitim oldu, eğitmen çok ilgiliydi, bizimle sürekli ilgilendi ve maillerimize çok hızlı şekilde dönüş sağladı. Alanında gerçekten profesyonel ve tavsiyelerinden çok memnun kaldık. Umarım daha fazla eğitim hizmeti sunar ve onlardan da başarıyla mezun olabiliriz :). Eğitmenimize ve PetAcademy'e teşekkür ederiz.",
                            Date = DateTime.Now.Date,
                            UserId = 4,
                            TrainingId = 7
                        },
                        new Comment()
                        {
                            Body = "Çok faydalı bir eğitim oldu, eğitmen çok ilgiliydi, bizimle sürekli ilgilendi ve maillerimize çok hızlı şekilde dönüş sağladı. Alanında gerçekten profesyonel ve tavsiyelerinden çok memnun kaldık. Umarım daha fazla eğitim hizmeti sunar ve onlardan da başarıyla mezun olabiliriz :). Eğitmenimize ve PetAcademy'e teşekkür ederiz.",
                            Date = DateTime.Now.Date,
                            UserId = 4,
                            TrainingId = 8
                        },
                        new Comment()
                        {
                            Body = "Hocamız çok ilgiliydi. Eğitim içeriği muhteşem ve çok uzun sürmüyor. Ücreti de oldukça makul geldi. Eğitimden memnun kaldık teşekkür ederiz.",
                            Date = DateTime.Now.Date,
                            UserId = 6,
                            TrainingId = 1
                        },
                        new Comment()
                        {
                            Body = "Hocamız çok ilgiliydi. Eğitim içeriği muhteşem ve çok uzun sürmüyor. Ücreti de oldukça makul geldi. Eğitimden memnun kaldık teşekkür ederiz.",
                            Date = DateTime.Now.Date,
                            UserId = 6,
                            TrainingId = 2
                        },
                        new Comment()
                        {
                            Body = "Hocamız çok ilgiliydi. Eğitim içeriği muhteşem ve çok uzun sürmüyor. Ücreti de oldukça makul geldi. Eğitimden memnun kaldık teşekkür ederiz.",
                            Date = DateTime.Now.Date,
                            UserId = 6,
                            TrainingId = 3
                        },
                        new Comment()
                        {
                            Body = "Hocamız çok ilgiliydi. Eğitim içeriği muhteşem ve çok uzun sürmüyor. Ücreti de oldukça makul geldi. Eğitimden memnun kaldık teşekkür ederiz.",
                            Date = DateTime.Now.Date,
                            UserId = 6,
                            TrainingId = 4
                        },
                        new Comment()
                        {
                            Body = "Hocamız çok ilgiliydi. Eğitim içeriği muhteşem ve çok uzun sürmüyor. Ücreti de oldukça makul geldi. Eğitimden memnun kaldık teşekkür ederiz.",
                            Date = DateTime.Now.Date,
                            UserId = 6,
                            TrainingId = 5
                        },
                        new Comment()
                        {
                            Body = "Hocamız çok ilgiliydi. Eğitim içeriği muhteşem ve çok uzun sürmüyor. Ücreti de oldukça makul geldi. Eğitimden memnun kaldık teşekkür ederiz.",
                            Date = DateTime.Now.Date,
                            UserId = 6,
                            TrainingId = 6
                        },
                        new Comment()
                        {
                            Body = "Hocamız çok ilgiliydi. Eğitim içeriği muhteşem ve çok uzun sürmüyor. Ücreti de oldukça makul geldi. Eğitimden memnun kaldık teşekkür ederiz.",
                            Date = DateTime.Now.Date,
                            UserId = 6,
                            TrainingId = 7
                        },
                        new Comment()
                        {
                            Body = "Hocamız çok ilgiliydi. Eğitim içeriği muhteşem ve çok uzun sürmüyor. Ücreti de oldukça makul geldi. Eğitimden memnun kaldık teşekkür ederiz.",
                            Date = DateTime.Now.Date,
                            UserId = 6,
                            TrainingId = 8
                        },
                        new Comment()
                        {
                            Body = "Pek memnun kalmadım. Eğitim bittikten sonrasında evcil hayvanım eski haline geri döndü. Sürekli eğitime para veremem, tavsiye etmiyorum.",
                            Date = DateTime.Now.Date,
                            UserId = 3,
                            TrainingId = 1
                        },
                        new Comment()
                        {
                            Body = "Pek memnun kalmadım. Eğitim bittikten sonrasında evcil hayvanım eski haline geri döndü. Sürekli eğitime para veremem, tavsiye etmiyorum.",
                            Date = DateTime.Now.Date,
                            UserId = 3,
                            TrainingId = 2
                        },
                        new Comment()
                        {
                            Body = "Pek memnun kalmadım. Eğitim bittikten sonrasında evcil hayvanım eski haline geri döndü. Sürekli eğitime para veremem, tavsiye etmiyorum.",
                            Date = DateTime.Now.Date,
                            UserId = 3,
                            TrainingId = 3
                        },
                        new Comment()
                        {
                            Body = "Pek memnun kalmadım. Eğitim bittikten sonrasında evcil hayvanım eski haline geri döndü. Sürekli eğitime para veremem, tavsiye etmiyorum.",
                            Date = DateTime.Now.Date,
                            UserId = 3,
                            TrainingId = 4
                        },
                        new Comment()
                        {
                            Body = "Pek memnun kalmadım. Eğitim bittikten sonrasında evcil hayvanım eski haline geri döndü. Sürekli eğitime para veremem, tavsiye etmiyorum.",
                            Date = DateTime.Now.Date,
                            UserId = 3,
                            TrainingId = 5
                        },
                        new Comment()
                        {
                            Body = "Pek memnun kalmadım. Eğitim bittikten sonrasında evcil hayvanım eski haline geri döndü. Sürekli eğitime para veremem, tavsiye etmiyorum.",
                            Date = DateTime.Now.Date,
                            UserId = 3,
                            TrainingId = 6
                        },
                        new Comment()
                        {
                            Body = "Pek memnun kalmadım. Eğitim bittikten sonrasında evcil hayvanım eski haline geri döndü. Sürekli eğitime para veremem, tavsiye etmiyorum.",
                            Date = DateTime.Now.Date,
                            UserId = 3,
                            TrainingId = 7
                        },
                        new Comment()
                        {
                            Body = "Pek memnun kalmadım. Eğitim bittikten sonrasında evcil hayvanım eski haline geri döndü. Sürekli eğitime para veremem, tavsiye etmiyorum.",
                            Date = DateTime.Now.Date,
                            UserId = 3,
                            TrainingId = 8
                        }
                    );

                context.Certificates.AddRange(
                        new Certificate()
                        {
                            PetId = 1,
                            TrainingId = 1,
                            Date = DateTime.Now.Date
                        },
                        new Certificate()
                        {
                            PetId = 1,
                            TrainingId = 11,
                            Date = DateTime.Now.Date
                        },
                        new Certificate()
                        {
                            PetId = 2,
                            TrainingId = 12,
                            Date = DateTime.Now.Date
                        },
                        new Certificate()
                        {
                            PetId = 1,
                            TrainingId = 10,
                            Date = DateTime.Now.Date
                        }
                    );

                context.SaveChanges();
            }
        }
    }
}
