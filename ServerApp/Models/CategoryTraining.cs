using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class CategoryTraining
    {
        public int Id { get; set; }
        public int TrainingId { get; set; }
        public int CategoryId { get; set; }
    }
}
