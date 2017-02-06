using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json.Linq;

namespace GAPSZ.WebAPI.Helpers
{
    public class WebAPIErrorResult : IHttpActionResult
    {
        HttpStatusCode statusCode;
        public WebAPIErrorResult(HttpStatusCode statusCode, string message, HttpRequestMessage request)
        {
            ReasonPhrase = message;
            Request = request;
            this.statusCode = statusCode;
        }

        public string ReasonPhrase { get; private set; }

        public HttpRequestMessage Request { get; private set; }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());
        }

        public HttpResponseMessage ExecuteSync()
        {
            return Execute();
        }

        private HttpResponseMessage Execute()
        {
            string message;
            switch (statusCode)
            {
                case HttpStatusCode.BadRequest:
                    message = "Bad request";
                    break;
                case HttpStatusCode.Unauthorized:
                    message = "Not Authorized";
                    break;
                case HttpStatusCode.NotFound:
                    message = "Record Not Found";
                    break;
                case HttpStatusCode.InternalServerError:
                    message = "Server Error";
                    break;
                default:
                    message = ReasonPhrase;
                    break;
            }

            dynamic json = new JObject();
            json.success = false;
            json.error_code = statusCode;
            json.error_msg = message;

            string jsonString = json.ToString();

            var response = Request.CreateResponse(statusCode);
            response.Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");

            return response;
        }
    }
}