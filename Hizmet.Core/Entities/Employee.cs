using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hizmet.Core.Entities
{
    public class Employee:Person 
    {
        public bool IsActive { get; set; }
        [DisplayName("İşe Giriş Tarihi")]
        public DateTime Startdate { get; set; }
        [DisplayName("İşten Çıkış Tarihi")]
        public DateTime? TerminationDate { get; set; }
        public int DepartmantId { get; set; }
        public  Departmant? Departmant { get; set; }
        public List <Service>? Services { get; set; }

    }
}
