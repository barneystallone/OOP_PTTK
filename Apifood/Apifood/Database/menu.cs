using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backendtexxt.Database
{
    public class menu
    {
        [Key]
        public int menuid { get; set; }
        public string menuname { get; set; }
        public string menuavata { get; set; }
    }
}
