using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CM_Video_Butik.Models
{

    
    public class CustomerModel
    {
        //Model data for all costumers
        [Key]
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int QuantityOfMovies { get; set; } = 0;
        


        //Using framework feature to generate unique increment value for each cosutomer created.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; } = 0;




    }


  

}