using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.DTO
{
    public class LoginUserReturnDTO
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public bool IsTrainer { get; set; }
    }
}
