using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAPSZ.WebAPI.Models
{
    public class ArticleModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Total_in_shelf { get; set; }
        public double Total_in_vault { get; set; }
        public int Store_id { get; set; }
        public string Store_name { get; set; }
    }
}