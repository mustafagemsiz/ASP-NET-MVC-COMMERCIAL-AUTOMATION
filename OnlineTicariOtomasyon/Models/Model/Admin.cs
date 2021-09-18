using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Model
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Column(TypeName = "Varchar")]
        [Required(ErrorMessage = "Lütfen boş alan bırakmayınız.")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter giriniz.")]
        [MinLength(2, ErrorMessage = "Lütfen daha uzun bir değer giriniz.")]
        public string KullaniciAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage = "Lütfen boş alan bırakmayınız.")]
        [MinLength(2, ErrorMessage = "Lütfen daha uzun bir değer giriniz.")]
        public string Sifre { get; set; }

        [StringLength(1)]
        public string Yetki { get; set; }
    }
}