using System;
using GAPSZ.Helpers;
using GAPSZ.Models;
using System.Web.Mvc;

namespace GAPSZ.Controllers
{
    public class ArticleController : Controller
    {
        static readonly IServerDataRestClient RestClient = new ServerDataRestClient();

        private IServerDataRestClient _restClient;

        public ArticleController()
        {
        }

        public ArticleController(IServerDataRestClient restClient)
        {
            _restClient = restClient;
        }

        // GET: Article
        public ActionResult Index()
        {
            return View(RestClient.GetAllArticles());
        }

        // GET: Article/Details/5
        public ActionResult Details(int id)
        {
            return View(RestClient.GetArticleById(id));
        }

        // GET: Article/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Article/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                RestClient.ArticleAdd(new ArticleModel() {
                    Name = collection.GetValue("Name").AttemptedValue,
                    Description = collection.GetValue("Description").AttemptedValue,
                    Price = double.Parse(collection.GetValue("Price").AttemptedValue),
                    Total_in_shelf = int.Parse(collection.GetValue("Total_in_shelf").AttemptedValue),
                    Total_in_vault = int.Parse(collection.GetValue("Total_in_vault").AttemptedValue),
                    Store_id = collection.GetValue("Store_id").AttemptedValue
                });
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Article/Edit/5
        public ActionResult Edit(int id)
        {
            return View(RestClient.GetArticleById(id));
        }

        // POST: Article/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                RestClient.ArticleEdit(new ArticleModel() {
                    Id = id,
                    Name = collection.GetValue("Name").AttemptedValue,
                    Description = collection.GetValue("Description").AttemptedValue,
                    Price = double.Parse(collection.GetValue("Price").AttemptedValue),
                    Total_in_shelf = int.Parse(collection.GetValue("Total_in_shelf").AttemptedValue),
                    Total_in_vault = int.Parse(collection.GetValue("Description").AttemptedValue),
                    Store_id = collection.GetValue("Store_id").AttemptedValue
                });
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Article/Delete/5
        public ActionResult Delete(int id)
        {
            return View(RestClient.GetArticleById(id));
        }

        // POST: Article/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                RestClient.ArticleDelete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
