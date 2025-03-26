using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hizmet.Core.Entities
{
    public class Departmant

    {
        public int Id { get; set; }
        [DisplayName("Departman")]
        [Required(ErrorMessage = "Departman Adı Boş Geçilemez")]
        public string? Name { get; set; }
        [DisplayName("Aktif Mi?")]
        public bool IsActive { get; set; }
        [DisplayName("Üst Departman Mı?")]
        public bool IsTopDepartmant { get; set; }
        [DisplayName("Üst Departman")]
        public int? ParentId { get; set; }
        public List<Employee>? Employees { get; set; }
        public List <Service>? Services { get; set; }
    }
}
