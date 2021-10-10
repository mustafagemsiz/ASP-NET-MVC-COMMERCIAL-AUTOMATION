using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Model
{
    public class KargoTakip
    {
        [Key]
        public int KargoTakipId { get; set; }

        [Column(TypeName="Varchar")]
        [StringLength(10, ErrorMessage = "En fazla 10 karakter giriniz.")]
        [Required(ErrorMessage = "Lütfen boş alan bırakmayınız.")]
        [MinLength(1, ErrorMessage = "Lütfen daha uzun bir değer giriniz.")]
        public string TakipKodu { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100, ErrorMessage = "En fazla 100 karakter giriniz.")]
        [Required(ErrorMessage = "Lütfen boş alan bırakmayınız.")]
        [MinLength(1, ErrorMessage = "Lütfen daha uzun bir değer giriniz.")]
        public string Aciklama { get; set; }

        public DateTime TarihZaman { get; set; }
    }
}