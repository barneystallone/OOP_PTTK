using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Apifood.Database
{
    public class About
    {
        [Key]
        public int Abouttid { get; set; }
        public string Abouttitle { get; set; }
        public string Aboutimg { get; set; }
        public string AboutDescriptions { get; set; }
    }
}
