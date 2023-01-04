using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apifood.Database
{
    public class Cart
    {

        [Key]
        public int Cartid { get; set; }
        public int foodid { get; set; }
        public string foodname { get; set; }
        public int foodprice { get; set; }
        public string foodimghp { get; set; }
        public int customerid { get; set; }
        public int cartquantity { get; set; }
        public int Allprice { get; set; }
    }
}
