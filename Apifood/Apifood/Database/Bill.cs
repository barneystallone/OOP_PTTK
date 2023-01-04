using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Apifood.Database
{
    public class Bill
    {
        [Key]
        public int BillId { get; set; }
        public string Customer { get; set; }
        public string Phonenumber { get; set; }
        public string Address { get; set; }
        public int customerid { get; set; }
        public Bill()
        {
            DayOrder = DateTime.Now;
        }
        public DateTime? DayOrder { get; set; }
        public int Status { get; set; }

    }
}
