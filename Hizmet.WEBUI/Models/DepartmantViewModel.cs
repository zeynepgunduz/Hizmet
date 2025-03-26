using Hizmet.Core.Entities;
using System.ComponentModel;

namespace Hizmet.WEBUI.Models
{
    public class DepartmantViewModel
    {
        public int Id { get; set; }
        [DisplayName("Departman")]

        public string? Name { get; set; }
        [DisplayName("Aktif Mi?")]
        public bool IsActive { get; set; }
        [DisplayName("Üst Departman Mı?")]
        public bool IsTopDepartmant { get; set; }
        [DisplayName("Üst Departman")]
        public string ParentName { get; set; } = "Yok"; // Varsayılan olarak "Yok"
    }

}
 