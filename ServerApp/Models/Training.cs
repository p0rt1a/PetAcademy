using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class Training
    {
        public int Id { get; set; }
        public int TrainerId { get; set; }
        public string Header { get; set; }
        public string Level { get; set; }
        public string VideoUrl { get; set; }
        public string Description { get; set; }
    }
}
