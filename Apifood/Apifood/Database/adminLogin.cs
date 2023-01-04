using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Apifood.Database
{
    public class adminLogin
    {
        [Key]
        public int adminid { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
