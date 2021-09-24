using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Model
{
    public class Fatura
    {
        [Key]
        public int FaturaId { get; set; }

        [Column(TypeName = "Char")]
        [Required(ErrorMessage = "Lütfen boş alan bırakmayınız.")]
        [StringLength(1, ErrorMessage = "En fazla 1 karakter giriniz.")]
        public string FaturaSeriNo { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6, ErrorMessage = "En fazla 6 karakter giriniz.")]
        [Required(ErrorMessage = "Lütfen boş alan bırakmayınız.")]
        [MinLength(2, ErrorMessage = "Lütfen daha uzun bir değer giriniz.")]
        public string FaturaSıraNo { get; set; }

        public DateTime Tarih { get; set; }

        [Column(TypeName ="Char")]
        [Required(ErrorMessage = "Lütfen boş alan bırakmayınız.")]
        [StringLength(5, ErrorMessage = "En fazla 5 karakter giriniz.")]
        [MinLength(2, ErrorMessage = "Lütfen daha uzun bir değer giriniz.")]
        public string Saat { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60, ErrorMessage = "En fazla 60 karakter giriniz.")]
        [Required(ErrorMessage = "Lütfen boş alan bırakmayınız.")]
        [MinLength(2, ErrorMessage = "Lütfen daha uzun bir değer giriniz.")]
        public string VergiDairesi { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter giriniz.")]
        [Required(ErrorMessage = "Lütfen boş alan bırakmayınız.")]
        [MinLength(2, ErrorMessage = "Lütfen daha uzun bir değer giriniz.")]
        public string TeslimEden { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter giriniz.")]
        [Required(ErrorMessage = "Lütfen boş alan bırakmayınız.")]
        [MinLength(2, ErrorMessage = "Lütfen daha uzun bir değer giriniz.")]
        public string TeslimAlan { get; set; }


        [Required(ErrorMessage = "Lütfen boş alan bırakmayınız.")]
        public decimal ToplamTutar { get; set; }

        public ICollection<FaturaKalem> FaturaKalems { get; set; }
    }
}