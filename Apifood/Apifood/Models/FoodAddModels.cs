using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Apifood.Models
{
    public class FoodAddModels
    {
        [Required(ErrorMessage = "Vui lòng nhập tên Món ăn")]
        public string foodname { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên Danh mục")]
        public int menuid { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập giá")]
        public int foodprice { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập hình ảnh")]
        public string foodimghp { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập hình ảnh 1")]
        public string foodimg1 { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập hình ảnh 2")]
        public string foodimg2 { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập hình ảnh 3")]
        public string foodimg3 { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập hình ảnh 4")]
        public string foodimg4 { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Mô tả")]
        public string foodDescriptions { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tình trạng")]
        public int foodInStock { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập loại")]
        public int typefood { get; set; }

    }
}
