using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Model
{
    [Table("Categories")]
    public class Categories
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên loại sản phẩm không được để trống")]
        [Display(Name = "Tên loại sản phẩm")]
        public string Name { get; set; }

        public string Slug { get; set; }

        [Display(Name = "Cấp cha")]
        public int ParentID { get; set; }

        [Display(Name = "Sắp xếp")]
        public int? Order { get; set; }

        [Required(ErrorMessage = "Phần mô tả không được để trống")]
        [Display(Name = "Mô tả")]
        public string MetaDesc { get; set; }

        [Required(ErrorMessage = "Phần từ khóa không được để trống")]
        [Display(Name = "Từ khóa")]
        public string MetaKey { get; set; }

        public DateTime CreateAt { get; set; }

        public int CreateBy { get; set; }

        public DateTime UpdateAt { get; set; }

        public int UpdateBy { get; set; }

        [Display(Name = "Trạng thái")]
        public int Status { get; set; }

    }
}
