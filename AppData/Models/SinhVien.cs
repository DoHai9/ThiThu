using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class SinhVien
    {
        public Guid? Id { get; set; }    
        [StringLength(10,ErrorMessage ="ten không quá 10 ký tự")]
        [Required]
        public string? Name { get; set; }
        [Range(1000,9999,ErrorMessage ="MaSV không quá 5 ký tự")]
        public int? MaSV { get; set; }
        [EmailAddress(ErrorMessage ="Sai Email")]
        public string? Email { get; set; }
        [Range(1990,2005, ErrorMessage ="năm sinh phải từ 1990 - 2005")]
        public int? NamSinh { get; set; }
        public bool TrangThai { get; set; }
    }
}
