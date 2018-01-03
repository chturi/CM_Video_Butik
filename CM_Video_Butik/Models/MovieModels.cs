using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CM_Video_Butik.Models
{

    //Model for videos which can be rented
    public class MovieModels
    {
        [Key]
        public string Title { get; set; }
        public string Genre { get; set; }
        public int QuantityTotalStock { get; set; }
        public int QuantityRented { get; set; }

    }
}