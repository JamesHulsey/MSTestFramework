using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestFramework.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestFramework.API
{
    public class RequestObject
    {
        public enum AuthType
        {
            Basic,
            Ntml
        }

        private readonly RestClient client;
        private readonly RestRequest request;

        public RequestObject(string url, Method type, bool useDefaultWindowsCredentials = false)
        {
            client = new RestClient(url);
            request = new RestRequest(type)
            {
                UseDefaultCredentials = useDefaultWindowsCredentials
            };
        }

        public RequestObject(string url, Method type, AuthType authType, string username, string password)
        {
            try
            {
                switch (authType)
                {
                    case AuthType.Basic:
                        client = new RestClient(url)
                        {
                            Authenticator = new HttpBasicAuthenticator(username, password)
                        };
                        MyLogger.Log.Debug($"Created basic-auth client with url: {url} and username: {username}.");
                        break;
                    case AuthType.Ntml:
                        client = new RestClient(url)
                        {
                            Authenticator = new NtlmAuthenticator(username, password)
                        };
                        MyLogger.Log.Debug($"Created ntml-auth client with url: {url} and username: {username}.");
                        break;

                }
            } catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to create client with url: {url}. {e.Message}");
                throw e;
            }
            
            request = new RestRequest(type);
        }

        public IRestResponse ExecuteAndGetIRestResponse()
        {
            IRestResponse response;

            try
            {
                response = client.Execute(request);
                MyLogger.Log.Debug($"Executed request: {request}.");
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to execute request: {request}. {e.Message}");
                throw e;
            }

            return response;
        }

        public JObject ExecuteAndGetJson()
        {
            IRestResponse response = null;
            JObject jsonResponse;

            try
            {
                var responseTime = Stopwatch.StartNew();
                response = client.Execute(request);
                responseTime.Stop();

                var elapsedTimeInMilli = responseTime.ElapsedMilliseconds;
                jsonResponse = JObject.Parse(response.Content);
                jsonResponse.AddFirst(new JProperty("ResponseTime", elapsedTimeInMilli));
                jsonResponse.AddFirst(new JProperty("StatusCode", (int)response.StatusCode));
                jsonResponse.AddFirst(new JProperty("StatusDescription", response.StatusDescription));
            }
            catch (JsonReaderException jre)
            {
                MyLogger.Log.Error($"Failed to parse response content into json. Response content: {response.Content}. {jre.Message}");
                throw jre;
            }
            catch (Exception e)
            {
                MyLogger.Log.Error($"Failed to execute request: {request}. {e.Message}");
                throw e;
            }

            return jsonResponse;
            
        }
    }
}
