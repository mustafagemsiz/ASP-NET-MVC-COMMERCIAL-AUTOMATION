﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Model;
namespace OnlineTicariOtomasyon.Controllers
{
    public class IstatistikController : Controller
    {
        DataContext context = new DataContext();
        // GET: Istatistik
        public ActionResult Index()
        {

            var CariSayisi = context.Caris.Count().ToString();
            var UrunSayisi = context.Uruns.Count().ToString();
            var PersonelSayisi = context.Personels.Count().ToString();
            var KategoriSayisi = context.Kategoris.Count().ToString();
            var UrunStokSayisi = context.Uruns.Sum(x => x.Stok).ToString();
            var MarkaSayisi = (from x in context.Uruns select x.Marka).Distinct().Count().ToString();
            var KritikUrunSayisi = context.Uruns.Count(x => x.Stok <= 20).ToString();
            var MaxFiyatUrun = (from x in context.Uruns orderby x.SatisFiyat descending select x.UrunAd).FirstOrDefault().ToString();
            var MinFiyatUrun = (from x in context.Uruns orderby x.SatisFiyat ascending select x.UrunAd).FirstOrDefault().ToString();
            var BuzdolabıSayisi = context.Uruns.Where(x => x.KategoriId == 1).Sum(x => x.Stok).ToString();
            var LaptopSayisi = context.Uruns.Where(x => x.KategoriId == 4).Sum(x => x.Stok).ToString();
            var PopulerMarka = context.Uruns.GroupBy(x => x.Marka).OrderByDescending(x => x.Count()).Select(x => x.Key).FirstOrDefault().ToString();
            var KasaToplamTutar = context.SatisHarekets.Sum(x => (decimal?)x.ToplamTutar).ToString();
            DateTime today = DateTime.Today;
            var GunlukSatisTutari = context.SatisHarekets.Count(x => x.Tarih == today).ToString();
            var GunlukSatisKasaDurum = context.SatisHarekets.Where(x => x.Tarih == today).Sum(x => (decimal?)x.ToplamTutar).ToString();
            var EnCokSatanUrunAd = from SatisHareket in context.SatisHarekets

                                               join Urun in context.Uruns on SatisHareket.UrunId equals Urun.UrunId

                                               group SatisHareket by SatisHareket.Urun.UrunAd into grup

                                               select new

                                               {

                                                   UrunAd = grup.Key,

                                                   Adet = grup.Sum(x => x.Adet)

                                               };

            //ViewBag
            ViewBag.Cari = CariSayisi;
            ViewBag.Urun = UrunSayisi;
            ViewBag.Personel = PersonelSayisi;
            ViewBag.Kategori = KategoriSayisi;
            ViewBag.UrunStok = UrunStokSayisi;
            ViewBag.Marka = MarkaSayisi;
            ViewBag.KritikUrun = KritikUrunSayisi;
            ViewBag.MaxFiyat = MaxFiyatUrun;
            ViewBag.MinFiyat = MinFiyatUrun;
            ViewBag.BeyazEsya = BuzdolabıSayisi;
            ViewBag.BilgiSayar = LaptopSayisi;
            ViewBag.KasaToplam = KasaToplamTutar;
            ViewBag.PopulerMarka = PopulerMarka;
            ViewBag.EnCokSatan = EnCokSatanUrunAd.OrderByDescending(x => x.Adet).ToList().FirstOrDefault().UrunAd;

            //ViewBag.GunlukSatis = GunlukSatisTutari;
            if (GunlukSatisTutari != "")
            {
                ViewBag.GunlukSatis = GunlukSatisTutari;
            }
            else
            {
                ViewBag.GunlukSatis = "Satış Yapılmadı";
            }
            //ViewBag.GunlukKasa = GunlukSatisKasaDurum;
            if (GunlukSatisKasaDurum!="")
            {
                ViewBag.GunlukKasa = GunlukSatisKasaDurum;
            }
            else
            {
                ViewBag.GunlukKasa = "Satış Yok".ToString();
            }
            


            return View();
        }
    }
}