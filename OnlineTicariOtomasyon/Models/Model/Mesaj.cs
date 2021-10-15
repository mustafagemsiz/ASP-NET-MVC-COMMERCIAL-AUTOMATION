using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Model
{
    public class Mesaj
    {
        [Key]
        public int MesajId { get; set; }

        [Display(Name ="Gönderici")]
        [Required(ErrorMessage = "Lütfen boş alan bırakmayınız.")]
        [Column(TypeName = "Varchar")]
        [MaxLength(50, ErrorMessage = "En fazla 50 karakter giriniz.")]
        public string Gonderici { get; set; }

        [Display(Name = "Alıcı")]
        [Required(ErrorMessage = "Lütfen boş alan bırakmayınız.")]
        [Column(TypeName = "Varchar")]
        [MaxLength(50, ErrorMessage = "En fazla 50 karakter giriniz.")]
        public string Alici { get; set; }

        [Display(Name = "Konu")]
        [Required(ErrorMessage = "Lütfen boş alan bırakmayınız.")]
        [Column(TypeName = "Varchar")]
        [MaxLength(50, ErrorMessage = "En fazla 50 karakter giriniz.")]
        public string Konu { get; set; }

        [Display(Name = "İçerik")]
        [Required(ErrorMessage = "Lütfen boş alan bırakmayınız.")]
        [Column(TypeName = "Varchar")]
        [MaxLength(2000, ErrorMessage = "En fazla 2000 karakter giriniz.")]
        public string Icerik { get; set; }

        [Display(Name ="Tarih")]
        public DateTime Tarih { get; set; }

    }
}