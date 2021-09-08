using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HepsiBizde.PazarYerleri
{
    public class Bisiat
    {
        public Bisiat()
        {
            BisiatConnect data = new BisiatConnect();
            BisiatGetByToken.GetToken getByToken = new BisiatGetByToken.GetToken();
            IRestResponse response = data.GetByToken();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                getByToken = JsonConvert.DeserializeObject<BisiatGetByToken.GetToken>(response.Content);
                Token = getByToken.Message.Token;
            }

        }
        public class BisiatConnect
        {
            private readonly string urlBase = ConfigurationManager.AppSettings["BisiatBaseUrl"];
            private readonly string user = ConfigurationManager.AppSettings["BisiatUser"], pass = ConfigurationManager.AppSettings["BisiatPass"];

            public IRestResponse GetByToken()
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                var client = new RestClient(urlBase + "generateToken");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                string body = "{\"email\":\"" + user + "\",\"password\":\"" + pass + "\"}";

                request.AddParameter("application/json", body, ParameterType.RequestBody);
                if (!string.IsNullOrEmpty(body))
                {
                    request.AddParameter("application/json", body, ParameterType.RequestBody);
                }
                IRestResponse response = client.Execute(request);

                return response;
            }
            public IRestResponse GetByItems(string url, string body, Method method, string token)
            {
                //url = "auth/getToken";
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                var client = new RestClient(urlBase + url);
                client.Timeout = -1;
                var request = new RestRequest(method);
                request.AddHeader("Authorization", "Bearer " + token);

                if (!string.IsNullOrEmpty(body))
                {
                    request.AddParameter("application/json", body, ParameterType.RequestBody);
                }
                IRestResponse response = client.Execute(request);

                return response;
            }
        }
    }
}