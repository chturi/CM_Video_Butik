﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CM_Video_Butik.Models
{

    //Model for videos which can be rented
    public class MovieModels
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity),Key]
        public int MovieID { get; set; }
       
        public string Title { get; set; } = "";
        public string Genre { get; set; } = "";
        public int QuantityTotalStock { get; set; } = 0;
        public int QuantityRented { get; set; } = 0;
       


    }
}