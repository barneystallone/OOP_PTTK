using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Apifood.Database
{
    public class New
    {
        [Key]
        public int newsid { get; set; }
        public string newsname { get; set; }
        public string newsavata { get; set; }
        public string Descriptions { get; set; }
    }
}
