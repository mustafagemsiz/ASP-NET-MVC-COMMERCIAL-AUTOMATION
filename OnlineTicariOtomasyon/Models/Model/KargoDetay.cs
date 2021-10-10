using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Model
{
    public class KargoDetay
    {
        [Key]
        public int KargoDetayId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(300, ErrorMessage = "En fazla 300 karakter giriniz.")]
        [Required(ErrorMessage = "Lütfen boş alan bırakmayınız.")]
        [MinLength(1, ErrorMessage = "Lütfen daha uzun bir değer giriniz.")]
        public string Aciklama { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10, ErrorMessage = "En fazla 10 karakter giriniz.")]
        [Required(ErrorMessage = "Lütfen boş alan bırakmayınız.")]
        [MinLength(1, ErrorMessage = "Lütfen daha uzun bir değer giriniz.")]
        public string TakipKodu { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter giriniz.")]
        [Required(ErrorMessage = "Lütfen boş alan bırakmayınız.")]
        [MinLength(1, ErrorMessage = "Lütfen daha uzun bir değer giriniz.")]
        public string Personel { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter giriniz.")]
        [Required(ErrorMessage = "Lütfen boş alan bırakmayınız.")]
        [MinLength(1, ErrorMessage = "Lütfen daha uzun bir değer giriniz.")]
        public string Alici { get; set; }

        public DateTime Tarih { get; set; }
    }
}