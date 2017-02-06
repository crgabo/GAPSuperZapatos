using GAPSZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAPSZ.Helpers
{
    public interface IServerDataRestClient
    {
        //Store
        IEnumerable<ServerDataModel> GetAllStores();
        StoreModel GetStoreById(int id);
        bool StoreAdd(StoreModel store);
        bool StoreDelete(int id);
        StoreModel StoreEdit(StoreModel store);

        //Article
        IEnumerable<ServerDataModel> GetAllArticles();
        ArticleModel GetArticleById(int id);
        bool ArticleAdd(ArticleModel store);
        bool ArticleDelete(int id);
        ArticleModel ArticleEdit(ArticleModel store);
    }
}
