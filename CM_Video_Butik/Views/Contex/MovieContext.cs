using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CM_Video_Butik.Models;

namespace CM_Video_Butik.Views.Contex
{
    public class MovieContext : DbContext
    {

        public DbSet<MovieModels> Movies { get; set; }


    }




}