using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIproject.Models
{
    public class usr_in_dys
    {
        [Key]
        public int trip_id { get; set; }
        public DateTime strt_day { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime end_day { get; set; }
        public int no_of_days { get; set; }

        public ICollection<usr_in_cty> city { get; set; }
    }

    public class usr_in_cty   // Class name is same as Table Name in DB. 
    {
        [Key]
        public int usr_in_cty_id { get; set; }       
        public string cty_nm { get; set; }
        public int trip_id { get; set; }

        //Foreign key for Usr_in_dys to trp_id
        [ForeignKey("trip_id")]       
        public usr_in_dys days { get; set;  }
       
    }

}
