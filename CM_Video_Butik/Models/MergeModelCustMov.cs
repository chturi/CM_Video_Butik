using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CM_Video_Butik.Models
{
    public class MergeModelCustMov
    {
        public List<CustomerMoviesModell> CustMoviesList { get; set; } = new List<CustomerMoviesModell>();
        public CustomerModel Customers { get; set; }
    }
}