using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Model
{
    public class Departman
    {
        [Key]
        public int DepartmanId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter giriniz.")]
        [Required(ErrorMessage = "Lütfen boş alan bırakmayınız.")]
        [MinLength(2, ErrorMessage = "Lütfen daha uzun bir değer giriniz.")]
        public string DepartmanAd { get; set; }

        public ICollection<Personel> Personels { get; set; }
    }
}