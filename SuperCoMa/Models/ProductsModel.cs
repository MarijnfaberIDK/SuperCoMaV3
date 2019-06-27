using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperCoMa.Areas.Admin.Models
{
    public class ProductsModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string EAN { get; set; }

        [Display(Name = "Titel")]
        public string Title { get; set; }

        [Display(Name = "Merk")]
        public string Brand { get; set; }

        [Display(Name = "Korte beschrijving")]
        public string ShortDescription { get; set; }

        [Display(Name = "Volle beschrijving")]
        public string FullDescription { get; set; }

        [Display(Name = "Product afbeelding")]
        public string Image { get; set; }

        [Display(Name = "Gewicht")]
        public double Weight { get; set; }

        [Display(Name = "Prijs")]
        public double Price { get; set; }

        [Display(Name = "Categorie")]
        public string Category { get; set; }

        [Display(Name = "Sub-categorie")]
        public string SubCategory { get; set; }

        [Display(Name = "Sub-sub-categorie")]
        public string SubSubCategory { get; set; }
    }
}
