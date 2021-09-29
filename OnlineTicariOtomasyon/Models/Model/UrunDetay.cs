using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Model
{
    public class UrunDetay
    {
        [Key]
        public int DetayId { get; set; }

        [Column(TypeName="Varchar")]
        [Required(ErrorMessage = "Lütfen boş alan bırakmayınız.")]
        [MaxLength(30, ErrorMessage = "En fazla 30 karakter giriniz.")]
        public string UrunAd { get; set; }

        [Column(TypeName = "Varchar")]
        [Required(ErrorMessage = "Lütfen boş alan bırakmayınız.")]
        [MaxLength(500, ErrorMessage = "En fazla 500 karakter giriniz.")]
        public string UrunBilgi { get; set; }

    }

}