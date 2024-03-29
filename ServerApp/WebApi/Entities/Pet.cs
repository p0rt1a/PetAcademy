﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    public class Pet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
