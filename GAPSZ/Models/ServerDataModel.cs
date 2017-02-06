using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GAPSZ.Models
{
    public class ServerDataModel
    {
        private List<StoreModel> _stores = null;
        private List<ArticleModel> _articles = null;
        public bool success { get; set; }
        public int total_elements { get; set; }
        public StoreModel store { get; set; }       
        public List<StoreModel> stores {
            get {
                if (_stores == null && store != null)
                    _stores.Add(store);
                return _stores;
            }
            set { _stores = value; }
        }

        public ArticleModel article { get; set; }
        public List<ArticleModel> articles
        {
            get
            {
                if (_articles == null && article != null)
                    _articles.Add(article);
                return _articles;
            }
            set { _articles = value; }
        }
        public int error_code { get; set; }
        public string error_msg { get; set; }
    }
}