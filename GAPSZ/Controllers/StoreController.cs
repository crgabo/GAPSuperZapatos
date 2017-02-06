using GAPSZ.Helpers;
using GAPSZ.Models;
using System.Web.Mvc;

namespace GAPSZ.Controllers
{
    public class StoreController : Controller
    {
        static readonly IServerDataRestClient RestClient = new ServerDataRestClient();

        private IServerDataRestClient _restClient;

        public StoreController()
        {
        }

        public StoreController(IServerDataRestClient restClient)
        {
            _restClient = restClient;
        }

        // GET: Store
        public ActionResult Index()
        {
            return View(RestClient.GetAllStores());
        }

        // GET: Store/Details/5
        public ActionResult Details(int id)
        {
            return View(RestClient.GetStoreById(id));
        }

        // GET: Store/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Store/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                RestClient.StoreAdd(new StoreModel() { Name = collection.GetValue("Name").AttemptedValue, Address = collection.GetValue("Address").AttemptedValue });
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Store/Edit/5
        public ActionResult Edit(int id)
        {
            return View(RestClient.GetStoreById(id));
        }

        // POST: Store/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                RestClient.StoreEdit(new StoreModel() {Id = id,  Name = collection.GetValue("Name").AttemptedValue, Address = collection.GetValue("Address").AttemptedValue });
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Store/Delete/5
        public ActionResult Delete(int id)
        {
            return View(RestClient.GetStoreById(id));
        }

        // POST: Store/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                RestClient.StoreDelete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
