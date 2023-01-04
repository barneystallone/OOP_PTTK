using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Apifood.Database
{
    public class Slider
    {
        [Key]
        public int slideid { get; set; }
        public string slidetitle { get; set; }
        public string slidedescription { get; set; }
        public string slideimg { get; set; }
        public int slideActive { get; set; }
        public int slidetype { get; set; }
    }
}
