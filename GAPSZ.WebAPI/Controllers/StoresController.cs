using GAPSZ.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Serialization;
using Newtonsoft.Json.Linq;
using GAPSZ.WebAPI.Helpers;

namespace GAPSZ.WebAPI.Controllers
{
    [WebAPIBasicAuthentication]
    [Authorize]
    public class StoresController : ApiController
    {
        private List<Store> _stores;

        private List<Store> stores {
            get
            {
                if (_stores == null)
                    _stores = GetDBStores();
                return _stores;
            }
            set
            {
                _stores = value;
            }
        }

        private List<Store> GetDBStores()
        {
            GAPSZDatabaseEntities dbEntity = new GAPSZDatabaseEntities();
            return dbEntity.Stores.ToList();
        }

        public JObject GetAllStores()
        {
            dynamic json = new JObject();
            json.success = true;

            json.total_elements = this.stores.Count;

            dynamic stores = new JArray();
            if (this.stores.Count > 1)
                json.stores = stores;
            else
                json.store = stores;
        
            foreach(Store s in this.stores)
            {
                dynamic store = new JObject();
                store.id = s.Id;
                store.address = s.Address;
                store.name = s.Name;
                stores.Add(store);
            }

            return json;
        }

        public StoreModel GetStoreById(int id)
        {
            StoreModel result = null;
            Store s = stores.FirstOrDefault(i => i.Id == id);
            if (s != null)
            {
                result = new StoreModel();
                result.Id = s.Id;
                result.Name = s.Name;
                result.Address = s.Address;
            }
            return result;
        }

        public bool DeleteStore(int id)
        {
            bool result = false;
            try
            {
                Store newStore = new Store() { Id = id};
                GAPSZDatabaseEntities dbEntity = new GAPSZDatabaseEntities();
                dbEntity.Stores.Remove(dbEntity.Stores.FirstOrDefault(i => i.Id == id));
                dbEntity.SaveChanges();
                return true;
            }
            catch { }
            return result;
        }

        [HttpPost]
        public StoreModel Add(StoreModel store)
        {
            try
            {
                Store newStore = new Store() { Name = store.Name, Address = store.Address };
                GAPSZDatabaseEntities dbEntity = new GAPSZDatabaseEntities();
                dbEntity.Stores.Add(newStore);
                dbEntity.SaveChanges();
                return GetStoreById(newStore.Id);
            }
            catch{}
            return null;
        }

        [HttpPut]
        public StoreModel Edit(StoreModel store)
        {
            try
            {
                GAPSZDatabaseEntities dbEntity = new GAPSZDatabaseEntities();
                Store editedStore = dbEntity.Stores.FirstOrDefault(i => i.Id == store.Id);
                editedStore.Name = store.Name;
                editedStore.Address = store.Address;
                dbEntity.SaveChanges();
                return GetStoreById(editedStore.Id);
            }
            catch { }
            return null;
        }
    }
}
