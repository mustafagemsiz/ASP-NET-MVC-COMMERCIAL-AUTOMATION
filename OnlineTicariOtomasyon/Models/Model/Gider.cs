﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Model
{
    public class Gider
    {
        [Key]
        public int GiderId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(200, ErrorMessage = "En fazla 200 karakter giriniz.")]
        [MinLength(2, ErrorMessage = "Lütfen boş alan bırakmayınız.")]
        public string Aciklama { get; set; }

        public DateTime Tarih { get; set; }
        public decimal Tutar { get; set; }
    }
}