using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace CM_Video_Butik.Models
{
    public class CustomerMoviesModell
    {
        [Key]
        public string CusMovID { get; set; }
        public string Title { get; set; } = "";
        public string Genre { get; set; } = "";
        public int Quantity { get; set; } = 0;


    }
}