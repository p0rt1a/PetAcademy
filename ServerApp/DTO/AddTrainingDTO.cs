using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.DTO
{
    //data transfer object
    public class AddTrainingDTO
    {
        public Training training { get; set; }
        public int[] categoryIndexes { get; set; }
    }
}
