using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Model
{
    public class Cari
    {
        [Key]
        public int CariId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter giriniz.")]
        [MinLength(2, ErrorMessage = "Lütfen boş alan bırakmayınız.")]
        public string CariAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter giriniz.")]
        [MinLength(2, ErrorMessage = "Lütfen boş alan bırakmayınız.")]
        public string CariSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(13, ErrorMessage = "En fazla 13 karakter giriniz.")]
        [MinLength(2, ErrorMessage = "Lütfen boş alan bırakmayınız.")]
        public string CariSehir { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter giriniz.")]
        [MinLength(2, ErrorMessage = "Lütfen boş alan bırakmayınız.")]
        public string CariMail { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}