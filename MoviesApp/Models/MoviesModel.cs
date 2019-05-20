using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class MoviesModel
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string MoviePlot { get; set; }
        public string MoviePoster { get; set; }
        public DateTime MovieYear { get; set; }
        public ProducersModel Producer { get; set; }
        public string ProducerName { get; set; }
        public int ProducerId { get; set; }
        public List<ActorModel> Actors { get; set; }
    }
}
