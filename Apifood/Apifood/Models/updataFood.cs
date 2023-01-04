using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Apifood.Models
{
    public class updataFood
    {
        public int foodid { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm")]
        public string foodname { get; set; }
        public int menuyid { get; set; }
        public int foodprice { get; set; }
        public string foodavata { get; set; }
        public string foodDescriptions { get; set; }
        public int foodInStock { get; set; }
    }
}
