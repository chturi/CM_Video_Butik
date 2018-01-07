using CM_Video_Butik.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CM_Video_Butik.Views.Contex
{
    public class CustMovContext : DbContext
    {
        public DbSet<CustomerMoviesModell> CustMovdb { get; set; }
    }
}