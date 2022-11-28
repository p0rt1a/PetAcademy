using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public bool IsTrainer { get; set; }
    }
}
