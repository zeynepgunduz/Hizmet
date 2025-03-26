using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hizmet.Core.Entities
{
     public  class Service
    {
        public int Id { get; set; }
       [DisplayName("Hizmet Adı")]
        [Required(ErrorMessage = "Hizmet Adı Boş Geçilemez")]
        public string  Name { get; set; }
        [DisplayName("Hizmet Fiyatı")]
        public decimal Price { get; set; }
        [DisplayName("Aktif Mi?")]
        public bool IsActive { get; set; }
        [DisplayName("Bölüm")]
        [Required(ErrorMessage = "Bölüm Seçiniz")]
        [Range(1, int.MaxValue, ErrorMessage = "Bölüm Seçiniz")]
        public int DepartmantId { get; set; }
        public Departmant? Departmant { get; set; }
        public List<Employee>? Employees { get; set; }
    }
}
