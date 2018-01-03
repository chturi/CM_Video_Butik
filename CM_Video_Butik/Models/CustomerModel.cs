using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CM_Video_Butik.Models
{

    
    public class CustomerModel
    {
        //Model for all costumers
        [Key]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public int QuantityOfMovies { get; set; } = 0;
        public List<MovieModels> RentedMovies { get; set; }



    }


  

}