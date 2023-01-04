using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Apifood.Database
{
    public class food
    {

        [Key]
        public int foodid { get; set; }
        public string foodname { get; set; }
        public int menuid { get; set; }
        public int foodprice { get; set; }
        public string foodimghp { get; set; }
        public string foodimg1 { get; set; }
        public string foodimg2 { get; set; }
        public string foodimg3 { get; set; }
        public string foodimg4 { get; set; }
        public string foodDescriptions { get; set; }
        public int foodInStock { get; set; }
        public int typefood { get; set; }
    }
}
