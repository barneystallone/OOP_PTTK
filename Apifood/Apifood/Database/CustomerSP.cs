using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Apifood.Database
{
    public class CustomerSP
    {
        
        [Key]
        public int customerSPid { get; set; }
        public string customerSPname { get; set; }
        public string customerSPemail { get; set; }
        public string customerSPDescriptions { get; set; }
    }

}

