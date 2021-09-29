using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Model
{
    public class UrunListele
    {
        public IEnumerable<Urun> Deger1 { get; set; }
        public IEnumerable<UrunDetay> Deger2 { get; set; }
    }
}