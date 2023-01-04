using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Apifood.Database
{
    public class BillDetail
    {
        [Key]
        public int BiDid { get; set; }
        public string foodname { get; set; }
        public int foodprice { get; set; }
        public int Quantity { get; set; }
        public int BillId { get; set; }
        public int Allprice { get; set; }

    }
}
