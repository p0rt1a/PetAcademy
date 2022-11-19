using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class TrainingCategory
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int TrainingId { get; set; }
        public Training Training { get; set; }
    }
}
