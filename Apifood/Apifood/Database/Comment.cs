using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Apifood.Database
{
    public class Comment
    {
        [Key]
        public int commentid { get; set; }
        public int  foodid { get; set; }
        public string foodname { get; set; }
        public string customername { get; set; }
        public string commentDescriptions { get; set; }

    }
}
