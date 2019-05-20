
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class ActorModel
    {
        public int ActorId { get; set; }
        public string ActorName { get; set; }
        public string ActorBio { get; set; }
        public DateTime ActorDOB { get; set; }
        public string ActorSex { get; set; }
    }
}
