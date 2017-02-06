using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GAPSZ.Models
{
    public class ArticleModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Price")]
        public double Price { get; set; }
        [Display(Name = "Total in Shelf")]
        public int Total_in_shelf { get; set; }
        [Display(Name = "Total in Vault")]
        public int Total_in_vault { get; set; }
        [Display(Name = "Store Id")]
        public string Store_id { get; set; }
        [Display(Name = "Store Name")]
        public string Store_name { get; set; }
    }
}