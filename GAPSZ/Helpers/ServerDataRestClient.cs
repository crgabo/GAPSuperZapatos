using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GAPSZ.Models;
using RestSharp;
using System.Configuration;
using RestSharp.Authenticators;
using System.Net;

namespace GAPSZ.Helpers
{
    public class ServerDataRestClient : IServerDataRestClient
    {
        private readonly RestClient _client;
        private readonly string _url = ConfigurationManager.AppSettings["WebAPIBaseUrl"];
        private readonly string _user = ConfigurationManager.AppSettings["WebAPIUser"];
        private readonly string _password = ConfigurationManager.AppSettings["WebAPIPassword"];

        public ServerDataRestClient()
        {
            _client = new RestClient { BaseUrl = new System.Uri(_url) };
            _client.Authenticator = new HttpBasicAuthenticator(_user, _password);
        }

        #region Stores
        public IEnumerable<ServerDataModel> GetAllStores()
        {
            var request = new RestRequest("services/stores", Method.GET)
                { RequestFormat = DataFormat.Json,
                };

            var response = _client.Execute<List<ServerDataModel>>(request);

            if (response.Data == null)
                throw new Exception(response.ErrorMessage);

            return response.Data;
        }

        public StoreModel GetStoreById(int id)
        {
            var request = new RestRequest("services/stores/{id}", Method.GET)
            {
                RequestFormat = DataFormat.Json,
            };

            request.AddParameter("id", id, ParameterType.UrlSegment);

            var response = _client.Execute<StoreModel>(request);

            if (response.Data == null)
                throw new Exception(response.ErrorMessage);

            return response.Data;
        }

        public bool StoreAdd(StoreModel store)
        {
            var request = new RestRequest("services/stores", Method.POST)
            { RequestFormat = DataFormat.Json };
            request.AddBody(store);

            var response = _client.Execute<StoreModel>(request);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.ErrorMessage);

            return response.StatusCode == HttpStatusCode.OK;
        }

        public bool StoreDelete(int id)
        {
            var request = new RestRequest("services/stores/{id}", Method.DELETE)
            {
                RequestFormat = DataFormat.Json,
            };

            request.AddParameter("id", id, ParameterType.UrlSegment);

            var response = _client.Execute<bool>(request);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.ErrorMessage);

            return response.StatusCode == HttpStatusCode.OK;
        }

        public StoreModel StoreEdit(StoreModel store)
        {
            var request = new RestRequest("services/stores", Method.PUT)
            {
                RequestFormat = DataFormat.Json,
            };
            request.AddBody(store);

            var response = _client.Execute<StoreModel>(request);

            if (response.Data == null)
                throw new Exception(response.ErrorMessage);

            return response.Data;
        }

        #endregion

        #region Articles
        public IEnumerable<ServerDataModel> GetAllArticles()
        {
            var request = new RestRequest("services/articles", Method.GET)
            {
                RequestFormat = DataFormat.Json,
            };

            var response = _client.Execute<List<ServerDataModel>>(request);

            if (response.Data == null)
                throw new Exception(response.ErrorMessage);

            return response.Data;
        }

        public ArticleModel GetArticleById(int id)
        {
            var request = new RestRequest("services/articles/{id}", Method.GET)
            {
                RequestFormat = DataFormat.Json,
            };

            request.AddParameter("id", id, ParameterType.UrlSegment);

            var response = _client.Execute<ArticleModel>(request);

            if (response.Data == null)
                throw new Exception(response.ErrorMessage);

            return response.Data;
        }

        public bool ArticleAdd(ArticleModel article)
        {
            var request = new RestRequest("services/articles", Method.POST)
            { RequestFormat = DataFormat.Json };
            request.AddBody(article);

            var response = _client.Execute<ArticleModel>(request);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.ErrorMessage);

            return response.StatusCode == HttpStatusCode.OK;
        }

        public bool ArticleDelete(int id)
        {
            var request = new RestRequest("services/articles/{id}", Method.DELETE)
            {
                RequestFormat = DataFormat.Json,
            };

            request.AddParameter("id", id, ParameterType.UrlSegment);

            var response = _client.Execute<bool>(request);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.ErrorMessage);

            return response.StatusCode == HttpStatusCode.OK;
        }

        public ArticleModel ArticleEdit(ArticleModel article)
        {
            var request = new RestRequest("services/articles", Method.PUT)
            {
                RequestFormat = DataFormat.Json,
            };
            request.AddBody(article);

            var response = _client.Execute<ArticleModel>(request);

            if (response.Data == null)
                throw new Exception(response.ErrorMessage);

            return response.Data;
        }

        #endregion
    }
}