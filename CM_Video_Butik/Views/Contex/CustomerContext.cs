using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CM_Video_Butik.Models;

namespace CM_Video_Butik.Views.Contex
{
    public class CustomerContext : DbContext
    {

        public DbSet<CustomerModel> CustomerDb { get; set; }


    }
}