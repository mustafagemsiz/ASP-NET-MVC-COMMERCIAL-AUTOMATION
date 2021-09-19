using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Model
{
    public class Urun
    {
        [Key]
        public int UrunId { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(30,ErrorMessage ="En fazla 30 karakter giriniz.")]
        [Required(ErrorMessage = "Lütfen boş alan bırakmayınız.")]
        [MinLength(2, ErrorMessage = "Lütfen daha uzun bir değer giriniz.")]
        public string UrunAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter giriniz.")]
        [Required(ErrorMessage = "Lütfen boş alan bırakmayınız.")]
        [MinLength(2, ErrorMessage = "Lütfen daha uzun bir değer giriniz.")]
        public string Marka { get; set; }

        public short Stok { get; set; }
        public decimal AlisFiyat { get; set; }
        public decimal SatisFiyat { get; set; }
        public bool Durum { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250, ErrorMessage = "En fazla 250 karakter giriniz.")]
        [Required(ErrorMessage = "Lütfen boş alan bırakmayınız.")]
        [MinLength(2, ErrorMessage = "Lütfen daha uzun bir değer giriniz.")]
        public string UrunGorsel { get; set; }

        public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }

    }
}