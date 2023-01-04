using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apifood.Models
{
    public class BillModel
    {
        public string Customer { get; set; }
        public string Phonenumber { get; set; }
        public string Address { get; set; }
        public int customerid { get; set; }
        public int Status { get; set; }
    }
}
