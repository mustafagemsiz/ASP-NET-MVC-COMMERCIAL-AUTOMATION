using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Model
{
    public class SatisHareket
    {
        [Key]
        public int SatisId { get; set; }
        public Urun Urun { get; set; }
        public Cari Cari { get; set; }
        public Personel Personel { get; set; }
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }
    }
}