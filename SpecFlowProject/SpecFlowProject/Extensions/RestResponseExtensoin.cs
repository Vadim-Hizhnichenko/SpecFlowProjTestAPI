using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Extensions
{
    public static class RestResponseExtensoin
    {
        public static IRestResponse ExecuteRequest(this IRestResponse response, ScenarioContext scenarionContext)
        {
            var client = scenarionContext.Get<RestClient>("client");
            var request = scenarionContext.Get<RestRequest>("request");
            response = client.Execute(request);

            
            scenarionContext.Remove("response");
            scenarionContext.Add("response",response);
            return response;
        
        }

        public static IRestResponse GetResponseContent<T>(this IRestResponse response, ScenarioContext scenarionContext) where T : new()
        {
            var _desializer = new JsonDeserializer();
            T model = _desializer.Deserialize<T>(scenarionContext.Get<RestResponse>("response"));

            scenarionContext.Remove("model");
            scenarionContext.Add("model", model);
            
            return response;
        }

        public static List<IRestResponse> GetResponseContentWithList<T>(this IRestResponse response, ScenarioContext scenarionContext)  where T : new ()
        {
            var _desializer = new JsonDeserializer();
            List<T> model = _desializer.Deserialize<List<T>>(scenarionContext.Get<RestResponse>("response"));
            

            scenarionContext.Remove("model");
            scenarionContext.Add("model", model);
            
            return (List<IRestResponse>)response;
        }
    }
}
