using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Model
{
    public class Kategori
    {
        [Key]
        public int KategoriId { get; set; }

        [Required(ErrorMessage = "Lütfen boş alan bırakmayınız.")]
        [Column(TypeName = "Varchar")]
        [MaxLength(30, ErrorMessage = "En fazla 30 karakter giriniz.")]
        public string KategoriAd { get; set; }

        public ICollection<Urun> Uruns { get; set; }
    }
}