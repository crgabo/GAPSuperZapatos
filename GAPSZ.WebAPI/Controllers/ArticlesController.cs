using GAPSZ.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using GAPSZ.WebAPI.Helpers;
using System.Web;

namespace GAPSZ.WebAPI.Controllers
{
    [WebAPIBasicAuthentication]
    [Authorize]
    public class ArticlesController : ApiController
    {
        private List<Article> _articles;

        private List<Article> articles
        {
            get
            {
                if (_articles == null)
                    _articles = GetDBArticles();
                return _articles;
            }
            set
            {
                _articles = value;
            }
        }

        private List<Article> GetDBArticles()
        {
            GAPSZDatabaseEntities dbEntity = new GAPSZDatabaseEntities();
            return dbEntity.Articles.ToList();
        }

        public JObject GetAllArticles()
        {
            return GetArticle(this.articles);
        }


        [HttpGet]
        public ArticleModel GetArticlesById(int id)
        {
            ArticleModel result = null;
            Article a = articles.FirstOrDefault(i => i.Id == id);
            if (a != null)
            {
                result = new ArticleModel();
                result.Id = a.Id;
                result.Name = a.Name;
                result.Description = a.Description;
                result.Price = double.Parse(a.Price.ToString());
                result.Total_in_shelf = a.TotalInShelf;
                result.Total_in_vault = a.TotalInVault;
                result.Store_id = a.StoreId;
                result.Store_name = a.Store.Name;
            }
            return result;
        }

        [HttpDelete]
        public bool DeleteArticles(int id)
        {
            bool result = false;
            try
            {
                Article newStore = new Article() { Id = id };
                GAPSZDatabaseEntities dbEntity = new GAPSZDatabaseEntities();
                dbEntity.Articles.Remove(dbEntity.Articles.FirstOrDefault(i => i.Id == id));
                dbEntity.SaveChanges();
                return true;
            }
            catch { }
            return result;
        }

        [HttpPost]
        public ArticleModel Add(ArticleModel article)
        {
            try
            {
                Article newArticle = new Article() {
                    Id = article.Id,
                    Name = article.Name,
                    Description = article.Description,
                    Price = decimal.Parse(article.Price.ToString()),
                    TotalInShelf = int.Parse(article.Total_in_shelf.ToString()),
                    TotalInVault = int.Parse(article.Total_in_vault.ToString()),
                    StoreId = article.Store_id
                };
                GAPSZDatabaseEntities dbEntity = new GAPSZDatabaseEntities();
                dbEntity.Articles.Add(newArticle);
                dbEntity.SaveChanges();
                return GetArticlesById(newArticle.Id);
            }
            catch { }
            return null;
        }

        [HttpPut]
        public ArticleModel Edit(ArticleModel article)
        {
            try
            {
                GAPSZDatabaseEntities dbEntity = new GAPSZDatabaseEntities();
                Article editedArticle = dbEntity.Articles.FirstOrDefault(i => i.Id == article.Id);
                editedArticle.Id = article.Id;
                editedArticle.Name = article.Name;
                editedArticle.Description = article.Description;
                editedArticle.Price = decimal.Parse(article.Price.ToString());
                editedArticle.TotalInShelf = int.Parse(article.Total_in_shelf.ToString());
                editedArticle.TotalInVault = int.Parse(article.Total_in_vault.ToString());
                editedArticle.StoreId = article.Store_id;
                dbEntity.SaveChanges();
                return GetArticlesById(editedArticle.Id);
            }
            catch { }
            return null;
        }

        [HttpGet]
        [Route("services/articles/stores/{id}")]
        [WebAPIErrorsHandler]
        public JObject GetArticlesByStore(int id)
        {
            List<Article> articleList = articles.Where(i => i.StoreId == id).ToList<Article>();
            if (articleList.Count == 0)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return GetArticle(articleList);
        }

        private JObject GetArticle(List<Article> articleList)
        {
            dynamic json = new JObject();
            json.success = true;

            json.total_elements = articleList.Count;

            dynamic articles = new JArray();
            if (articleList.Count > 1)
                json.articles = articles;
            else
                json.article = articles;

            foreach (Article s in articleList)
            {
                StoresController sc = new StoresController();

                dynamic article = new JObject();
                article.id = s.Id;
                article.description = s.Description;
                article.name = s.Name;
                article.price = s.Price;
                article.total_in_shelf = s.TotalInShelf;
                article.total_in_vault = s.TotalInVault;
                article.store_id = s.StoreId;
                article.store_name = sc.GetStoreById(s.StoreId).Name;
                articles.Add(article);
            }

            return json;
        }
    }
}
