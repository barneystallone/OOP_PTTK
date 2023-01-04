using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apifood.Models
{
    public class ConmentModel
    {
        public int foodid { get; set; }
        public string foodname { get; set; }
        public string customername { get; set; }
        public string commentDescriptions { get; set; }
    }
}
