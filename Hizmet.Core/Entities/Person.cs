using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hizmet.Core.Entities
{
    public class Person
    {
        public int Id { get; set; }
        [Display(Name = "Ad")]
        public string Name { get; set; }
        [Display(Name = "Soyad")]
        public string Surname { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Telefon")]
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }
        [Display(Name = "Adres")]
        public string? Address { get; set; }
        [Display(Name = "Doğum Tarihi")]
        public DateTime? BirthDate { get; set; }
        [ScaffoldColumn(false)]
        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime CreateDate { get; set; }=DateTime.Now;

    }
}
