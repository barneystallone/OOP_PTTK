using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Apifood.Models
{
    public class Addcustomer
    {
        [Required(ErrorMessage = "Vui lòng nhập Tên")]
        public string customername { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Email")]
        public string customeremail { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập SDT")]
        public string customernuber { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Password")]
        public string customerpassword { get; set; }
    }
}
