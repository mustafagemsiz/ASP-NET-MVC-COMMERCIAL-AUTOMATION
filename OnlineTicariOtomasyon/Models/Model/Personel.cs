using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Model
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter giriniz.")]
        [Required(ErrorMessage = "Lütfen boş alan bırakmayınız.")]
        [MinLength(2, ErrorMessage = "Lütfen daha uzun bir değer giriniz.")]
        public string PersonelAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter giriniz.")]
        [Required(ErrorMessage = "Lütfen boş alan bırakmayınız.")]
        [MinLength(2, ErrorMessage = "Lütfen daha uzun bir değer giriniz.")]
        public string PersonelSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100, ErrorMessage = "En fazla 100 karakter giriniz.")]
        [Required(ErrorMessage = "Lütfen boş alan bırakmayınız.")]
        [MinLength(2, ErrorMessage = "Lütfen daha uzun bir değer giriniz.")]
        public string PersonelAdres { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter giriniz.")]
        [Required(ErrorMessage = "Lütfen boş alan bırakmayınız.")]
        [MinLength(2, ErrorMessage = "Lütfen daha uzun bir değer giriniz.")]
        public string PersonelTelefon { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250, ErrorMessage = "En fazla 250 karakter giriniz.")]
        [Required(ErrorMessage = "Lütfen boş alan bırakmayınız.")]
        [MinLength(2, ErrorMessage = "Lütfen daha uzun bir değer giriniz.")]
        public string PersonelGorsel { get; set; }

        public ICollection<SatisHareket> SatisHarekets { get; set; }
        public Departman Departman { get; set; }
    }
}