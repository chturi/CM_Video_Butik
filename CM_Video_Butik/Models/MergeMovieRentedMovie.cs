using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CM_Video_Butik.Models
{
    public class MergeMovieRentedMovie {
        public List<MovieModels> MoviesList { get; set; } = new List<MovieModels>();
        public List<CustomerMoviesModell> RentedMovieList { get; set; } = new List<CustomerMoviesModell>();

    }
            



}
