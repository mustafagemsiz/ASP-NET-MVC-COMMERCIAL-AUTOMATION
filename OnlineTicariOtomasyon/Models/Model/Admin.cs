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
        [StringLength(30, ErrorMessage = "En fazla 30 karakter giriniz.")]
        [MinLength(2, ErrorMessage = "Lütfen boş alan bırakmayınız.")]
        public string KullaniciAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [MinLength(2, ErrorMessage = "Lütfen boş alan bırakmayınız.")]
        public string Sifre { get; set; }

        [StringLength(1)]
        public string Yetki { get; set; }
    }
}