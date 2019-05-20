using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class ProducersModel
    {
        public int ProducerId { get; set; }
        public string ProducerName { get; set; }
        public string ProducerSex { get; set; }
        public string ProducerBio { get; set; }
        public DateTime ProducerDOB { get; set; }
    }
}
