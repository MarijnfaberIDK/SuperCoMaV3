using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperCoMa.Models
{
    public class CategoriesModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } //subcategory
        //public string SubCategory { get; set; } //subsubcategory
        //nog toevoegen: Product-Categories
    }
}
